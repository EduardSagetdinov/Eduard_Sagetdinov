using Epam.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Blog.Dal.Interface
{
    public interface IUsersRolesMapDal
    {
        void NewUsersRolesMap(int userId, int roleId);
        void DeleteUsersRolesMap(int userId);
        void DeleteUsersRolesMapByRoleId(int roleId);
    }
}
