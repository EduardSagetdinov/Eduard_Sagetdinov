using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.Blog.Entities
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}