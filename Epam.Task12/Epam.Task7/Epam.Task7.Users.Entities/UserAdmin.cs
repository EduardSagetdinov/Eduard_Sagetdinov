using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Users.Entities
{
    public class UserAdmin
    {
        public string Login { get; set; }

        public string Pass { get; set; }

        public int AdminOrUser { get; set; }

        public override string ToString()
        {
            return $"{Login} {Pass} {AdminOrUser}"; 
        }
    }
}
