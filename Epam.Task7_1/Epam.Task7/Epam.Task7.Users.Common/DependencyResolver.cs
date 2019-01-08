using System.Configuration;
using Epam.Task7.Users.BLL;
using Epam.Task7.Users.BLL.Interface;
using Epam.Task7.Users.DAL;
using Epam.Task7.Users.DAL.Interface;
using Epam.Task7.Users.Entities;

namespace Epam.Task7.Users.Common
{
    public static class DependencyResolver
    {
        private static IUserDao userDao;

        private static IAwardsDao awardsDao;

        private static IUserAwardsDao userAwardsDao;

        private static IUserLogic userLogic;

        private static IAwardLogic awardLogic;

        private static IUserAwardsLogic userAwardsLogic;

        private static ICacheLogic cacheLogic;

        public static IUserLogic UserLogic => userLogic ?? (userLogic = new UserLogic(UserDao, CacheLogic));

        public static IAwardLogic AwardLogic => awardLogic ?? (awardLogic = new AwardLogic(AwardsDao, CacheLogic));

        public static IUserAwardsLogic UserAwardsLogic => userAwardsLogic ?? (userAwardsLogic = new UserAwardsLogic(UserAwardsDao, AwardsDao, CacheLogic));

        public static ICacheLogic CacheLogic => cacheLogic ?? (cacheLogic = new CacheLogic());

        public static IUserDao UserDao
        {
            get
            {
                var key = ConfigurationManager.AppSettings["DaoUsersKey"];
                if (userDao == null)
                {
                    switch (key.ToLower())
                    {
                        case "memory":
                            {
                                userDao = new UserFakeDao();
                                break;
                            }

                        default:
                            break;
                    }
                }

                return userDao;
            }
        }

        public static IAwardsDao AwardsDao
        {
            get
            {
                var key = ConfigurationManager.AppSettings["DaoAwardsKey"];
                if (awardsDao == null)
                {
                    switch (key.ToLower())
                    {
                        case "memory":
                            {
                                awardsDao = new AwardsFakeDao();
                                break;
                            }

                        default:
                            break;
                    }
                }

                return awardsDao;
            }
        }

        public static IUserAwardsDao UserAwardsDao
        {
            get
            {
                var key = ConfigurationManager.AppSettings["DaoUserAwardsKey"];
                if (userAwardsDao == null)
                {
                    switch (key.ToLower())
                    {
                        case "memory":
                            {
                                userAwardsDao = new UserAwardsFakeDao();
                                break;
                            }

                        default:
                            break;
                    }
                }

                return userAwardsDao;
            }
        }
    }
}
