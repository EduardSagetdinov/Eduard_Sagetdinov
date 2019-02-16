using System.Collections.Generic;
using Epam.Task7.Users.Entities;

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
