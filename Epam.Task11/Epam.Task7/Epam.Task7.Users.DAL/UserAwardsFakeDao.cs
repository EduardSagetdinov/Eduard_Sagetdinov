using System.Collections.Generic;
using System.IO;
using System.Linq;
using Epam.Task7.Users.DAL.Interface;

namespace Epam.Task7.Users.Entities
{
    public class UserAwardsFakeDao : IUserAwardsDao
    {
        private static string fileUsersAwardsPath = Path.GetTempPath() + "usersAwards.txt";
        
        public void AddUserAward(UsersAwards userAward)
        {
            int userId = 0;
            int awardId = 0;
            string[] userAwards;
            int count = 0;

            FileExists();

            var listOfUsersAwards = File.ReadAllLines(fileUsersAwardsPath);
            if (listOfUsersAwards.Length != 0)
            {
                foreach (var item in listOfUsersAwards)
                {
                    userAwards = item.Split(' ');
                    userId = int.Parse(userAwards[0]);
                    awardId = int.Parse(userAwards[1]);
                    if ((userId == userAward.IdUser) && (awardId == userAward.IdAward))
                    {
                        ++count;
                        break;
                    }
                }
            }

            if (count == 0)
            {
                using (StreamWriter newUserAward = File.AppendText(fileUsersAwardsPath))
                {
                    newUserAward.WriteLine(userAward.ToString());
                }
            }
        }

        public void DelUserAward(int idUser, int idAward)
        {
            int userId = 0;
            int awardId = 0;
            string[] usersAwards;
            FileExists();
            var listOfUsersAwards = File.ReadAllLines(fileUsersAwardsPath).ToList();
            foreach (var item in listOfUsersAwards)
            {
                usersAwards = item.Split(' ');
                userId = int.Parse(usersAwards[0]);
                awardId = int.Parse(usersAwards[1]);
                if ((userId == idUser) && (awardId == idAward))
                {
                    listOfUsersAwards.Remove(item);
                    File.WriteAllLines(fileUsersAwardsPath, listOfUsersAwards);
                    break;
                }
            }
        }

        public IEnumerable<UsersAwards> GetAllUserAward()
        {
            FileExists();
            var arrayOfUsersAwards = File.ReadAllLines(fileUsersAwardsPath);
            List<UsersAwards> awardList = new List<UsersAwards>();
            string line;
            using (StreamReader streamReader = File.OpenText(fileUsersAwardsPath))
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] oneUserAward = line.Split(' ');
                    int idUser = int.Parse(oneUserAward[0]);
                    int idAward = int.Parse(oneUserAward[1]);

                    UsersAwards userAwardForList = new UsersAwards
                    {
                        IdUser = idUser,
                        IdAward = idAward,
                    };
                    awardList.Add(userAwardForList);
                }

                return awardList;
            }
        }

        public bool UpdUserAward(UsersAwards userAward)
        {
            FileExists();
            var arrayOfUsersAwards = File.ReadAllLines(fileUsersAwardsPath);

            List<string> listOfUsersAwards = arrayOfUsersAwards.ToList();

            if (listOfUsersAwards.Count != 0)
            {
                foreach (var item in listOfUsersAwards.ToList())
                {
                    string[] infoUserAward = item.Split(' ');
                    if ((userAward.IdUser == int.Parse(infoUserAward[0])) && (userAward.IdAward == int.Parse(infoUserAward[1])))
                    {
                        listOfUsersAwards.Remove(item);
                        listOfUsersAwards.Add(userAward.ToString());
                        File.WriteAllLines(fileUsersAwardsPath, listOfUsersAwards);
                        return true;
                    }
                }
            }

            return false;
        }

        private static void FileExists()
        {
            if (!File.Exists(fileUsersAwardsPath))
            {
                using (FileStream fs = File.Create(fileUsersAwardsPath))
                {
                }
            }
        }
    }
}
