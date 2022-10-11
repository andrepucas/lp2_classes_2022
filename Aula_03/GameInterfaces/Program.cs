using System;

namespace GameInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            IHasValue[] valuables = new IHasValue[5];
            IHasValue previous = null;

            valuables[0] = new Building("T3", 120, 3000);
            valuables[1] = new Building("T0", 5, 1000);
            valuables[2] = new MilitaryUnit(3, 50, 10);
            valuables[3] = new SettlerUnit(5, 200);
            valuables[4] = new SettlerUnit(4, 200);

            foreach (IHasValue valuable in valuables)
            {
                Console.WriteLine("{0} is {1} to previous.",
                    valuable.GetType().Name,
                    valuable.Equals(previous) ? "equal" : "NOT equal");

                previous = valuable;
            }
        }
    }
}
