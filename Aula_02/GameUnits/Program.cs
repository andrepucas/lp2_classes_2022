using System;

namespace GameUnits
{
    class Program
    {
        private static void Main(string[] args)
        {
            Unit mu = new MilitaryUnit(4, 100, 30);
            Unit su = new SettlerUnit(10, 200);

            mu.Move(new Vector2(2, -3));
            su.Move(new Vector2(-3, 5));

            Console.WriteLine(mu);
            Console.WriteLine(su);
        }
    }
}
