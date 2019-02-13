using Epam.Task7.Users.DAL.Interface;
using Epam.Task7.Users.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Users.DAL
{
    public class UserAdminFakeDao : IUserAdminFakeDao
    {
        private const string FileUserAdminPath = "C:/Users/123/source/repos/Epam.Task7_1/Epam.Task7/UserAdmin.txt";
        private static void FileExists()
        {
            if (!File.Exists(FileUserAdminPath))
            {
                using (FileStream fs = File.Create(FileUserAdminPath))
                {
                }
            }
        }
        public void AddUserAdmin(UserAdmin userAdmin)
        {
            FileExists();

            var listOfUserAdmin = File.ReadAllLines(FileUserAdminPath);



            using (StreamWriter newUser = File.AppendText(FileUserAdminPath))
            {
                newUser.WriteLine(userAdmin.ToString());
            }
        }

        public void DeleteUserAdmin(string login)
        {
            FileExists();
            var arrayOfUserAdmin = File.ReadAllLines(FileUserAdminPath);
            List<string> listOfUserAdmin = arrayOfUserAdmin.ToList();

            if (listOfUserAdmin.Count != 0)
            {
                foreach (var item in listOfUserAdmin)
                {
                    string[] infoUserAdmin = item.Split(' ');
                    if (login == infoUserAdmin[0])
                    {
                        listOfUserAdmin.Remove(item);
                        File.WriteAllLines(FileUserAdminPath, listOfUserAdmin.ToArray());
                        break;
                    }
                }
            }
        }

        public IEnumerable<UserAdmin> GetAll()
        {
            FileExists();
            var arrayOfUsers = File.ReadAllLines(FileUserAdminPath);
            List<UserAdmin> userAdminList = new List<UserAdmin>();
            string line;
            using (StreamReader streamReader = File.OpenText(FileUserAdminPath))
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] oneUserAdmin = line.Split(' ');
                    string log = oneUserAdmin[0];
                    string password = oneUserAdmin[1];
                    int adminOrNotAdmin = int.Parse(oneUserAdmin[2]);
                    UserAdmin userAdminForDict = new UserAdmin
                    {
                        login = log,
                        pass = password,
                        adminOrUser = adminOrNotAdmin,
                    };
                    userAdminList.Add(userAdminForDict);
                }

                return userAdminList;
            }
        }

        public bool UpdateUserAdmin(UserAdmin userAdmin)
        {
            FileExists();
            var arrayOfUserAdmin = File.ReadAllLines(FileUserAdminPath);

            List<string> listOfUserAdmin = arrayOfUserAdmin.ToList();

            if (listOfUserAdmin.Count != 0)
            {
                foreach (var item in listOfUserAdmin.ToList())
                {
                    string[] infoUserAdmin = item.Split(' ');
                    if (userAdmin.login == infoUserAdmin[0])
                    {
                        listOfUserAdmin.Remove(item);
                        listOfUserAdmin.Add(userAdmin.ToString());
                        File.WriteAllLines(FileUserAdminPath, listOfUserAdmin.ToArray());
                        return true;
                    }
                }
            }

            return false;
        }
    }
}

