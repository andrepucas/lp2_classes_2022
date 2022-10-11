using System;
using System.Collections.Generic;

namespace HashBuildings
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Building> list = new List<Building>();
            Stack<Building> stack = new Stack<Building>();
            Queue<Building> queue = new Queue<Building>();
            HashSet<Building> hashSet = new HashSet<Building>();

            Building[] array = new Building[]
            {
                new Building("T0", 5f, 1000),
                new Building("T1", 20f, 2000),
                new Building("T5", 200f, 15000),
                new Building("T2", 50f, 3000),
                new Building("T1", 20f, 2000)
            };

            foreach (Building b in array)
            {
                list.Add(b);
                stack.Push(b);
                queue.Enqueue(b);
                hashSet.Add(b);
            }

            Console.WriteLine("\nList:");
            foreach(Building b in list) Console.WriteLine(b);

            Console.WriteLine("\nStack:");
            foreach(Building b in stack) Console.WriteLine(b);

            Console.WriteLine("\nQueue:");
            foreach(Building b in queue) Console.WriteLine(b);

            Console.WriteLine("\nHashSet:");
            foreach(Building b in hashSet) Console.WriteLine(b);
        }
    }
}
