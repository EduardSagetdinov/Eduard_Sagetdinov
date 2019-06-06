using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.Blog.Entities
{
    public class Tag
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UrlFriendlyName { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {UrlFriendlyName}";
        }
    }
}