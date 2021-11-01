using System;
using System.Collections.Generic;
using ProductionsProductionCompany.Models.ObjectModels;

namespace ProductionsProductionCompany.Data.DAL
{
    interface IGroupRepo : IDisposable
    {
        IEnumerable<Group> GetGroups();
        Group GetGroupByID(int groupId);
        void InsertGroup(Group group);
        void DeleteGroup(int groupId);
        void UpdateGroup(Group group);
        void Save();
    }
}
