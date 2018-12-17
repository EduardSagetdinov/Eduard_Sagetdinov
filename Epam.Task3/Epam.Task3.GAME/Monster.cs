using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.GAME
{
    public class Monster : Model, IAction
    {
        public Monster(string n, int x, int y, int h, int arm, int s, int dam) : base(n, x, y, h, arm, s)
        {
            this.Damage = dam;
        }

        public int Damage { get; set; }

        public void Action()
        {
            Console.WriteLine("Attack!!!!"); 
        }

        public void Algorithm()
        {
        }

        public bool IsDeath()
        {
            return false;
        }

        public void Move()
        {
            Console.WriteLine("Go!");
        }
    }
}
