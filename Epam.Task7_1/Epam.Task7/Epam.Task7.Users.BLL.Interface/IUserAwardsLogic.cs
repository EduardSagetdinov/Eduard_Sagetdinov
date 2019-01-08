using System.Collections.Generic;
using Epam.Task7.Users.Entities;

namespace Epam.Task7.Users.BLL.Interface
{
    public interface IUserAwardsLogic
    {
        void AddUserAward(UsersAwards userAward);

        void DelUserAward(int idUser, int idAward);

        void UpdUserAward(UsersAwards userAward);

        IEnumerable<UsersAwards> GetAllUserAward();

        IEnumerable<string> GetAwardsOfUser(User user);
    }
}
