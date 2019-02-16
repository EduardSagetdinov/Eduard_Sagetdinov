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
            var userAdminLogic = DependencyResolver.UserAdminLogic;
            var userLogic = DependencyResolver.UserLogic;
            var awardsLogic = DependencyResolver.AwardLogic;
            var userAwardsLogik = DependencyResolver.UserAwardsLogic;
            Awards ironCross = new Awards
            {
                Title = "Iron_Kross",
            };
            Awards medalForHonor = new Awards
            {
                Title = "MedalForHonor",
            };
            Awards redStar = new Awards
            {
                Title = "Award_Of_Red_Star",
            };
            Awards goldMedal = new Awards
            {
                Title = "GoldMedal",
            };
            Awards silverMedal = new Awards
            {
                Title = "SilverMedal",
            };
            UsersAwards usersAwards = new UsersAwards
            {
                IdUser = 1,
                IdAward = 0,
            };
             awardsLogic.AddAward(ironCross);
             awardsLogic.AddAward(medalForHonor);
             awardsLogic.AddAward(redStar);
             awardsLogic.AddAward(goldMedal);
             awardsLogic.AddAward(silverMedal);
             AddUser(userLogic);

             AddUser(userLogic);

             AddUser(userLogic);

             userLogic.DeleteUser(3);

             AddUser(userLogic);
             AddUser(userLogic);
             AddUser(userLogic);
            var user2 = new User
            {
                Id = 2,
                Name = "Peter",
                DateOfBirth = new DateTime(56),
            };
            var user3 = new User
            {
                Id = 1,
                Name = "Irvin",
                DateOfBirth = new DateTime(1986, 07, 24),
            };
            userLogic.UpdateUser(user2);
            userLogic.UpdateUser(user3);
            ShowUser(userLogic);
             ShowAward(awardsLogic);
            ShowUserAward(userAwardsLogik);
            ShowAwardsOfUser(userAwardsLogik, user3);
        }

        private static void ShowAwardsOfUser(IUserAwardsLogic userAwardsLogik, User user1)
        {
            foreach (var item in userAwardsLogik.GetAwardsOfUser(user1))
            {
                Console.WriteLine($"For user {user1.Name} Award is {item}");
            }
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
            Console.WriteLine();
            Console.WriteLine("ID|Name|  Birth |Age");
            foreach (var user in userLogic.GetAll())
            {
                Console.WriteLine(user.Name);
            }
        }

        private static void ShowAward(IAwardLogic awardLogic)
        {
            Console.WriteLine();
            Console.WriteLine("ID|Title ");
            foreach (var award in awardLogic.GetAll())
            {
                Console.WriteLine(award);
            }
        }

        private static void ShowUserAward(IUserAwardsLogic userAwardsLogic)
        {
            Console.WriteLine();
            Console.WriteLine("ID_User|ID_Award ");
            foreach (var award in userAwardsLogic.GetAllUserAward())
            {
                Console.WriteLine(award);
            }
        }
    }
}
