using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4.LOST
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GroupPeople gP = new GroupPeople();
            try
            {
                gP.Init();
                Console.Write("Before removing: ");
                gP.Show();
                Console.WriteLine();
                gP.DelTwo();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
