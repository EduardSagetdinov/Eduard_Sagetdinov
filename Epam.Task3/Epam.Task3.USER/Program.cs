using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.USER
{
    public class Program
    {
        public static void Main(string[] args)
        {
            User us;
            string sn;
            string n;
            string patr;
            string d;
            Console.Write("What is your surname: ");
            sn = Console.ReadLine();
            Console.Write("What is your name: ");
            n = Console.ReadLine();
            Console.Write("What is your patronymic: ");
            patr = Console.ReadLine();
            Console.Write("What is your day of birth? Only day, please:  ");
            d = Console.ReadLine();
            d += " ";
            Console.Write("What is your month of birth? Only number of month, please: ");
            d += Console.ReadLine();
            d += " ";
            Console.Write("What is your year of birth? Four digits, please: ");
            d += Console.ReadLine();
            try
            {
                us = new User(sn, n, patr, d);
                if (us.Age >= 150 || us.Age <= 0)
                {
                    Console.WriteLine("It is not your date of birth!");
                }
                else
                {
                    Console.WriteLine($"Hello, {us.Surname} {us.Name} {us.Patronymic}!!!");
                    Console.WriteLine($"You date of birth is: {us.Birth.ToString("dd-MM-yyyy")}");
                    Console.WriteLine($"You age is {us.Age} full yeas.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); 
            }
        }
    }
}
