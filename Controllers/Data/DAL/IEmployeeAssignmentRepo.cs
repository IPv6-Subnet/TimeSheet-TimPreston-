using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductionsProductionCompany.Models.ObjectModels;

namespace ProductionsProductionCompany.Data.DAL
{
    public interface IEmployeeAssignmentRepo : IDisposable
    {
        IEnumerable<EmployeeAssignment> GetEmployeeAssignments();
        EmployeeAssignment GetEmployeeAssignmentByID(int employeeAssignmentId);
        void InsertEmployeeAssignment(EmployeeAssignment employeeAssignment);
        void DeleteEmployeeAssignment(int employeeAssignmentId);
        void UpdateEmployeeAssignment(EmployeeAssignment employeeAssignment);
        void Save();
    }
}
