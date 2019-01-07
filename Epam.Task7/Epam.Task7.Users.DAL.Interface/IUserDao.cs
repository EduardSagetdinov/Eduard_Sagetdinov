using System.Collections.Generic;
using Epam.Task7.Users.Entities;

namespace Epam.Task7.Users.DAL
{
    public interface IUserDao
    {
        void AddUser(User user);

        void DeleteUser(int id);

        IEnumerable<User> GetAll();

        bool UpdateUser(User user);
    }
}