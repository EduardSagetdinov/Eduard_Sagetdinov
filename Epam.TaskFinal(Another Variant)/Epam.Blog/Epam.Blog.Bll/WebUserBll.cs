using Epam.Blog.Bll.Interface;
using Epam.Blog.Dal;
using Epam.Blog.Entities;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.SessionState;

namespace Epam.Blog.Bll
{
    public class WebUserBll: IWebUserBll
    {
        UserDal userDal = new UserDal();
        RoleDal roleDal = new RoleDal();
        RoleBll roleBll = new RoleBll();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private static HttpSessionState Session
        {
            get
            {
                logger.Trace("Success");
                return HttpContext.Current.Session;
            }
        }


        public bool HasRole(string roleName)
        {
            var roles = GetRolesForUser();
            logger.Trace("Success");

            return roles.Contains(roleName);
        }

        public IEnumerable<string> GetRolesForUser()
        {
            logger.Trace("Success");

            return GetRolesForUser(UserId);
        }

        public IEnumerable<string> GetRolesForUser(int id)
        {
            logger.Trace("Success");

            return roleBll.GetRolesForUser(id);
        }

        public bool Authenticate(string username, string password)
        {
            var user = userDal.SelectAllUsersByUserName(username).First();

            if (user == null)
            {
                logger.Warn("User == null");

                return false;
            }
            logger.Trace("Success");

            return Crypto.VerifyHashedPassword((string)user.Password, password);
        }

        public void Login(string username)
        {
            var user = userDal.SelectAllUsersByUserName(username);

            if (user == null)
            {
                logger.Warn("user == null");

                return;
            }
            logger.Trace("Success");

            SetupSession(user.First());
        }

        public bool AuthenticateAndLogin(string username, string password)
        {
            username = username.ToLowerInvariant().Trim();
            var user = userDal.SelectAllUsersByUserName(username); 

            if (user.Count() == 0)
            {
                logger.Warn("user.Count() == 0");

                return false;
            }

            var verified = Crypto.VerifyHashedPassword(user.First().Password, password);

            if (!verified)
            {
                logger.Warn("Not verified");

                return false;
            }

            SetupSession(user.First());
            logger.Trace("Success");

            return true;

        }

        private static void SetupSession(Users user)
        {


            Session["userid"] = user.Id;
            Session["username"] = user.UserName;
            Session["email"] = user.Email;
            logger.Trace("Success");

        }

        public static int UserId
        {
            get
            {
                var value = Session["userid"];

                if (value == null)
                {
                    logger.Trace("value == null");

                    return -1;
                }
                logger.Trace("Success");

                return (int)value;
            }
        }

        public static string Username
        {
            get
            {
                var value = Session["username"];

                if (value == null)
                {
                    logger.Warn("value == null");

                    return string.Empty;
                }
                logger.Trace("Success");

                return (string)value;
            }
        }

        public static string Email
        {
            get
            {
                var value = Session["email"];

                if (value == null)
                {
                    logger.Warn("value == null");

                    return string.Empty;
                }
                logger.Trace("Success");

                return (string)value;
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                logger.Trace(!string.IsNullOrEmpty(Username));

                return !string.IsNullOrEmpty(Username);
            }
        }
    }
}
