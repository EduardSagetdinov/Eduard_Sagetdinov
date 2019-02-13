using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Users.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string photoUserLink { get; set; } = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ69ZfwZPfQ4JKyO4RbcYTF6Ga6nngAO__p35KL45YtrlL0OYEh";

        public override string ToString()
        {
            return $"{Id} {Name} {DateOfBirth:dd/MM/yyyy} {DateTime.Now.Year - DateOfBirth.Year} {photoUserLink}";
        }
    }
}
