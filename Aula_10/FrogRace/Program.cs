using System;
using System.Threading;
using System.Collections.Generic;

namespace FrogRace
{
    class Program
    {
        private static object _threadLock = new object();

        private static List<object> _raceFinishers;
        
        private static void Main(string[] args)
        {
            Thread t1 = new Thread(Go);
            Thread t2 = new Thread(Go);
            Thread t3 = new Thread(Go);

            _raceFinishers = new List<object>();

            t1.Name = "T_One";
            t2.Name = "T_Two";
            t3.Name = "T_Three";

            t1.Start(1);
            t2.Start(2);
            t3.Start(3);

            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("\n\n-- PÓDIO --");
            for (int i = 0; i < _raceFinishers.Count; i++)
                Console.WriteLine($"POS {i+1} - RÃ {(int)_raceFinishers[i]}");
        }

        private static void Go(object p_frogNum)
        {
            Random rnd = new Random();

            for (int i = 0; i < 11; i++)
            {
                Console.Write($"\nRâ {p_frogNum} deu salto {i} " +
                    $"(thread {Thread.CurrentThread.Name})");

                Thread.Sleep(rnd.Next(1001));
            }

            lock(_threadLock) _raceFinishers.Add(p_frogNum);
        }
    }
}
