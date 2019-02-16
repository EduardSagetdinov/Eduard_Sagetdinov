using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Epam.Task7.Users.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PhotoUserLink { get; set; } = @"https://www.meme-arsenal.com/memes/83830fd17734cb4c59b3beefc0fd24f1.jpg";

        public override string ToString()
        {
            return $"{Id} {Name} {DateOfBirth:dd/MM/yyyy} {DateTime.Now.Year - DateOfBirth.Year}";
        }
    }
}
