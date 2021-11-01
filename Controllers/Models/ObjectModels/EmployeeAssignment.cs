using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionsProductionCompany.Models.ObjectModels
{
    /// <summary>
    /// EmployeeAssignment class is responsible for holding the division and group(optional) assignments of an employee
    /// </summary>
    public class EmployeeAssignment : EntityBase
    {
        public Employee Employee { get; set; }
        public string EmployeeId { get; set; }
        public Division Division { get; set; }
        public int DivisionID { get; set; }
        public Group Group { get; set; }
        public int? GroupID { get; set; }
    }
}
