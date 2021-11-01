using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductionsProductionCompany.Models.ObjectModels;

namespace ProductionsProductionCompany.Data.DAL
{
    public class PayrollRepo : IPayrollRepo, IDisposable
    {
        private ApplicationDbContext context;

        public PayrollRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Payroll> GetPayrolls()
        {
            return context.Payrolls.ToList();
        }

        public Payroll GetPayrollByID(int id)
        {
            return context.Payrolls.Find(id);
        }

        public void InsertPayroll(Payroll payroll)
        {
            context.Payrolls.Add(payroll);
        }

        public void DeletePayroll(int payrollId)
        {
            Payroll payroll = context.Payrolls.Find(payrollId);
            context.Payrolls.Remove(payroll);
        }

        public void UpdatePayroll(Payroll payroll)
        {
            context.Entry(payroll).State = EntityState.Modified;
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
