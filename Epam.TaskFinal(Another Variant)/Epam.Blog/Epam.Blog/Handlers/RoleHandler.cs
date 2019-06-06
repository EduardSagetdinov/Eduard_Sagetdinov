using Epam.Blog.Bll;
using Epam.Blog.Entities;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.SessionState;

namespace Epam.Blog.Handlers
{
    public class RoleHandler : IHttpHandler, IReadOnlySessionState
    {
        public RoleHandler()
        {
        }

        WebUserBll webUserBll = new WebUserBll();
        UsersRolesMap usersRolesMap = new UsersRolesMap();
        RoleBll roleBll = new RoleBll();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public bool IsReusable
        {
            get
            {
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
            var name = context.Request.Form["roleName"];
            var id = context.Request.Form["roleId"];
            var resourceItem = context.Request.Form["resourceItem"];

            if (mode == "edit")
            {
                Edit(Convert.ToInt32(id), name);
                logger.Trace("Success");
            }
            else if (mode == "new")
            {
                Create(name);
                logger.Trace("Success");
            }
            else if (mode == "delete")
            {
                Delete(name ?? resourceItem);
                logger.Trace("Success");
            }

            if (string.IsNullOrEmpty(resourceItem))
            {
                context.Response.Redirect("~/admin/role/");
                logger.Trace("Success");

            }



        }
        private void Create(string name)
        {
            var result = roleBll.GetRoleByName(name);
            if (result.Count() != 0)
            {
                logger.Error("Role is already in use");
                throw new HttpException(411, "Role is already in use");
            }
            logger.Trace("Success");
            roleBll.AddNewRole(name);
        }

        private void Edit(int id, string name)
        {
            var result = roleBll.GetRoleById(id).First();
            if (result == null)
            {
                logger.Error("Role does not exist");
                throw new HttpException(412, "Role does not exist");
            }
            roleBll.UpdateRole(id, name);
            logger.Trace("Success");
        }

        private void Delete(string name)
        {
            roleBll.DeleteRole(name);
            logger.Trace("Success");
        }

    }
}