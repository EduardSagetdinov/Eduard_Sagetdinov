using System;
using System.Collections.Generic;
using Epam.Task7.Users.BLL.Interface;
using Epam.Task7.Users.DAL;
using Epam.Task7.Users.Entities;

namespace Epam.Task7.Users.BLL
{
    public class UserLogic : IUserLogic
    {
        private const string AllUsersCacheKey = "GetAllUsers";
        private readonly IUserDao userDao;
        private readonly ICacheLogic cacheLogicUser;

        public UserLogic(IUserDao userDao, ICacheLogic cacheLogic)
        {
            this.userDao = userDao;
            this.cacheLogicUser = cacheLogic;
        }

        public void AddUser(User user)
        {
            if (user != null)
            {
                if ((DateTime.Now.Year - user.DateOfBirth.Year >= 5) && (DateTime.Now.Year - user.DateOfBirth.Year   <= 130))
                {
                    this.cacheLogicUser.Delete(AllUsersCacheKey);
                    this.userDao.AddUser(user);
                }
            }
        }

        public void DeleteUser(int id)
        {
            this.userDao.DeleteUser(id);
        }

        public void UpdateUser(User user)
        {
            if ((DateTime.Now.Year - user.DateOfBirth.Year >= 5) && (DateTime.Now.Year - user.DateOfBirth.Year <= 130))
            {
                this.userDao.UpdateUser(user);
            }
        }

        public IEnumerable<User> GetAll()
        {
            var cacheResult = this.cacheLogicUser.Get<IEnumerable<User>>(AllUsersCacheKey);
            if (cacheResult == null)
            {
                var result = this.userDao.GetAll();
                this.cacheLogicUser.Add(AllUsersCacheKey, this.userDao.GetAll());
                return result;
            }

            return cacheResult;
        }
    }
}
