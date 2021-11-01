using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionsProductionCompany.Models.ObjectModels
{
    /// <summary>
    /// Division class is responsible for the information regarding a division within the company.
    /// </summary>
    public class Division : EntityBase
    {
        public Employee DivisionManager { get; set; }
        public string DivisionManagerId { get; set; }
        public string Title { get; set; }
        public double Budget { get; set; }
        public ICollection<Employee> DivisionMembers { get; set; }

    }
}
