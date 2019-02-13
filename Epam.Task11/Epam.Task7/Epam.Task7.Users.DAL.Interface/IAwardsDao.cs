using System.Collections.Generic;
using Epam.Task7.Users.Entities;

namespace Epam.Task7.Users.DAL.Interface
{
    public interface IAwardsDao
    {
        void AddAward(Awards award);

        void DelAward(int id);

        bool UpdAward(Awards award);

        IEnumerable<Awards> GetAll();
    }
}
