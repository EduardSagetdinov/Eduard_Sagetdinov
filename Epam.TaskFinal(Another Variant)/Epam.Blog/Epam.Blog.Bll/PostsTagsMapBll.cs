using Epam.Blog.Dal;
using Epam.Blog.Entities;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.Blog.Bll
{
    public class PostsTagsMapBll
    {
        private readonly PostsTagsMapDal postsTagsMapDal = new PostsTagsMapDal();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public IEnumerable<PostsTagsMap> GetPostsTagsMap()
        {
            logger.Trace("Success");

            return postsTagsMapDal.GetPostsTagsMap();
        }

        public void NewPostsTagsMap(int postId, int tagId)
        {
            logger.Trace("Success");

            postsTagsMapDal.NewPostsTagsMap(postId, tagId);
        }

        public void DeletePostsTagsMapByPostId(int postId)
        {
            logger.Trace("Success");

            postsTagsMapDal.DeletePostsTagsMapByPostId(postId);
        }


    }
}