using Epam.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Blog.Dal.Interface
{
    public interface IPostDal
    {
        IEnumerable<Post> GetPublishedPosts();
        IEnumerable<forGet> GetPublishedPostsByTag(string urlFriendlyName);
        IEnumerable<Post> GetPostById(int id);
        forGet GetPostBySlug(string slug);
        IEnumerable<Post> GetAllPosts();
        void NewPost(string title, string content, string slug, DateTime? datePublished, int authorId);
        void UpdatePost(int id, string title, string content,
           string slug, DateTime? datePublished, int authorId);
        void DeletePost(int id);
    }
}
