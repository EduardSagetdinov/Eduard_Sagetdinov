using Epam.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Blog.Dal.Interface
{
    public interface IUserDal
    {
        IEnumerable<Users> SelectAllUsersById(int id);
        IEnumerable<Users> SelectAllUsersByUserName(string userName);
        IEnumerable<Users> GetAllUsers(string orderBy = null, string where = null);
        void NewUser(Users user);
        void UpdateUser(Users user);
        void DeleteUserByUserName(string username);
    }
}
