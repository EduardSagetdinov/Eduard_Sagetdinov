using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.GAME
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Hero gamer = new Hero("SuperGamer", 0, 0, 100, 25, 30);
            Monster mons = new Monster("Wolf", 1, 1, 20, 10, 30, 50);
            Monster mons1 = new Monster("Bear", 10, 15, 200, 100, 10, 500);
            Obstacle stone = new Obstacle("stone", 4, 6, 0, 0, 0);
            Obstacle tree = new Obstacle("tree", 7, 77, 0, 0, 0);
            Bonus apple = new Bonus("apple", 2, 2, 25, 0, 0);
            Bonus banana = new Bonus("banana", 15, 14, 25, 150, 0);
            Field f = new Field(100, 100, 1);
        }
    }
}
