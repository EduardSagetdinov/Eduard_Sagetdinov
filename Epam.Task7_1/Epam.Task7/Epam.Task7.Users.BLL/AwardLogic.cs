using System.Collections.Generic;
using Epam.Task7.Users.BLL.Interface;
using Epam.Task7.Users.DAL.Interface;
using Epam.Task7.Users.Entities;

namespace Epam.Task7.Users.BLL
{
    public class AwardLogic : IAwardLogic
    {
        private const string AllUsersCacheKey = "GetAllAwards";
        private readonly IAwardsDao awardsDao;
        private readonly ICacheLogic cacheLogicAwards;

        public AwardLogic(IAwardsDao awardsDao, ICacheLogic cacheLogic)
        {
            this.awardsDao = awardsDao;
            this.cacheLogicAwards = cacheLogic;
        }

        public void AddAward(Awards award)
        {
            if (award != null)
            {
                this.cacheLogicAwards.Delete(AllUsersCacheKey);
                this.awardsDao.AddAward(award);
            }
        }

        public void DelAward(int id)
        {
            this.awardsDao.DelAward(id);
        }

        public IEnumerable<Awards> GetAll()
        {
            var cacheResult = this.cacheLogicAwards.Get<IEnumerable<Awards>>(AllUsersCacheKey);
            if (cacheResult == null)
            {
                var result = this.awardsDao.GetAll();
                this.cacheLogicAwards.Add(AllUsersCacheKey, this.awardsDao.GetAll());
                return result;
            }

            return cacheResult;
        }

        public void UpdAward(Awards award)
        {
            this.awardsDao.UpdAward(award);
        }
    }
}
