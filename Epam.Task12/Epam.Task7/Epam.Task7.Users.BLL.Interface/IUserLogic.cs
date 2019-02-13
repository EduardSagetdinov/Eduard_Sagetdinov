using System.Collections.Generic;
using Epam.Task7.Users.Entities;

namespace Epam.Task7.Users.BLL.Interface
{
    public interface IUserLogic
    {
        void AddUser(User user);

        void DeleteUser(int id);

        void UpdateUser(User user);

        IEnumerable<User> GetAll();
    }
}
