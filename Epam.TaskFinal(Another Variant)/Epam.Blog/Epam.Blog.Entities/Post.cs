using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace Epam.Blog.Entities
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DatePublished { get; set; }

        public int? AuthorId { get; set; }

        public string Slug { get; set; }

        public List<Tag> tags = new List<Tag>();
    }
}
