using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Blog.Bll.Interface
{
    public interface IUsersRolesMapBll
    {
        void NewUsersRolesMap(int userId, int roleId);
        void DeleteUsersRolesMap(int userId);
        void DeleteUsersRolesMapByRoleId(int roleId);
    }
}
