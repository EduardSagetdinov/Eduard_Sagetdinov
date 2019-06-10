using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Blog.Bll.Interface
{
    public interface IWebUserBll
    {
        IEnumerable<string> GetRolesForUser();
        IEnumerable<string> GetRolesForUser(int id);
        bool Authenticate(string username, string password);
        void Login(string username);
        bool AuthenticateAndLogin(string username, string password);

    }
}
