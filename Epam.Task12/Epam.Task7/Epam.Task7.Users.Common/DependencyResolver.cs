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
        private static IUserAdminFakeDao userAdminFakeDao;

        private static IUserLogic userLogic;

        private static IAwardLogic awardLogic;

        private static IUserAwardsLogic userAwardsLogic;

        private static ICacheLogic cacheLogic;
        private static IUserAdminLogic userAdminLogic;

        public static IUserLogic UserLogic => userLogic ?? (userLogic = new UserLogic(UserDao, CacheLogic));

        public static IAwardLogic AwardLogic => awardLogic ?? (awardLogic = new AwardLogic(AwardsDao, CacheLogic));

        public static IUserAwardsLogic UserAwardsLogic => userAwardsLogic ?? (userAwardsLogic = new UserAwardsLogic(UserAwardsDao, AwardsDao, CacheLogic));

        public static ICacheLogic CacheLogic => cacheLogic ?? (cacheLogic = new CacheLogic());

        public static IUserAdminLogic UserAdminLogic => userAdminLogic ?? (userAdminLogic = new UserAdminLogic(UserAdminFakeDao, CacheLogic));

        public static IUserDao UserDao => userDao ?? (userDao = new UserSqlDao());

        public static IUserAdminFakeDao UserAdminFakeDao => userAdminFakeDao ?? (userAdminFakeDao = new UserAdminSqlDao());
        

        public static IAwardsDao AwardsDao => awardsDao ?? (awardsDao = new AwardsSqlDao());
       
        

        public static IUserAwardsDao UserAwardsDao => userAwardsDao ?? (userAwardsDao = new UserAwardsSqlDao());
       
    }
}
