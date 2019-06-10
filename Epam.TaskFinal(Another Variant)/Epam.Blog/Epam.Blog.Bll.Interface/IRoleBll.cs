using Epam.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Blog.Bll.Interface
{
    public interface IRoleBll
    {
        IEnumerable<Role> GetRoleById(int id);
        IEnumerable<Role> GetRoleByName(string name);
        IEnumerable<string> GetRolesForUser(int id);
        IEnumerable<Role> GetAllRole();
        void AddNewRole(string name);
        void UpdateRole(int id, string name);
        void DeleteRole(string roleName);

    }
}
