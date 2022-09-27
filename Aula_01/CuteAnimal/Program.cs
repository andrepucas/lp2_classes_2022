using System;

namespace CuteAnimal
{
    public class Program
    {
        static void Main()
        {
            Cat c1 = new Cat("Beep", 3, Feed.Satisfied, Mood.IgnoringYou);
            Cat c2 = new Cat("Clap", 2, Feed.Hungry, Mood.Grumpy);
            Cat c3 = new Cat ("Random 1");
            Cat c4 = new Cat ("Random2");

            Console.WriteLine(c1.ToString());
            Console.WriteLine(c2.ToString());
            Console.WriteLine(c3.ToString());
            Console.WriteLine(c4.ToString());
            Console.WriteLine("\nOldest possible age for a cat: " + Cat.maxAge);
        }
    }
}