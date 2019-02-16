using System.Collections.Generic;
using Epam.Task7.Users.BLL.Interface;
using Epam.Task7.Users.DAL.Interface;
using Epam.Task7.Users.Entities;

namespace Epam.Task7.Users.BLL
{
    public class UserAdminLogic : IUserAdminLogic
    {
        private const string AllUserAdminCacheKey = "GetAllUserAdmin";

        private readonly IUserAdminFakeDao userAdminFakeDao;

        public UserAdminLogic(IUserAdminFakeDao userAdminFakeDao)
        {
            this.userAdminFakeDao = userAdminFakeDao;
        }

        public void AddUserAdmin(UserAdmin userAdmin)
        {
            var flag = 0;
            if (userAdmin != null)
            {
                if ((userAdmin.Login.Length > 0) && (userAdmin.Pass.Length > 0))
                {
                        var test = this.userAdminFakeDao.GetAll();

                        foreach (var item in test)
                        {
                            if (item.Login.Contains(userAdmin.Login))
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
            return this.userAdminFakeDao.GetAll();
        }

        public bool UpdateUserAdmin(UserAdmin userAdmin)
        {
            if ((userAdmin.Login.Length > 0) && (userAdmin.Pass.Length > 0))
            {
                this.userAdminFakeDao.UpdateUserAdmin(userAdmin);
                return true;
            }

            return false;
        }

        public bool IsRegistered(string log)
        {
            var allPeople = this.userAdminFakeDao.GetAll();
            foreach (var item in allPeople)
            {
                if (item.Login == log)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsCorrectPass(string log, string pas)
        {
            var allPeople = this.userAdminFakeDao.GetAll();
            foreach (var item in allPeople)
            {
                if ((item.Login == log) && (item.Pass == pas))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsAdminOrUser(string log)
        {
            var allPeople = this.userAdminFakeDao.GetAll();
            foreach (var item in allPeople)
            {
                if ((item.Login == log) && (item.AdminOrUser == 1))
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
