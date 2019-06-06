using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using WebMatrix.Data;
using System.Web.Helpers;
using System.Web.SessionState;
using Epam.Blog.Bll;
using Epam.Blog.Entities;
using Epam.Blog.Dal;
using NLog;

namespace Epam.Blog.Handlers
{
    public class AccountHandler : IHttpHandler, IReadOnlySessionState
    {
        public AccountHandler()
        {
        }
        WebUserBll webUserBll = new WebUserBll();
        UserBll userBll = new UserBll();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public bool IsReusable
        {
            get
            {
                logger.Trace("False");
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            AntiForgery.Validate();

            if (!webUserBll.IsAuthenticated)
            {
                logger.Error("You must login to do this");
                throw new HttpException(401, "You must login to do this.");
            }

            if (!webUserBll.HasRole(UsersRolesMap.Admin))
            {
                logger.Error("You do not have permission to do this");
                throw new HttpException(402, "You do not have permission to do this.");
            }

            var mode = context.Request.Form["mode"];
            var username = context.Request.Form["accountName"];
            var password1 = context.Request.Form["accountPassword1"];
            var password2 = context.Request.Form["accountPassword2"];
            var id = context.Request.Form["accountId"];
            var email = context.Request.Form["accountEmail"];
            var userRoles = context.Request.Form["accountRoles"];
            var resourceItem = context.Request.Form["resourceItem"];
            IEnumerable<int> roles = new int[] { };

            if (!string.IsNullOrEmpty(userRoles))
            {
                roles = userRoles.Split(',').Select(v => Convert.ToInt32(v));
            }

            if (mode == "delete")
            {
                logger.Trace("Delete");
                Delete(username ?? resourceItem);
            }
            else
            {
                if (password1 != password2)
                {
                    logger.Error("Passwords do not match");
                    throw new HttpException(414, "Passwords do not match");
                }
                if (string.IsNullOrWhiteSpace(email))
                {
                    logger.Error("Email cannot be blank");
                    throw new HttpException(415, "Email cannot be blank");
                }
                if (string.IsNullOrWhiteSpace(username))
                {
                    logger.Error("Username cannot be blank");
                    throw new HttpException(416, "Username cannot be blank");
                }
                if (mode == "edit")
                {
                    logger.Trace("Edit");
                    Edit(Convert.ToInt32(id), username, password1, email, roles);
                }
                else if (mode == "new")
                {
                    logger.Trace("Create");
                    Create(username, password1, email, roles);
                }
            }


            if (string.IsNullOrEmpty(resourceItem))
            {
                context.Response.Redirect("~/admin/account/");
            }



        }
        private void Create(string username, string password,
            string email, IEnumerable<int> roles)
        {

            if (string.IsNullOrWhiteSpace(password))
            {
                logger.Error("Password cannot be blank");
                throw new HttpException(417, "Password cannot be blank");
            }

            var result = userBll.SelectAllUsersByUserName(username);

            if (result.Count() != 0)
            {
                logger.Error("User is already exists");
                throw new HttpException(409, "User is already exists");
            }
            Users user = new Users();
            user.UserName = username;
            user.Password = Crypto.HashPassword(password);
            user.Email = email;
            userBll.NewUser(username, Crypto.HashPassword(password), email, roles);
        }

        public void Edit(int id, string username, string password,
            string email, IEnumerable<int> roles)
        {
            var result = userBll.SelectAllUsersByUserName(username).First();

            if (result == null)
            {
                logger.Error("User does not exist");
                throw new HttpException(410, "User does not exist");
            }

            var updatedPassword = result.Password;

            if (!string.IsNullOrWhiteSpace(password))
            {
                updatedPassword = Crypto.HashPassword(password);
            }
            userBll.UpdateUser(id, result.UserName, updatedPassword, email, roles);
            logger.Trace("Success");

        }

        public void Delete(string username)
        {
            userBll.DeleteUserByUserName(username);
            logger.Trace("Success");
        }

        private static string CreateSlug(string title)
        {
            title = title.ToLowerInvariant().Replace(" ", "-");
            title = Regex.Replace(title, @"[^0-9a-z-]", string.Empty);
            logger.Trace("Created slug");
            return title;
        }

    }
}