using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4.LOST
{
    public class GroupPeople
    {
        private readonly List<int> numPeople = new List<int>();

        public void Init()
        {
            Console.WriteLine("How many men in your round?");
            string a = Console.ReadLine();
         
                this.Test(a, out int c);
                for (int i = 1; i <= c; i++)
                {
                    this.numPeople.Add(i);
                }
        }

        public void DelTwo()
        {
            while (this.numPeople.Count != 1)
            {
                for (int i = 1; i < this.numPeople.Count; i += 2)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Removing people with number {numPeople[i]} at index {i}");
                    this.numPeople.RemoveAt(i);
                    Console.Write("After removing: ");
                    this.Show();
                }
            }

            Console.Write($"The last man with number: ");
            this.Show();
        }

        public void Test(string h, out int e)
        {
            if (!int.TryParse(h, out e) || e <= 0)
            {
                throw new Exception("Wrong data!!!");
            }
        }

        public void Show()
        {
            foreach (var item in this.numPeople)
            {
                Console.Write(item + "\t");
            }

            Console.WriteLine();
        }
    }
}
