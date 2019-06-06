using Epam.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Blog.Dal.Interface
{
    public interface IRoleDal
    {
        IEnumerable<Role> GetRoleById(int id);
        IEnumerable<Role> GetRoleByName(string name);
        IEnumerable<Role> GetRolesForUser(int id);
        IEnumerable<Role> GetAllRole();
        void AddNewRole(string name);
        void UpdateRole(int id, string name);
        void DeleteRoleById(int id);
        void DeleteRoleByName(string name);
    }
}
