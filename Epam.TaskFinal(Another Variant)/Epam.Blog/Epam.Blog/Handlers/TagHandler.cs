using Epam.Blog.Bll;
using Epam.Blog.Entities;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Helpers;
using System.Web.SessionState;

namespace Epam.Blog.Handlers
{
    public class TagHandler : IHttpHandler, IReadOnlySessionState
    {
        public TagHandler()
        {
        }

        WebUserBll webUserBll = new WebUserBll();
        TagBll tagBll = new TagBll();
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
                throw new HttpException(403, "You must login to do this.");
            }

            if (!webUserBll.HasRole(UsersRolesMap.Admin) && !webUserBll.HasRole(UsersRolesMap.Editor))
            {
                logger.Error("You do not have permission to do this");
                throw new HttpException(402, "You do not have permission to do this.");
            }

            var mode = context.Request.Form["mode"];
            var name = context.Request.Form["tagName"];
            var friendlyName = context.Request.Form["tagFriendlyName"];
            var id = context.Request.Form["tagId"];
            var resourceItem = context.Request.Form["resourceItem"];
            var message = String.Empty;
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(friendlyName))
            {
                logger.Error("New tag musn't be empty");
                throw new HttpException(405, "New tag musn't be empty.");
            }
            if (mode == "delete")
            {
                DeleteTag(friendlyName ?? resourceItem);
                logger.Trace("Success");
            }
            else
            {
                if (string.IsNullOrWhiteSpace(friendlyName))
                {
                    friendlyName = CreateTag(name);
                    logger.Trace("Success");
                }

                if (mode == "edit")
                {
                    EditTag(Convert.ToInt32(id), name, friendlyName);
                    logger.Trace("Success");
                }
                else if (mode == "new")
                {
                    CreateTag(name, friendlyName);
                    logger.Trace("Success");
                }
            }

            if (string.IsNullOrEmpty(resourceItem))
            {
                context.Response.Redirect("~/Admin/Tag/");
                logger.Trace("Success");
            }

        }
        private void CreateTag(string name, string friendlyName)
        {
            var result = tagBll.SelectAllFromTagByUrlFriendlyName(friendlyName);
            if (result.Count() != 0)
            {
                logger.Error("Tag is already in use");
                throw new HttpException(406, "Tag is already in use");
            }
            tagBll.NewTag(name, friendlyName);
            logger.Trace("Success");
        }

        private void EditTag(int id, string name, string friendlyName)
        {
            var result = tagBll.SelectAllFromTagById(id);
            if (result == null)
            {
                logger.Error("Post does not exist");
                throw new HttpException(407, "Post does not exist");
            }
            tagBll.UpdateTag(id, name, friendlyName);
            logger.Trace("Success");
        }

        private void DeleteTag(string friendlyName)
        {
            tagBll.DeleteTagByUrlFriendlyName(friendlyName);
            logger.Trace("Success");
        }

        private static string CreateTag(string name)
        {
            name = name.ToLowerInvariant().Replace(" ", "-");
            name = Regex.Replace(name, @"[^0-9a-z-]", string.Empty);
            logger.Trace("Success");
            return name;
        }
    }
}