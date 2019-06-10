using Epam.Blog.Bll.Interface;
using Epam.Blog.Dal;
using Epam.Blog.Entities;
using NLog;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace Epam.Blog.Bll
{
    public class PostBll: IPostBll
    {
        private readonly PostDal postDal = new PostDal();
        private readonly TagDal tagDal = new TagDal();
        private readonly PostsTagsMapDal postsTagsMapDal = new PostsTagsMapDal();
        private readonly UserDal userDal = new UserDal();
        private static Logger logger = LogManager.GetCurrentClassLogger();


        public IEnumerable<Post> GetPublishedPosts()
        {
            logger.Trace("Success");

            return postDal.GetPublishedPosts();
        }

        public IEnumerable<forGet> GetPublishedPostsByTag(string urlFriendlyName)
        {
            logger.Trace("Success");
            return postDal.GetPublishedPostsByTag(urlFriendlyName);
        }

        public IEnumerable<Post> GetPostById(int id)
        {
            logger.Trace("Success");
            return postDal.GetPostById(id);
        }

        public forGet GetPostBySlug(string slug)
        {
            logger.Trace("Success");
            return postDal.GetPostBySlug(slug);
        }

        public IEnumerable<Post> GetAllPosts()
        {
            logger.Trace("Success");
            return postDal.GetAllPosts();
        }

        public IEnumerable<forGet> SelectAllUserPublishedPostsAndTags()
        {
            
            IEnumerable<forGet> results = from p in postDal.GetPublishedPosts()
                                        join pM in postsTagsMapDal.GetPostsTagsMap()
                                        on p.Id equals pM.PostId
                                        join t in tagDal.GetAllTags() on
                                        pM.TagId equals t.Id
                                        join u in userDal.GetAllUsers() on
                                        p.AuthorId equals u.Id
                                        select new forGet {post = p, tag = t, user = u};
            foreach (var p in results)
            {
                p.post.tags.Add(p.tag);
            }
            logger.Trace("Success");
            return results;
        }

        public void NewPost(string title, string content, string slug, DateTime? datePublished, int authorId, IEnumerable<int> tags)
        {
            if (!datePublished.HasValue)
            {
                datePublished = null;
            }
            postDal.NewPost(title, content, slug, datePublished, authorId);
            var post = postDal.PostBySlug(slug);
            AddTags(tags, post.First());
            logger.Trace("Success");
        }

        private void AddTags(IEnumerable<int> tags, Post post)
        {
            if (tags.Any())
            {
                foreach (var tag in tags)
                {
                    postsTagsMapDal.NewPostsTagsMap(post.Id, tag);
                }
            }
            logger.Trace("Success");
        }

        public void UpdatePost(int id, string title, string content,
           string slug, DateTime? datePublished, int authorId, IEnumerable<int> tags)
        {
            postDal.UpdatePost(id, title, content, slug, datePublished, authorId);

            postsTagsMapDal.DeletePostsTagsMapByPostId(id);

            foreach (var tag in tags)
            {
                postsTagsMapDal.NewPostsTagsMap(id, tag);
            }
            logger.Trace("Success");
        }

        public void DeletePost(string slug)
        {
            var post = postDal.PostBySlug(slug);
            if (post.Count() != 0)
            {
                postsTagsMapDal.DeletePostsTagsMapByPostId(post.First().Id);
                postDal.DeletePost(post.First().Id);
            }
            logger.Trace("Success");
        }

        public forGet Get(int id)
        {
            logger.Trace("Success");
            return postDal.Get(id);
        }

        public forGet Get(string slug)
        {
            logger.Trace("Success");
            return postDal.Get(slug);
        }

        private WebPageRenderingBase Page
        {
            get
            {
                logger.Trace("Success");
                return WebPageContext.Current.Page;
            }
        }
        public string Slug
        {
            get
            {
                if (Mode != "new")
                {
                    logger.Trace("Success");
                    return Page.UrlData[1];
                }
                logger.Trace("Success");
                return string.Empty;
            }
        }

        public string Mode
        {
            get
            {
                if (Page.UrlData.Any())
                {
                    logger.Trace("Success");
                    return Page.UrlData[0].ToLower();
                }
                logger.Trace("Success");
                return string.Empty;
            }
        }

        public string FriendlyName
        {
            get
            {
                if (Mode != "new")
                {
                    logger.Trace("Success");
                    return Page.UrlData[1];
                }
                logger.Trace("Success");
                return string.Empty;
            }
        }

        public forGet Current
        {
            get
            {

                var result = postDal.Get(Slug);

                if (result != null)
                {
                    logger.Trace("Success");
                    return result;
                }
                forGet another = new forGet();
                another.post = CreatePostObject();
                another.tag = CreateTagObject();
                another.user = CreateUserObject();
                logger.Trace("Success");
                return another;


            }
        }

        public IEnumerable<forGet> GetAll(string orderBy = null)
        {
            logger.Trace("Success");
            return postDal.GetAll(orderBy);
        }

        private static Post CreatePostObject()
        {
            Post obj = new Post();
            obj.Id = 0;
            obj.Title = string.Empty;
            obj.Content = string.Empty;
            obj.DateCreated = null;
            obj.DatePublished = null;
            obj.Slug = string.Empty;
            obj.AuthorId = null;
            obj.tags = new List<Tag>();
            logger.Trace("Success");
            return obj;
        }
        private static Tag CreateTagObject()
        {
            Tag obj = new Tag();
            obj.Id = 0;
            obj.Name = string.Empty;
            obj.UrlFriendlyName = string.Empty;
            logger.Trace("Success");
            return obj;
        }

        private static Users CreateUserObject()
        {
            Users obj = new Users();
            obj.Id = 0;
            obj.UserName = string.Empty;
            obj.Email = string.Empty;
            obj.Password = string.Empty;
            logger.Trace("Success");
            return obj;
        }

        public static forGet CreateNewObject(forGet obj)
        {
            forGet newObj = new forGet();
            newObj.post.Id = obj.post.Id;
            newObj.post.Title = obj.post.Title;
            newObj.post.Content = obj.post.Content;
            newObj.post.DateCreated = obj.post.DateCreated;
            newObj.post.DatePublished = obj.post.DatePublished;
            newObj.post.Slug = obj.post.Slug;
            newObj.post.AuthorId = obj.post.AuthorId;
            newObj.tag = obj.tag;
            newObj.user.UserName = obj.user.UserName;
            logger.Trace("Success");
            return obj;
        }

    }
}
