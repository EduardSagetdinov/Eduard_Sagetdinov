using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4.WORD_FREQUENCY
{
    public class Text
    {
        private readonly Dictionary<string, int> cont = new Dictionary<string, int>();

        private string text = "There are two types of elephant in the world: " +
            "the African elephant and the Indian elephant It is quite " +
            "easy to tell the difference between the two because they don’t look the same. " +
            "The African elephant has bigger ears than the Indian elephant, " +
            "and the Indian elephant’s legs are shorter. Both types of elephant " +
            "use their trunks to lift things and are as strong as each other. " +
            "Elephants are faster than you would think and are more intelligent " +
            "than many other animals.";

        private List<string> textPrepared = new List<string>();

        public void PrepareText()
        {
            this.text = this.text.ToLower();
            char[] seps = { ' ', '.', ',', ';', ':', '!', '?', '-', '"' };
            this.textPrepared = this.text.Split(seps, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public void CountWords()
        {   
            int count = 1;
            foreach (var item in this.textPrepared)
            {
                try
                {
                    this.cont.Add(item, count);
                }
                catch (Exception)
                {
                    ++this.cont[item];
                }
            }
        }

        public void Show()
        {
            foreach (var item in this.cont)
            {
                Console.WriteLine($"The word {item.Key} meets for {item.Value} times");
            }
        }
    }
}
