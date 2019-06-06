using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.Blog.Entities
{
    public class UsersRolesMap
    {
        public const string Admin = "admin";

        public const string Editor = "editor";

        public const string Author = "author";

        public int Id { get; set; }

        public int UserId { get; set; }

        public int RoleId { get; set; }

    }
}