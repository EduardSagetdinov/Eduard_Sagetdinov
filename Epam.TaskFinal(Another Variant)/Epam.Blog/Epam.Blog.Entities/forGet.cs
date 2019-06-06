using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Blog.Entities
{
    public class forGet
    {
        public Post post { get; set; }
         public Tag tag { get; set; }
         public Users user { get; set; }

         public override string ToString()
         {
             return $"{user} {tag} {user}"; 
         }
    }

}
