using Epam.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Blog.Bll.Interface
{
    public interface IPostBll
    {
        IEnumerable<Post> GetPublishedPosts();
        IEnumerable<forGet> GetPublishedPostsByTag(string urlFriendlyName);
        IEnumerable<Post> GetPostById(int id);
        forGet GetPostBySlug(string slug);
        IEnumerable<Post> GetAllPosts();
        IEnumerable<forGet> SelectAllUserPublishedPostsAndTags();
        void NewPost(string title, string content, string slug, DateTime? datePublished, int authorId, IEnumerable<int> tags);
        void UpdatePost(int id, string title, string content, string slug, DateTime? datePublished, int authorId, IEnumerable<int> tags);
        void DeletePost(string slug);
        forGet Get(int id);
        forGet Get(string slug);
        IEnumerable<forGet> GetAll(string orderBy = null);
    }
}
