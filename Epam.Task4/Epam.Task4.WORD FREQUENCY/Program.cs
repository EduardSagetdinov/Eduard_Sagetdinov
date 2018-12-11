using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4.WORD_FREQUENCY
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Text tx = new Text();
            tx.PrepareText();
            tx.CountWords();
            tx.Show();
        }
    }
}
