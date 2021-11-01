using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductionsProductionCompany.Models.ObjectModels;

namespace ProductionsProductionCompany.Data.DAL
{
    public class DivisionRepo : IDivisionRepo, IDisposable
    {
        private ApplicationDbContext context;

        public DivisionRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Division> GetDivisions()
        {
            return context.Divisions.ToList();
        }

        public Division GetDivisionByID(int id)
        {
            return context.Divisions.Find(id);
        }

        public Employee GetDivisionManager(Division divisionId)
        {
            return context.Divisions.Find(divisionId).DivisionManager;
        }

        public void InsertDivision(Division division)
        {
            context.Divisions.Add(division);
        }

        public void DeleteDivision(int divisionId)
        {
            Division division = context.Divisions.Find(divisionId);
            context.Divisions.Remove(division);
        }

        public void UpdateDivision(Division division)
        {
            context.Entry(division).State = EntityState.Modified;
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
