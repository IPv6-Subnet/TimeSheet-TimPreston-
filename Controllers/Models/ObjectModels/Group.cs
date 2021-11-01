using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionsProductionCompany.Models.ObjectModels
{
    /// <summary>
    /// The Group class is responsible for holding information regarding groups that are formed within individual divisions within the company.
    /// </summary>
    public class Group : EntityBase
    {
        public Division Division { get; set; }
        public int DivisionID { get; set; }
        public Employee GroupManager { get; set; }
        public string? GroupManagerId { get; set; }
        public string Title { get; set; }
        public ICollection<Employee> GroupMembers { get; set; }

    }
}
