using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductionsProductionCompany.Models.ObjectModels;

namespace ProductionsProductionCompany.Data.DAL
{
    interface IPayrollRepo : IDisposable
    {
        IEnumerable<Payroll> GetPayrolls();
        Payroll GetPayrollByID(int payrollId);
        void InsertPayroll(Payroll payroll);
        void DeletePayroll(int payrollId);
        void UpdatePayroll(Payroll payroll);
        void Save();
    }
}
