using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionsProductionCompany.Models.ObjectModels
{
    /// <summary>
    /// TimeClock class is responsible for storing the clockin and clockout times of an employee on a given day
    /// </summary>
    public class TimeClock : EntityBase
    {
        public DateTime ClockInTime { get; set; }
        public DateTime? ClockOutTime { get; set; }
        public DateTime Date { get; set; }
        public Employee Employee { get; set; }
        public string EmployeeId { get; set; }
    }
}
