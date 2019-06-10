using Epam.Blog.Bll.Interface;
using Epam.Blog.Dal;
using Epam.Blog.Entities;
using NLog;

namespace Epam.Blog.Bll
{
    public class UsersRolesMapBll: IUsersRolesMapBll
    {
        private readonly UsersRolesMapDal usersRolesMapDal = new UsersRolesMapDal();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void NewUsersRolesMap(int userId, int roleId)
        {
            logger.Trace("Success");

            usersRolesMapDal.NewUsersRolesMap(userId, roleId);
        }

        public void DeleteUsersRolesMap(int userId)
        {
            logger.Trace("Success");

            usersRolesMapDal.DeleteUsersRolesMap(userId);
        }

        public void DeleteUsersRolesMapByRoleId(int roleId)
        {
            logger.Trace("Success");

            usersRolesMapDal.DeleteUsersRolesMapByRoleId(roleId);
        }
    }
}