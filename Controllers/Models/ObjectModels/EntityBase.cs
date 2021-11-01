using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionsProductionCompany.Models.ObjectModels
{
    /// <summary>
    /// EntityBase is the base class for each entity within the application. The common field(s) are held here.
    /// </summary>
    public class EntityBase
    {
        public int Id { get; set; }
        
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
