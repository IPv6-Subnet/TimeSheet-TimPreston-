using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductionsProductionCompany.Models.ObjectModels;

namespace ProductionsProductionCompany.Data.DAL
{
    public class GroupRepo : IGroupRepo, IDisposable
    {
        private ApplicationDbContext context;

        public GroupRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Group> GetGroups()
        {
            return context.Groups.ToList();
        }

        public Group GetGroupByID(int id)
        {
            return context.Groups.Find(id);
        }

        public void InsertGroup(Group group)
        {
            context.Groups.Add(group);
        }

        public void DeleteGroup(int groupId)
        {
            Group group = context.Groups.Find(groupId);
            context.Groups.Remove(group);
        }

        public void UpdateGroup(Group group)
        {
            context.Entry(group).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
