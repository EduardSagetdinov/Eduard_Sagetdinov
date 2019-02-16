using System.Collections.Generic;
using System.IO;
using System.Linq;
using Epam.Task7.Users.DAL.Interface;
using Epam.Task7.Users.Entities;

namespace Epam.Task7.Users.DAL
{
    public class UserAdminFakeDao : IUserAdminFakeDao
    {
        private static string fileUserAdminPath = Path.GetTempPath() + "UserAdmin.txt";
   
        public void AddUserAdmin(UserAdmin userAdmin)
        {
            FileExists();

            var listOfUserAdmin = File.ReadAllLines(fileUserAdminPath);

            using (StreamWriter newUser = File.AppendText(fileUserAdminPath))
            {
                newUser.WriteLine(userAdmin.ToString());
            }
        }

        public void DeleteUserAdmin(string login)
        {
            FileExists();
            var arrayOfUserAdmin = File.ReadAllLines(fileUserAdminPath);
            List<string> listOfUserAdmin = arrayOfUserAdmin.ToList();

            if (listOfUserAdmin.Count != 0)
            {
                foreach (var item in listOfUserAdmin)
                {
                    string[] infoUserAdmin = item.Split(' ');
                    if (login == infoUserAdmin[0])
                    {
                        listOfUserAdmin.Remove(item);
                        File.WriteAllLines(fileUserAdminPath, listOfUserAdmin.ToArray());
                        break;
                    }
                }
            }
        }

        public IEnumerable<UserAdmin> GetAll()
        {
            FileExists();
            var arrayOfUsers = File.ReadAllLines(fileUserAdminPath);
            List<UserAdmin> userAdminList = new List<UserAdmin>();
            string line;
            using (StreamReader streamReader = File.OpenText(fileUserAdminPath))
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] oneUserAdmin = line.Split(' ');
                    string log = oneUserAdmin[0];
                    string password = oneUserAdmin[1];
                    int adminOrNotAdmin = int.Parse(oneUserAdmin[2]);
                    UserAdmin userAdminForDict = new UserAdmin
                    {
                        Login = log,
                        Pass = password,
                        AdminOrUser = adminOrNotAdmin,
                    };
                    userAdminList.Add(userAdminForDict);
                }

                return userAdminList;
            }
        }

        public bool UpdateUserAdmin(UserAdmin userAdmin)
        {
            FileExists();
            var arrayOfUserAdmin = File.ReadAllLines(fileUserAdminPath);

            List<string> listOfUserAdmin = arrayOfUserAdmin.ToList();

            if (listOfUserAdmin.Count != 0)
            {
                foreach (var item in listOfUserAdmin.ToList())
                {
                    string[] infoUserAdmin = item.Split(' ');
                    if (userAdmin.Login == infoUserAdmin[0])
                    {
                        listOfUserAdmin.Remove(item);
                        listOfUserAdmin.Add(userAdmin.ToString());
                        File.WriteAllLines(fileUserAdminPath, listOfUserAdmin.ToArray());
                        return true;
                    }
                }
            }

            return false;
        }

        private static void FileExists()
        {
            if (!File.Exists(fileUserAdminPath))
            {
                using (FileStream fs = File.Create(fileUserAdminPath))
                {
                }
            }
        }
    }
}
