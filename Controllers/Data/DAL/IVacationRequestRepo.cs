using System;
using System.Collections.Generic;
using ProductionsProductionCompany.Models.ObjectModels;

namespace ProductionsProductionCompany.Data.DAL
{
    interface IVacationRequestRepo : IDisposable
    {
        IEnumerable<VacationRequest> GetVacationRequests();
        VacationRequest GetVacationRequestByID(int vacationRequestId);
        void InsertVacationRequest(VacationRequest vacationRequest);
        void DeleteVacationRequest(int vacationRequestId);
        void UpdateVacationRequest(VacationRequest vacationRequest);
        void Save();
    }
}
