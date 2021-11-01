using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using ProductionsProductionCompany.Models.ObjectModels;
using Microsoft.EntityFrameworkCore;

namespace ProductionsProductionCompany.Data.DAL
{
    public class EmployeeRepo : IEmployeeRepo, IDisposable
    {
        private ApplicationDbContext context;

        public EmployeeRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return context.Employees.ToList();
        }

        public Employee GetEmployeeByID(string id)
        {
            return context.Employees.Find(id);
        }

        public void InsertEmployee(Employee employee)
        {
            context.Employees.Add(employee);
        }

        public void DeleteEmployee(string employeeID)
        {
            Employee employee = context.Employees.Find(employeeID);
            context.Employees.Remove(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            context.Entry(employee).State = EntityState.Modified;
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