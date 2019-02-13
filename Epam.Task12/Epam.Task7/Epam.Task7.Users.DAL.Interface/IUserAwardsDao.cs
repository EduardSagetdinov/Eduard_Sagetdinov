using System.Collections.Generic;
using Epam.Task7.Users.Entities;

namespace Epam.Task7.Users.DAL.Interface
{
    public interface IUserAwardsDao
    {
        void AddUserAward(UsersAwards userAward);

        void DelUserAward(int idUser, int idAward);

        bool UpdUserAward(UsersAwards userAward);

        IEnumerable<UsersAwards> GetAllUserAward();
    }
}
