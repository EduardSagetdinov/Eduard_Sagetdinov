using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.FONT_ADJUSTMENT
{
    public class Program
    {
        [Flags]
        public enum Fonts
        {
            bold = 1,
            italic = 2,
            underline = 4,
        }

        public static void Task()
        {
            Console.Write(@"Choose the type of font:
                            1: bold
                            2: italic
                            3: underline
                           For exit type something among 1, 2, 3 or press Enter");
            Console.WriteLine();
        }

        public static void ChooseFonts(int n)
        {
            Fonts f = (Fonts)Math.Pow(2, n - 1) & Fonts.bold & Fonts.italic & Fonts.underline;
            
            while (n >= 1 && n <= 3) 
            {
               if (f.HasFlag((Fonts)Math.Pow(2, n - 1)))
                {
                    f = f ^ (Fonts)Math.Pow(2, n - 1);
                }
                else
                {
                    f = f | (Fonts)Math.Pow(2, n - 1);
                }

                Console.WriteLine($"You have chosen {f.ToString()} type.");
                Console.WriteLine();
                Task();
                
                int.TryParse(Console.ReadLine(), out n);
            } 
        }

        public static void Main(string[] args)
        {
            Console.Write(@"Choose the type of font:
                            1: bold
                            2: italic
                            3:underline
                           For exit type something among 1, 2, 3");
            Console.WriteLine();
            if (!int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine("Exit!");
            }
            else
            {
                ChooseFonts(n);
            }
        }
    }
}
