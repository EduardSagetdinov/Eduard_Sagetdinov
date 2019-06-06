using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.Blog.Entities
{
    public class Users
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public override string ToString()
        {
            return $"{Id} {UserName} {Password} {Email}";
        }
    }
}