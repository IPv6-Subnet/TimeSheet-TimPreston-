using System;
using System.Collections.Generic;
using ProductionsProductionCompany.Models.ObjectModels;

namespace ProductionsProductionCompany.Data.DAL
{
    public interface IEmployeeRepo : IDisposable
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeByID(string employeeId);
        void InsertEmployee(Employee employee);
        void DeleteEmployee(string employeeId);
        void UpdateEmployee(Employee employee);
        void Save();

    }
}
