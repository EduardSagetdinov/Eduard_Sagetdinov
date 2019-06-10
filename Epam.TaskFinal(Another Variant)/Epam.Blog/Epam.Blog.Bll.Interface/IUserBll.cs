using Epam.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Blog.Bll.Interface
{
    public interface IUserBll
    {
        IEnumerable<Users> SelectAllUsersById(int id);
        IEnumerable<Users> SelectAllUsersByUserName(string userName);
        IEnumerable<Users> GetAllUsers(string orderBy = null, string where = null);
        void NewUser(string username, string password, string email, IEnumerable<int> roles);
        void UpdateUser(int id, string username, string password, string email, IEnumerable<int> roles);
        void DeleteUserByUserName(string username);
        void AddRoles(string username, string password, string email, IEnumerable<int> roles);
    }
}
