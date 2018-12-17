using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.I_SEEK_YOU
{
    public class Timers
    {
        public static int[] MakeArray()
        {
            Random rand = new Random();
            int[] arr = new int[1000];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(-5000, 5000);
            }

            return arr;
        }

        public static TimeSpan MakeMaterial(TimeSpan[] arr)
        {
            int l = arr.Length / 2;
            Array.Sort(arr);
            return arr[l];
        }

        public static void TestTime()
        {
            long n = 10000;
            TimeSpan[] rounds = new TimeSpan[n];
            for (int i = 0; i < n; i++)
            {
                int[] arr = MakeArray();
                var time = Stopwatch.StartNew();
                StraitFind.StFind(arr);
                time.Stop();
                rounds[i] = time.Elapsed;
            }

            Console.WriteLine($"Straith find: {MakeMaterial(rounds)}");
            
            for (int i = 0; i < n; i++)
            {
                int[] arr = MakeArray();
                var time = Stopwatch.StartNew();
                DelegateFind.DelegFind(arr, DelegateFind.Compare);
                time.Stop();
                rounds[i] = time.Elapsed;
            }

            Console.WriteLine($"Delegate find: {MakeMaterial(rounds)}");
            
            for (int i = 0; i < n; i++)
            {
                int[] arr = MakeArray();
                var time = Stopwatch.StartNew();
                AnonimFind1.AnFind(arr);
                time.Stop();
                rounds[i] = time.Elapsed;
            }

            Console.WriteLine($"Anonim find: {MakeMaterial(rounds)}");
            
            for (int i = 0; i < n; i++)
            {
                Stopwatch t = Stopwatch.StartNew();
                int[] arr = Timers.MakeArray();
                Liambda.LiamFind(arr);
                t.Stop();
                rounds[i] = t.Elapsed;
            }

            Console.WriteLine($"Liambda find: {MakeMaterial(rounds)}");
            for (int i = 0; i < n; i++)
            {
                int[] arr = MakeArray();
                var time = Stopwatch.StartNew();
                LINQ.AnFind(arr);
                time.Stop();
                rounds[i] = time.Elapsed;
            }

            Console.WriteLine($"LINQ find: {MakeMaterial(rounds)}");
        }
    }
}
