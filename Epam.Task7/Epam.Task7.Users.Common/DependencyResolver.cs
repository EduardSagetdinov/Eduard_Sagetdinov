using System.Configuration;
using Epam.Task7.Users.BLL;
using Epam.Task7.Users.BLL.Interface;
using Epam.Task7.Users.DAL;

namespace Epam.Task7.Users.Common
{
    public static class DependencyResolver
    {
        private static IUserDao userDao;

        private static IUserLogic userLogic;

        private static ICacheLogic cacheLogic;

        public static IUserLogic UserLogic => userLogic ?? (userLogic = new UserLogic(UserDao, CacheLogic));

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
    }
}
