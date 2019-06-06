using Epam.Blog.Dal;
using Epam.Blog.Entities;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.WebPages;

namespace Epam.Blog.Bll
{
    public class UserBll
    {
        private readonly UserDal userDal = new UserDal();
        private readonly RoleDal roleDal = new RoleDal();
        private readonly UsersRolesMapDal usersRolesMapDal = new UsersRolesMapDal();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public IEnumerable<Users> SelectAllUsersById(int id)
        {
            logger.Trace("Success");
            return userDal.SelectAllUsersById(id);
        }

        public IEnumerable<Users> SelectAllUsersByUserName(string userName)
        {
            logger.Trace("Success");
            return userDal.SelectAllUsersByUserName(userName);
        }

        public IEnumerable<Users> GetAllUsers(string orderBy = null, string where = null)
        {
            logger.Trace("Success");
            return userDal.GetAllUsers(orderBy, where);
        }

        public void NewUser(string username, string password, string email, IEnumerable<int> roles)
        {
            var user = userDal.SelectAllUsersByUserName(username);
            if (user.Count() != 0)
            {
                logger.Error("User already exists");
                throw new HttpException(409, "User already exists");
            }
            Users newUser = new Users();
            newUser.UserName = username;
            newUser.Password = password;
            newUser.Email = email;
            userDal.NewUser(newUser);
            var someUser = userDal.SelectAllUsersByUserName(username).First();
            RoleForNewUser(someUser.Id, roles);
            logger.Trace("Success");

        }

        public void UpdateUser(int id, string username, string password, string email, IEnumerable<int> roles)
        {
            var user = userDal.SelectAllUsersByUserName(username).First();

            if (user == null)
            {
                logger.Error("User does not exist");
                throw new HttpException(410, "User does not exist");
            }

            var updatedPassword = user.Password;

            if (!string.IsNullOrWhiteSpace(password))
            {
                updatedPassword = Crypto.HashPassword(password);
            }
            usersRolesMapDal.DeleteUsersRolesMapByRoleId(id);

            if (roles.Any())
            {
                foreach (var role in roles)
                {
                    usersRolesMapDal.NewUsersRolesMap(id, role);
                }
            }

            
            userDal.UpdateUser(id, username, password, email);
            logger.Trace("Success");

        }

        public void DeleteUserByUserName(string username)
        {
            userDal.DeleteUserByUserName(username);
            logger.Trace("Success");
        }

        public void AddRoles(string username, string password,
            string email, IEnumerable<int> roles)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                logger.Error("Password cannot be blank");
                throw new HttpException(408, "Password cannot be blank");
            }

            var result = userDal.SelectAllUsersByUserName(username).First();

            if (result != null)
            {
                logger.Error("User is already exists");
                throw new HttpException(409, "User is already exists");
            }

            result = userDal.SelectAllUsersByUserName(username).First();

            foreach (var role in roles)
            {
                usersRolesMapDal.NewUsersRolesMap(result.Id, role);
            }
            logger.Trace("Success");
        }

        private static WebPageRenderingBase Page
        {
            get
            {
                logger.Trace("Success");
                return WebPageContext.Current.Page;
            }
        }

        public string Mode
        {
            get
            {
                if (Page.UrlData.Any())
                {
                    logger.Trace(Page.UrlData[0].ToLower());
                    return Page.UrlData[0].ToLower();
                }
                logger.Trace("Success");
                return string.Empty;
            }
        }

        public string Username
        {
            get
            {
                if (Mode != "new")
                {
                    logger.Trace(Page.UrlData[1]);
                    return Page.UrlData[1];
                }
                logger.Trace("Success");
                return string.Empty;
            }
        }

        public Users Current
        {
            get
            {
                var result = userDal.SelectAllUsersByUserName(Username);
                logger.Trace("Success");
                return result.Count() !=0 ? result.First() : CreateAccountObject();
            }
        }

        private Users CreateAccountObject()
        {
            var obj = new Users();
            obj.Id = 0;
            obj.UserName = string.Empty;
            obj.Password = string.Empty;
            obj.Email = string.Empty;
            logger.Trace("Success");

            return obj;
        }
        private void RoleForNewUser(int userId, IEnumerable<int> roles)
        {
            if (!roles.Any())
            {
                logger.Trace("Success");
                return;
            }

            foreach (var role in roles)
            {
                usersRolesMapDal.NewUsersRolesMap(userId, role);
            }
            logger.Trace("Success");
        }
    }

}
