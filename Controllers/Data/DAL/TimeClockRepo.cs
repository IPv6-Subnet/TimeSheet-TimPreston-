using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProductionsProductionCompany.Models.ObjectModels;

namespace ProductionsProductionCompany.Data.DAL
{
    public class TimeClockRepo : ITimeClockRepo, IDisposable
    {
        private ApplicationDbContext context;

        public TimeClockRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<TimeClock> GetTimeClocks()
        {
            return context.TimeClocks.ToList();
        }

        public TimeClock GetTimeClockByID(int id)
        {
            return context.TimeClocks.Find(id);
        }

        public void InsertTimeClock(TimeClock timeClock)
        {
            context.TimeClocks.Add(timeClock);
        }

        public void DeleteTimeClock(int timeClockId)
        {
            TimeClock timeClock = context.TimeClocks.Find(timeClockId);
            context.TimeClocks.Remove(timeClock);
        }

        public void UpdateTimeClock(TimeClock timeClock)
        {
            context.Entry(timeClock).State = EntityState.Modified;
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
