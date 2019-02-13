using Epam.Task7.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Users.BLL.Interface
{
    public interface IUserAdminLogic
    {
        void AddUserAdmin(UserAdmin userAdmin);

        void DeleteUserAdmin(string login);

        IEnumerable<UserAdmin> GetAll();

        bool UpdateUserAdmin(UserAdmin userAdmin);
        bool isCorrectPass(string log, string pas);
        bool isAdminOrUser(string log);
    }
}
