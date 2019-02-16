using System;
using System.Web.Security;
using Epam.Task7.Users.Common;

namespace Epam.Task11.WEB_UI.RolveProvider
{
    public class MyRoleProvider : RoleProvider
    {
        public override bool IsUserInRole(string username, string roleName)
        {
            if (username == "admin")
            {
                return true;
            }

            if (roleName == "User")
            {
                return true;
            }

            return false;
        }

        public override string[] GetRolesForUser(string username)
        {
            var userAdminLogic = DependencyResolver.UserAdminLogic;
            switch (userAdminLogic.IsAdminOrUser(username))
            {
                case true:
                    return new[] { "Admin" };
                default:
                    return new[] { "User" };
            }
        }

        #region NotImplemented

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}