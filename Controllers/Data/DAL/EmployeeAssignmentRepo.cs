using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductionsProductionCompany.Models.ObjectModels;

namespace ProductionsProductionCompany.Data.DAL
{
    public class EmployeeAssignmentRepo : IEmployeeAssignmentRepo, IDisposable
    {
        private ApplicationDbContext context;

        public EmployeeAssignmentRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<EmployeeAssignment> GetEmployeeAssignments()
        {
            return context.EmployeeAssignments.ToList();
        }

        public EmployeeAssignment GetEmployeeAssignmentByID(int id)
        {
            return context.EmployeeAssignments.Find(id);
        }

        public void InsertEmployeeAssignment(EmployeeAssignment employeeAssignment)
        {
            context.EmployeeAssignments.Add(employeeAssignment);
        }

        public void DeleteEmployeeAssignment(int employeeAssignmentId)
        {
            EmployeeAssignment employeeAssignment = context.EmployeeAssignments.Find(employeeAssignmentId);
            context.EmployeeAssignments.Remove(employeeAssignment);
        }

        public void UpdateEmployeeAssignment(EmployeeAssignment employeeAssignment)
        {
            context.Entry(employeeAssignment).State = EntityState.Modified;
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
