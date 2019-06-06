using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.Blog.Entities
{
    public class PostsTagsMap
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public int TagId { get; set; }

        public override string ToString()
        {
            return $"{Id} {PostId} {TagId}";
        }
    }
}