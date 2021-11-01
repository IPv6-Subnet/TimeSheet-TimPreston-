using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionsProductionCompany.Models.ObjectModels
{
    /// <summary>
    /// VacationRequest class is responsible for storing the information regarding a request for vacation time by an employee
    /// </summary>
    public class VacationRequest : EntityBase
    {
        public Employee Employee { get; set; }
        public string EmployeeId { get; set; }
        public bool Approved { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
