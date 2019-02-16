using System;
using System.Collections.Generic;
using System.Linq;
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
            return this.userDao.GetAll();
        }

        public IEnumerable<User> GetUserById(int id)
        {
            var all = this.userDao.GetAll();
            IEnumerable<User> us = from f in all where f.Id == id select f;
            return us;
        }
    }
}
