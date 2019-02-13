using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Users.Entities
{
    public class UserAdmin
    {
        public string login { get; set; }
        public string pass { get; set; }
        public int adminOrUser { get; set; }
        public override string ToString()
        {
            return $"{login} {pass} {adminOrUser}"; 
        }
    }
}
