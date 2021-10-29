using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionsProductionCompany.Models.ObjectModels
{
    /// <summary>
    /// Payroll class is responsible for holding the hours worked in a given pay period of an employee. It is to be approved by the Division manager for that employee.
    /// </summary>
    public class Payroll : EntityBase
    {
        public int Hours { get; set; }
        public double PeriodEarnings { get; set; }
        public PayPeriod PayPeriod { get; set; }
        public int PayPeriodID { get; set; }
        public Employee Employee { get; set; }
        public string EmployeeId { get; set; }
        public bool Approved { get; set; }
        public ICollection<TimeClock> TimeClocks { get; set; }
    }
}
