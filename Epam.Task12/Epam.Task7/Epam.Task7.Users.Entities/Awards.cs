using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Users.Entities
{
    public class Awards
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string photoLink { get; set; } = "https://www.dewir.ru/components/com_jshopping/files/img_products/full_MS_0421.jpg";

        public override string ToString()
        {
            return $"{Id} {Title} {photoLink}"; 
        }
    }
}
