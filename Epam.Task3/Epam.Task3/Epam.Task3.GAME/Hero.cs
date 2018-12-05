using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.GAME
{
    public class Hero : Model, IAction
    {
        public Hero(string n, int x, int y, int h, int arm, int s) : base(n, x, y, h, arm, s)
        {
        }

        public void Action()
        {
         Console.WriteLine("Can run. Can't attack. Can eating bonuses"); 
        }

        public void Algorithm()
        {
            Console.WriteLine("Play this hero.");
        }

        public bool IsDeath()
        {
            if (this.Health == 0)
            {
                return true;
            }

            return false;
        }

        public void Move()
        {
        }
    }
}
