using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Epam.Task7.Users.Entities;

namespace Epam.Task7.Users.DAL
{
    public class UserFakeDao : IUserDao
    {
        private static string fileUsersPath = Path.GetTempPath() + "Users.txt";

        private int max = 0;

        public void AddUser(User user)
        {
            FileExists();

            var listOfUsers = File.ReadAllLines(fileUsersPath);

            if (listOfUsers.Length == 0)
            {
                user.Id = 0;
            }
            else
            {
                foreach (var item in listOfUsers)
                {
                    string[] infoUser = item.Split(' ');
                    if (int.TryParse(infoUser[0], out int id) && this.max < id)
                    {
                        this.max = id;
                    }
                }

                user.Id = ++this.max;
            }

            using (StreamWriter newUser = File.AppendText(fileUsersPath))
            {
                newUser.WriteLine(user.ToString());
            }
        }

        public void DeleteUser(int id)
        {
            FileExists();
            var arrayOfUsers = File.ReadAllLines(fileUsersPath);
            List<string> listOfUsers = arrayOfUsers.ToList();
            Console.WriteLine(fileUsersPath);
            if (listOfUsers.Count != 0)
            {
                foreach (var item in listOfUsers.ToList())
                {
                    string[] infoUser = item.Split(' ');
                    Console.WriteLine(item);
                    if (id == int.Parse(infoUser[0]))
                    {
                        listOfUsers.Remove(item);
                        File.WriteAllLines(fileUsersPath, listOfUsers.ToArray());
                        break;
                    }
                }
            }
        }

        public bool UpdateUser(User user)
        {
            FileExists();
            var arrayOfUsers = File.ReadAllLines(fileUsersPath);
           
           List<string> listOfUsers = arrayOfUsers.ToList();

            if (listOfUsers.Count != 0)
            {
                foreach (var item in listOfUsers.ToList())
                {
                    string[] infoUser = item.Split(' ');
                    if (user.Id == int.Parse(infoUser[0]))
                    {
                        listOfUsers.Remove(item);
                        listOfUsers.Add(user.ToString());
                        File.WriteAllLines(fileUsersPath, listOfUsers.ToArray());
                        return true;
                    }
                }
            }

            return false;
        }
        
        public IEnumerable<User> GetAll()
        {
            FileExists();
            var arrayOfUsers = File.ReadAllLines(fileUsersPath);
            List<User> userList = new List<User>();
            string line;
            using (StreamReader streamReader = File.OpenText(fileUsersPath))
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] oneUser = line.Split(' ');
                    int id = int.Parse(oneUser[0]);
                    string name = oneUser[1];
                    string userPhotoPath = oneUser[4];
                    DateTime birth = DateTime.Parse(oneUser[2]);
                    User userForDict = new User
                    {
                        Id = id,
                        Name = name,
                        DateOfBirth = birth,
                        PhotoUserLink = userPhotoPath,
                    };
                    userList.Add(userForDict);
                }

                return userList;
            }
        }

        private static void FileExists()
        {
            if (!File.Exists(fileUsersPath))
            {
                using (FileStream fs = File.Create(fileUsersPath))
                {
                }
            }
        }
    }
}
