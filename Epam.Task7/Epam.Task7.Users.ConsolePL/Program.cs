using System;
using Epam.Task7.Users.BLL.Interface;
using Epam.Task7.Users.Common;
using Epam.Task7.Users.Entities;

namespace Epam.Task7.Users.ConsolePL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var userLogic = DependencyResolver.UserLogic;
           
            AddUser(userLogic);

            AddUser(userLogic);

            AddUser(userLogic);

            userLogic.DeleteUser(1);
            userLogic.DeleteUser(3);
           
             AddUser(userLogic);
            AddUser(userLogic);
            AddUser(userLogic);
             var user1 = new User
             {
                 Id = 2,
                 Name = "Peter",
                 DateOfBirth = new DateTime(1986, 07, 24),
             };
             userLogic.UpdateUser(user1);
            ShowUser(userLogic);
        }

        private static void AddUser(IUserLogic userLogic)
        {
            var user = new User
            {
                Name = "John",
                DateOfBirth = new DateTime(1986, 07, 24),
            };
            userLogic.AddUser(user);
        }

        private static void ShowUser(IUserLogic userLogic)
        {
            foreach (var user in userLogic.GetAll())
            {
                Console.WriteLine(user);
            }
        }
    }
}
