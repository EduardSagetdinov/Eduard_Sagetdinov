using Epam.Blog.Bll;
using Epam.Blog.Dal;
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
    public class PostHandler : IHttpHandler, IReadOnlySessionState
    {
        public PostHandler()
        {
        }

        WebUserBll webUserBll = new WebUserBll();
        PostBll postBll = new PostBll();
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

            if (!webUserBll.HasRole(UsersRolesMap.Admin) && !webUserBll.HasRole(UsersRolesMap.Editor) &&
    !webUserBll.HasRole(UsersRolesMap.Author))
            {
                logger.Error("You do not have permission to do this");
                throw new HttpException(402, "You do not have permission to do this.");
            }




            var mode = context.Request.Form["mode"];
            var title = context.Request.Form["postTitle"];
            var content = context.Request.Form["postContent"];
            var slug = context.Request.Form["postSlug"] ?? context.Request.Form["postTitle"];
            var datePublished = context.Request.Form["postDatePublished"];
            var id = context.Request.Form["postId"];
            var postTags = context.Request.Form["postTags"];
            var authorId = context.Request.Form["postAuthorId"];
            var resourceItem = context.Request.Form["resourceItem"];

            IEnumerable<int> tags = new int[] { };

            if (!string.IsNullOrEmpty(postTags))
            {
                tags = postTags.Split(',').Select(v => Convert.ToInt32(v));
            }

            if ((mode == "edit" || mode == "delete") && webUserBll.HasRole(UsersRolesMap.Author))
            {
                if (WebUserBll.UserId != Convert.ToInt32(authorId))
                {
                    logger.Error("You do not have permission to do this");
                    throw new HttpException(402, "You do not have permission to do this.");
                }
            }

            if (mode == "delete")
            {
                logger.Trace("Success");
                DeletePost(slug ?? resourceItem);
            }
            else
            {
                if (string.IsNullOrEmpty(slug))
                {
                    logger.Trace("Success");
                    slug = CreateSlug(title);
                }
                if (mode == "edit")
                {
                    logger.Trace("Success");
                    EditPost(Convert.ToInt32(id), title, content, slug, datePublished, Convert.ToInt32(authorId), tags);
                }
                else if (mode == "new")
                {
                    logger.Trace("Success");
                    CreatePost(title, content, slug, datePublished, WebUserBll.UserId, tags);
                }

            }

            if (string.IsNullOrEmpty(resourceItem))
            {
                logger.Trace("Success");
                context.Response.Redirect("~/Admin/Post/");
            }

        }
        private void CreatePost(string title, string content,
            string slug, string datePublished, int authorId, IEnumerable<int> tags)
        {
            var result = postBll.Get(slug);
            DateTime? published = null;
            if (result != null)
            {
                logger.Error("Slug is already in use");
                throw new HttpException(413, "Slug is already in use");
            }
            if (!string.IsNullOrWhiteSpace(datePublished))
            {
                published = DateTime.Parse(datePublished);
            }
            else
            {
                published = null;
            }
            postBll.NewPost(title, content, slug, published, authorId, tags);
            logger.Trace("Success");

        }

        private void EditPost(int id, string title, string content,
           string slug, string datePublished, int authorId, IEnumerable<int> tags)
        {
            var result = postBll.Get(id);
            DateTime? published = null;
            if (result == null)
            {
                logger.Error("Post does not exist");
                throw new HttpException(407, "Post does not exist");
            }
            if (!string.IsNullOrWhiteSpace(datePublished))
            {
                published = DateTime.Parse(datePublished);
            }
            postBll.UpdatePost(id, title, content, slug, published, authorId, tags);
            logger.Trace("Success");
        }

        private void DeletePost(string slug)
        {
            postBll.DeletePost(slug);
            logger.Trace("Success");
        }

        private static string CreateSlug(string title)
        {
            title = title.ToLowerInvariant().Replace(" ", "-");
            title = Regex.Replace(title, @"[^0-9a-z-]", string.Empty);
            logger.Trace("Success");
            return title;
        }
    }
}