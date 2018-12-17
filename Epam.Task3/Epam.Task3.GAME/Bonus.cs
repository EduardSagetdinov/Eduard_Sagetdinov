using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.GAME
{
    public class Bonus : Model, IAction
    {
        public Bonus(string n, int x, int y, int h, int arm, int s) : base(n, x, y, h, arm, s)
        {
        }

        public void Action()
        {
            Console.WriteLine("Giving something useful for hero!"); 
        }

        public void Algorithm()
        {
            Console.WriteLine("No algorithm!"); 
        }

        public bool IsDeath()
        {
            return false;
        }

        public void Move()
        {
            Console.WriteLine("Don't move! Only Stay!"); 
        }
    }
}
