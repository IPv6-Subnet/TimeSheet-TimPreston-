using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProductionsProductionCompany.Models.ObjectModels;

namespace ProductionsProductionCompany.Data.DAL
{
    public class VacationRequestRepo : IVacationRequestRepo, IDisposable
    {
        private ApplicationDbContext context;

        public VacationRequestRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<VacationRequest> GetVacationRequests()
        {
            return context.VacationRequests.ToList();
        }

        public VacationRequest GetVacationRequestByID(int id)
        {
            return context.VacationRequests.Find(id);
        }

        public void InsertVacationRequest(VacationRequest vacationRequest)
        {
            context.VacationRequests.Add(vacationRequest);
        }

        public void DeleteVacationRequest(int vacationRequestId)
        {
            VacationRequest vacationRequest = context.VacationRequests.Find(vacationRequestId);
            context.VacationRequests.Remove(vacationRequest);
        }

        public void UpdateVacationRequest(VacationRequest vacationRequest)
        {
            context.Entry(vacationRequest).State = EntityState.Modified;
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
