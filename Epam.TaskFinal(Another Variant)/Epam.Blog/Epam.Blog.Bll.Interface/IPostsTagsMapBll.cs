using Epam.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Blog.Bll.Interface
{
    public interface IPostsTagsMapBll
    {
        IEnumerable<PostsTagsMap> GetPostsTagsMap();
        void NewPostsTagsMap(int postId, int tagId);
        void DeletePostsTagsMapByPostId(int postId);
    }
}
