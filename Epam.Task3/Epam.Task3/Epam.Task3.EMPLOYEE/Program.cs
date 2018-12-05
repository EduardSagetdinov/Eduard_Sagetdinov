using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.EMPLOYEE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Employee emp;
            string sn;
            string n;
            string patr;
            string d;
            string pos;
            string exp;

            Console.Write("What is your name: ");
            n = Console.ReadLine();
            Console.Write("What is your surname: ");
            sn = Console.ReadLine();
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
            Console.Write("What is your position?  ");
            pos = Console.ReadLine();
            Console.Write("What is your experience?  ");
            exp = Console.ReadLine();
            try
            {
                emp = new Employee(sn, n, patr, d, pos, exp);
                if (emp.Age >= 150 || emp.Age <= 0 || int.Parse(emp.Experience) < 0)
                {
                    Console.WriteLine("It is wrong data!");
                }
                else
                {
                    Console.WriteLine($"Hello, {emp.Surname} {emp.Name} {emp.Patronymic}!!!");
                    Console.WriteLine($"You date of birth is: {emp.Birth.ToString("dd-MM-yyyy")}");
                    Console.WriteLine($"You age is {emp.Age} years.");
                    Console.WriteLine($"You are woking as {emp.Position} for {emp.Experience} years.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
