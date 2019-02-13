using Epam.Task7.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Users.DAL.Interface
{
    public interface IUserAdminFakeDao
    {
        void AddUserAdmin(UserAdmin userAdmin);

        void DeleteUserAdmin(string login);

        IEnumerable<UserAdmin> GetAll();

        bool UpdateUserAdmin(UserAdmin userAdmin);
    }
}
