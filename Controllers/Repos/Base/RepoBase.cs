using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using ProductionsProductionCompany.Data;
using ProductionsProductionCompany.Models.ObjectModels;

namespace ProductionsProductionCompany.Repos.Base
{
    public abstract class RepoBase<T> : IDisposable, IRepo<T> where T : EntityBase, new()
    {
        protected readonly ApplicationDbContext Db;
        protected RepoBase()
        {
            Db = new ApplicationDbContext();
            Table = Db.Set<T>();
        }
        protected RepoBase(DbContextOptions<ApplicationDbContext> options)
        {
            Db = new ApplicationDbContext(options);
            Table = Db.Set<T>();
        }


        protected DbSet<T> Table;
        public ApplicationDbContext Context => Db;

        public bool HasChanges => Db.ChangeTracker.HasChanges();

        public int Count => Table.Count();

        public T GetFirst() => Table.FirstOrDefault();

        public T Find(int? id) => Table.Find(id);

        public virtual IEnumerable<T> GetAll() => Table;

        internal IEnumerable<T> GetRange(IQueryable<T> query, int skip, int take)
            => query.Skip(skip).Take(take);
        public virtual IEnumerable<T> GetRange(int skip, int take)
            => GetRange(Table, skip, take);

        public virtual int Add(T entity, bool persist = true)
        {
            Table.Add(entity);
            return persist ? SaveChanges() : 0;
        }
        public virtual int AddRange(IEnumerable<T> entities, bool persist = true)
        {
            Table.AddRange(entities);
            return persist ? SaveChanges() : 0;
        }
        public virtual int Update(T entity, bool persist = true)
        {
            Table.Update(entity);
            return persist ? SaveChanges() : 0;
        }
        public virtual int UpdateRange(IEnumerable<T> entities, bool persist = true)
        {
            Table.UpdateRange(entities);
            return persist ? SaveChanges() : 0;
        }
        public virtual int Delete(T entity, bool persist = true)
        {
            Table.Remove(entity);
            return persist ? SaveChanges() : 0;
        }
        public virtual int DeleteRange(IEnumerable<T> entities, bool persist = true)
        {
            Table.RemoveRange(entities);
            return persist ? SaveChanges() : 0;
        }

        internal T GetEntryFromChangeTracker(int? id)
        {
            return Db.ChangeTracker.Entries<T>()
                .Select((EntityEntry e) => (T)e.Entity)
                    .FirstOrDefault(x => x.Id == id);
        }

        //TODO: Check For Cascade Delete
        public int Delete(int id, byte[] rowVersion, bool persist = true)
        {
            var entry = GetEntryFromChangeTracker(id);
            if (entry != null)
            {
                if (rowVersion != null && entry.RowVersion.SequenceEqual(rowVersion))
                {
                    return Delete(entry, persist);
                }
                throw new Exception("Unable to delete due to concurrency violation.");
            }
            Db.Entry(new T { Id = id, RowVersion = rowVersion }).State = EntityState.Deleted;
            return persist ? SaveChanges() : 0;
        }

        public int SaveChanges()
        {
            try
            {
                return Db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //A concurrency error occurred
                //Should handle intelligently
                Console.WriteLine(ex);
                throw;
            }
            catch (RetryLimitExceededException ex)
            {
                //DbResiliency retry limit exceeded
                //Should handle intelligently
                Console.WriteLine(ex);
                throw;
            }
            catch (Exception ex)
            {
                //Should handle intelligently
                Console.WriteLine(ex);
                throw;
                //-2146232060
                //throw new Exception($"{ex.HResult}");
            }
        }

        bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here. 
                //
            }
            Db.Dispose();
            _disposed = true;
        }
    }
}
