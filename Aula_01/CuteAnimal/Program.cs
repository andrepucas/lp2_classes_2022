using System;

namespace CuteAnimal
{
    public class Program
    {
        static void Main()
        {
            Cat c1 = new Cat("Beep", 3, Feed.Satisfied, Mood.IgnoringYou);
            Cat c2 = new Cat("Clap", 2, Feed.Hungry, Mood.Grumpy);
            Cat c3 = new Cat ("R1");
            Cat c4 = new Cat ("R2");

            Console.WriteLine("Cat 1: " + c1.GetAll());
            Console.WriteLine("Cat 2: " + c2.GetAll());
            Console.WriteLine("Cat 3 (Random): " + c3.GetAll());
            Console.WriteLine("Cat 4 (Random): " + c4.GetAll());
        }
    }
}