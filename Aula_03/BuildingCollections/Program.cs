using System;
using System.Collections.Generic;

namespace BuildingCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Building> list = new List<Building>();
            Stack<Building> stack = new Stack<Building>();
            Queue<Building> queue = new Queue<Building>();
            HashSet<Building> hashSet = new HashSet<Building>();

            Building b1 = new Building("T0", 5f, 1000);
            Building b2 = new Building("T1", 20f, 2000);
            Building b3 = new Building("T5", 200f, 15000);
            Building b4 = new Building("T2", 50f, 3000);

            list.Add(b1);
            list.Add(b2);
            list.Add(b3);
            list.Add(b4);
            list.Add(b4);

            stack.Push(b1);
            stack.Push(b2);
            stack.Push(b3);
            stack.Push(b4);
            stack.Push(b4);

            queue.Enqueue(b1);
            queue.Enqueue(b2);
            queue.Enqueue(b3);
            queue.Enqueue(b4);
            queue.Enqueue(b4);

            hashSet.Add(b1);
            hashSet.Add(b2);
            hashSet.Add(b3);
            hashSet.Add(b4);
            hashSet.Add(b4);

            Console.WriteLine("\nList:");

            foreach(Building b in list)
                Console.WriteLine(b);

            Console.WriteLine("\nStack:");

            foreach(Building b in stack)
                Console.WriteLine(b);

            Console.WriteLine("\nQueue:");

            foreach(Building b in queue)
                Console.WriteLine(b);

            Console.WriteLine("\nHashSet:");

            foreach(Building b in hashSet)
                Console.WriteLine(b);
        }
    }
}
