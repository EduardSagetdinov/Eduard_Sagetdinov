using Epam.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Blog.Dal.Interface
{
    public interface IPostsTagsMapDal
    {
        void NewPostsTagsMap(int postId, int tagId);
        void DeletePostsTagsMapByPostId(int postId);

    }
}
