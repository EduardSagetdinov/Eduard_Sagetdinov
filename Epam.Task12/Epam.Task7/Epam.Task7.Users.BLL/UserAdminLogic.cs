using Epam.Task7.Users.BLL.Interface;
using Epam.Task7.Users.DAL.Interface;
using Epam.Task7.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Users.BLL
{
    public class UserAdminLogic : IUserAdminLogic
    {
        private const string AllUserAdminCacheKey = "GetAllUserAdmin";
        private readonly IUserAdminFakeDao userAdminFakeDao;
        private readonly ICacheLogic cacheLogicUserAdmin;

        public UserAdminLogic(IUserAdminFakeDao userAdminFakeDao, ICacheLogic cacheLogic)
        {
            this.userAdminFakeDao = userAdminFakeDao;
            this.cacheLogicUserAdmin = cacheLogic;
        }
        public void AddUserAdmin(UserAdmin userAdmin)
        {
            var flag = 0;
            if (userAdmin != null)
            {
                if ((userAdmin.login.Length > 0) && (userAdmin.pass.Length > 0))
                {
                   
                        var test = userAdminFakeDao.GetAll();
                        foreach(var item in test)
                        {
                            if (item.login.Contains(userAdmin.login))
                            {
                                flag = 1;
                            }
                        }
                    if (flag == 0)
                    {
                        this.userAdminFakeDao.AddUserAdmin(userAdmin);
                    }
                    
                   
                  
                }
                flag = 0;
            }
        }

        public void DeleteUserAdmin(string login)
        {
            this.userAdminFakeDao.DeleteUserAdmin(login);
        }

        public IEnumerable<UserAdmin> GetAll()
        {
            return userAdminFakeDao.GetAll();
        }

        public bool UpdateUserAdmin(UserAdmin userAdmin)
        {
            if ((userAdmin.login.Length > 0) && (userAdmin.pass.Length > 0))
            {
                this.userAdminFakeDao.UpdateUserAdmin(userAdmin);
                return true;
            }
            return false;
        }
        public bool isRegistered(string log)
        {
            var allPeople = userAdminFakeDao.GetAll();
            foreach(var item in allPeople)
            {
                if(item.login == log)
                {
                    return true;
                }
               
            }
            return false;
        }
        public bool isCorrectPass(string log, string pas)
        {
            var allPeople = userAdminFakeDao.GetAll();
            foreach (var item in allPeople)
            {
                if ((item.login == log) && (item.pass == pas))
                {
                    return true;
                }

            }
            return false;
        }
        public bool isAdminOrUser(string log)
        {
            var allPeople = userAdminFakeDao.GetAll();
            foreach (var item in allPeople)
            {
                if ((item.login == log) && (item.adminOrUser == 1))//1-admin, 0-user
                {
                    return true;
                }
                if (log == "admin")
                {
                    return true;
                }
            }
            return false;
        }
    }
   
}
