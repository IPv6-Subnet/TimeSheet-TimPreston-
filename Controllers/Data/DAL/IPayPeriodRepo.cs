using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductionsProductionCompany.Models.ObjectModels;

namespace ProductionsProductionCompany.Data.DAL
{
    interface IPayPeriodRepo : IDisposable
    {
        IEnumerable<PayPeriod> GetPayPeriods();
        PayPeriod GetPayPeriodByID(int payPeriodId);
        void InsertPayPeriod(PayPeriod payPeriod);
        void DeletePayPeriod(int payPeriodId);
        void UpdatePayPeriod(PayPeriod payPeriod);
        void Save();
    }
}
