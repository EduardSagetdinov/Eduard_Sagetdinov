using System.Collections.Generic;
using System.IO;
using System.Linq;
using Epam.Task7.Users.DAL.Interface;
using Epam.Task7.Users.Entities;

namespace Epam.Task7.Users.DAL
{
    public class AwardsFakeDao : IAwardsDao
    {
        private const string FileAwardsPath = "Awards.txt";

        private int max = 0;
        
        public void AddAward(Awards award)
        {
            FileExists();

            var listOfAwards = File.ReadAllLines(FileAwardsPath).ToList();
            var hashAwards = new HashSet<string>();
            if (listOfAwards.Count == 0)
            {
                award.Id = 0;
            }
            else
            {
                foreach (var item in listOfAwards)
                {
                    string[] infoAward = item.Split(' ');
                    hashAwards.Add(infoAward[1]);
                    if (int.TryParse(infoAward[0], out int id) && this.max < id)
                    {
                        this.max = id;
                    }
                }

                award.Id = ++this.max;
                this.max = 0;
            }

            if (hashAwards.Add(award.Title))
            {
                listOfAwards.Add(award.ToString());
                File.WriteAllLines(FileAwardsPath, listOfAwards);
            }
        }

        public void DelAward(int id)
        {
            FileExists();
            var arrayOfAwards = File.ReadAllLines(FileAwardsPath);
            List<string> listOfAwards = arrayOfAwards.ToList();

            if (listOfAwards.Count != 0)
            {
                foreach (var item in listOfAwards.ToList())
                {
                    string[] infoAward = item.Split(' ');
                    if (id == int.Parse(infoAward[0]))
                    {
                        listOfAwards.Remove(item);
                        File.WriteAllLines(FileAwardsPath, listOfAwards);
                        break;
                    }
                }
            }
        }

        public IEnumerable<Awards> GetAll()
        {
            FileExists();
            var arrayOfAwards = File.ReadAllLines(FileAwardsPath);
            List<Awards> awardList = new List<Awards>();
            string line;
            using (StreamReader streamReader = File.OpenText(FileAwardsPath))
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] oneAward = line.Split(' ');
                    int id = int.Parse(oneAward[0]);
                    string title = oneAward[1];
                    
                    Awards awardForDict = new Awards
                    {
                        Id = id,
                        Title = title,
                    };
                    awardList.Add(awardForDict);
                }

                return awardList;
            }
        }

        public bool UpdAward(Awards award)
        {
            FileExists();
            var arrayOfAwards = File.ReadAllLines(FileAwardsPath);

            List<string> listOfAwards = arrayOfAwards.ToList();

            if (listOfAwards.Count != 0)
            {
                foreach (var item in listOfAwards.ToList())
                {
                    string[] infoAward = item.Split(' ');
                    if (award.Id == int.Parse(infoAward[0]))
                    {
                        listOfAwards.Remove(item);
                        listOfAwards.Add(award.ToString());
                        File.WriteAllLines(FileAwardsPath, listOfAwards.ToArray());
                        return true;
                    }
                }
            }

            return false;
        }

        private static void FileExists()
        {
            if (!File.Exists(FileAwardsPath))
            {
                using (FileStream fs = File.Create(FileAwardsPath))
                {
                }
            }
        }
    }
}
