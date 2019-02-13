using System.Collections.Generic;
using Epam.Task7.Users.Entities;

namespace Epam.Task7.Users.BLL.Interface
{
    public interface IAwardLogic
    {
        void AddAward(Awards award);

        void DelAward(int id);

        void UpdAward(Awards award);

        IEnumerable<Awards> GetAll();
    }
}
