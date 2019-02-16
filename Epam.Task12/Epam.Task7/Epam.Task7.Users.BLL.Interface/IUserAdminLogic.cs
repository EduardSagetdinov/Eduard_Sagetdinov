using System.Collections.Generic;
using Epam.Task7.Users.Entities;

namespace Epam.Task7.Users.BLL.Interface
{
    public interface IUserAdminLogic
    {
        void AddUserAdmin(UserAdmin userAdmin);

        void DeleteUserAdmin(string login);

        IEnumerable<UserAdmin> GetAll();

        bool UpdateUserAdmin(UserAdmin userAdmin);

        bool IsCorrectPass(string log, string pas);

        bool IsAdminOrUser(string log);
    }
}
