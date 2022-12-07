using System;
using System.Linq;
using System.Collections.Generic;

namespace ExtendString
{
    class Program
    {
        private static IEnumerable<int?> lotsOfInts;
        
        static void Main(string[] args)
        {
            lotsOfInts = new List<int?>(){1, 2,null, 3, 4, 5, 6, 10, 20, 50, 200};

            Console.WriteLine(lotsOfInts.Count(i => i % 2 != 0));

            foreach (int? i in lotsOfInts.Where(i => 100 % i == 0))
                Console.Write(i + " ");

            //bool hasNulls = bagOfInts.Any(i => !i.HasValue);
        }
    }
}
