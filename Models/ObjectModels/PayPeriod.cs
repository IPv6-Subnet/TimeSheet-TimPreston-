using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionsProductionCompany.Models.ObjectModels
{
    /// <summary>
    /// PayPeriod class is responsible for holding the starting and ending date for the specific pay period
    /// </summary>
    public class PayPeriod : EntityBase
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
