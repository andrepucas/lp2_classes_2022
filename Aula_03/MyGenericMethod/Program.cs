using System;
using System.Collections.Generic;

namespace MyGenericMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            IHasValue[] valuables = new IHasValue[]
            {
                new Building("T3", 120, 3000),
                new Building("T0", 5, 1000),
                new MilitaryUnit(3, 50, 10),
                new SettlerUnit(5, 200),
                new SettlerUnit(4, 200)
            };

            Console.WriteLine("No. buildings       : {0}",
                HowManyOfType<Building>(valuables));

            Console.WriteLine("No. units           : {0}",
                HowManyOfType<Unit>(valuables));

            Console.WriteLine("No. settler units   : {0}",
                HowManyOfType<SettlerUnit>(valuables));

            Console.WriteLine("No. military units  : {0}",
                HowManyOfType<MilitaryUnit>(valuables));
        }

        private static int HowManyOfType<T>(IEnumerable<IHasValue> p_collection)
            where T : IHasValue
        {
            int __count = 0;
            foreach (IHasValue item in p_collection) if (item is T) __count++;
            return __count;
        }
    }
}
