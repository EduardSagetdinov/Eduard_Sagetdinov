using System.Collections.Generic;
using System.IO;
using System.Linq;
using Epam.Task7.Users.DAL.Interface;
using Epam.Task7.Users.Entities;

namespace Epam.Task7.Users.DAL
{
    public class AwardsFakeDao : IAwardsDao
    {
        private static string fileAwardsPath = Path.GetTempPath() + "Awards.txt";
   
        private int max = 0;
        
        public void AddAward(Awards award)
        {
            FileExists();

            var listOfAwards = File.ReadAllLines(fileAwardsPath).ToList();
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
           
            if (hashAwards.Add(award.Title) && hashAwards.Add(award.PhotoLink))
            {
                listOfAwards.Add(award.ToString());
                File.WriteAllLines(fileAwardsPath, listOfAwards);
            }
        }

        public void DelAward(int id)
        {
            FileExists();
            var arrayOfAwards = File.ReadAllLines(fileAwardsPath);
            List<string> listOfAwards = arrayOfAwards.ToList();

            if (listOfAwards.Count != 0)
            {
                foreach (var item in listOfAwards.ToList())
                {
                    string[] infoAward = item.Split(' ');
                    if (id == int.Parse(infoAward[0]))
                    {
                        listOfAwards.Remove(item);
                        File.WriteAllLines(fileAwardsPath, listOfAwards);
                        break;
                    }
                }
            }
        }

        public IEnumerable<Awards> GetAll()
        {
            FileExists();
            var arrayOfAwards = File.ReadAllLines(fileAwardsPath);
            List<Awards> awardList = new List<Awards>();
            string line;
            using (StreamReader streamReader = File.OpenText(fileAwardsPath))
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] oneAward = line.Split(' ');
                    int id = int.Parse(oneAward[0]);
                    string title = oneAward[1];
                    string photoAw = oneAward[2];
                    
                    Awards awardForDict = new Awards
                    {
                        Id = id,
                        Title = title,
                        PhotoLink = photoAw,
                    };
                    awardList.Add(awardForDict);
                }

                return awardList;
            }
        }

        public bool UpdAward(Awards award)
        {
            FileExists();
            var arrayOfAwards = File.ReadAllLines(fileAwardsPath);

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
                        File.WriteAllLines(fileAwardsPath, listOfAwards.ToArray());
                        return true;
                    }
                }
            }

            return false;
        }

        private static void FileExists()
        {
            if (!File.Exists(fileAwardsPath))
            {
                using (FileStream fs = File.Create(fileAwardsPath))
                {
                }
            }
        }
    }
}
