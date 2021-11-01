using System;
using System.Collections.Generic;
using ProductionsProductionCompany.Models.ObjectModels;

namespace ProductionsProductionCompany.Data.DAL
{
    interface ITimeClockRepo : IDisposable
    {
        IEnumerable<TimeClock> GetTimeClocks();
        TimeClock GetTimeClockByID(int timeClockId);
        void InsertTimeClock(TimeClock timeClock);
        void DeleteTimeClock(int timeClockId);
        void UpdateTimeClock(TimeClock timeClock);
        void Save();
    }
}
