using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProductionsProductionCompany.Models.ObjectModels;

namespace ProductionsProductionCompany.Data.DAL
{
    public class PayPeriodRepo : IPayPeriodRepo, IDisposable
    {
        private ApplicationDbContext context;

        public PayPeriodRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<PayPeriod> GetPayPeriods()
        {
            return context.PayPeriods.ToList();
        }

        public PayPeriod GetPayPeriodByID(int id)
        {
            return context.PayPeriods.Find(id);
        }

        public void InsertPayPeriod(PayPeriod payPeriod)
        {
            context.PayPeriods.Add(payPeriod);
        }

        public void DeletePayPeriod(int payPeriodId)
        {
            PayPeriod payPeriod = context.PayPeriods.Find(payPeriodId);
            context.PayPeriods.Remove(payPeriod);
        }

        public void UpdatePayPeriod(PayPeriod payPeriod)
        {
            context.Entry(payPeriod).State = EntityState.Modified;
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
