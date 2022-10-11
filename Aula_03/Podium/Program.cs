using System;

namespace Podium
{
    class Program
    {
        static void Main(string[] args)
        {
            Podium<Building>    __buildingPodium;
            Podium<int>         __intPodium;

            __buildingPodium = new Podium<Building>(3);
            __buildingPodium.Add(new Building("Small hut", 1000f, 25f));
            __buildingPodium.Add(new Building("Cave", 5, 37.5f));
            __buildingPodium.Add(new Building("Skyscraper", 1500f, 2700.2f));
            __buildingPodium.Add(new Building("Stadium", 1800f, 668.7f));
            __buildingPodium.Add(new Building("School", 2500f, 350.0f));

            Console.WriteLine(" ==== Podium of Buildings ====");
            foreach (Building b in __buildingPodium) Console.WriteLine(b);

            __intPodium = new Podium<int>(5)
            { 10, -1, -9, 500, -13, 55, 19, 101, -999, -2, -1, -7};

            Console.WriteLine(" ==== Podium of Ints ====");
            foreach (int i in __intPodium) Console.WriteLine($" -> {i}");
        }
    }
}
