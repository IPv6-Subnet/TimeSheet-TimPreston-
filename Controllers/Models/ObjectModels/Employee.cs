using System;
using Microsoft.AspNetCore.Identity;

namespace ProductionsProductionCompany.Models.ObjectModels
{
    /// <summary>
    /// Employee class is responsible for holding the properties that are relevant to an employee
    /// </summary>
    public class Employee : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }
        [PersonalData]
        public double HourlyWage { get; set; }
        [PersonalData]
        public string Phone { get; set; }
        [PersonalData]
        public string Street { get; set; }
        [PersonalData]
        public string City { get; set; }
        [PersonalData]
        public string State { get; set; }
        [PersonalData]
        public string ZipCode { get; set; }
        [PersonalData]
        public DateTime HireDate { get; set; }
    }
}
