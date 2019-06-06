using Epam.Blog.Dal;
using Epam.Blog.Entities;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace Epam.Blog.Bll
{
    public class RoleBll
    {
        private readonly RoleDal roleDal = new RoleDal();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private readonly UsersRolesMapDal usersRolesMapDal = new UsersRolesMapDal();

        public IEnumerable<Role> GetRoleById(int id)
        {
            logger.Trace("Success");

            return roleDal.GetRoleById(id);
        }

        public IEnumerable<Role> GetRoleByName(string name)
        {
            logger.Trace("Success");

            return roleDal.GetRoleByName(name);
        }

        public IEnumerable<string> GetRolesForUser(int id)
        {
            IEnumerable<string> role = roleDal.GetRoleName(id);
            logger.Trace("Success");

            return role;
        }

        public IEnumerable<Role> GetAllRole()
        {
            logger.Trace("Success");

            return roleDal.GetAllRole();
        }

        public void AddNewRole(string name)
        {
            

            var role = roleDal.GetRoleByName(name);
            if (role.Count() != 0)
            {
                logger.Error("User already exists");
                throw new Exception("User already exists");
            }
            roleDal.AddNewRole(name);
            logger.Trace("Success");
        }

        public void UpdateRole(int id, string name)
        {
            roleDal.UpdateRole(id, name);
            logger.Trace("Success");

        }

        public void DeleteRole(string roleName)
        {
            var role = roleDal.GetRoleByName(roleName).First();

            if (role != null)
            {
                roleDal.DeleteRoleByName(roleName);
                usersRolesMapDal.DeleteUsersRolesMapByRoleId(role.Id);
                logger.Trace("Success");

            }
            else
            {
                logger.Warn("Null role");
            }

        }

        private static WebPageRenderingBase Page
        {
            get
            {
                logger.Trace("Success");

                return WebPageContext.Current.Page;

            }
        }

        public string Mode
        {
            get
            {
                if (Page.UrlData.Any())
                {
                    logger.Trace(Page.UrlData[0].ToLower());

                    return Page.UrlData[0].ToLower();
                }
                logger.Trace("Success");

                return string.Empty;
            }
        }

        public string Name
        {
            get
            {
                if (Mode != "new")
                {
                    logger.Trace("new");

                    return Page.UrlData[1];
                }
                return string.Empty;
            }
        }

        public Role Current
        {
            get
            {
                var result = GetRoleByName(Name);
                logger.Trace("success");

                return result.Count() != 0 ? result.First() : CreateRoleObject();
            }
        }

        private static Role CreateRoleObject()
        {
            var obj = new Role();
            obj.Id = 0;
            obj.Name = string.Empty;
            logger.Trace("success");

            return obj;
        }

    }
}