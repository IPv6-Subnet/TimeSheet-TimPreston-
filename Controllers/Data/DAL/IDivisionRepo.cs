using System;
using System.Collections.Generic;
using ProductionsProductionCompany.Models.ObjectModels;

namespace ProductionsProductionCompany.Data.DAL
{
    public interface IDivisionRepo : IDisposable
    {
        IEnumerable<Division> GetDivisions();
        Division GetDivisionByID(int divisionId);
        void InsertDivision(Division division);
        void DeleteDivision(int divisionId);
        void UpdateDivision(Division division);
        void Save();
    }
}
