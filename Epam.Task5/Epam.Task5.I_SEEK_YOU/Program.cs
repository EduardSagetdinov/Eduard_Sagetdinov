using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.I_SEEK_YOU
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Timers.TestTime();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
