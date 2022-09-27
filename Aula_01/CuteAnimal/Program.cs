using System;

namespace CuteAnimal
{
    public class Program
    {
        static void Main()
        {
            Cat c1 = new Cat("Beep", 3, Feed.Satisfied, Mood.Happy| Mood.HyperActive);
            Cat c2 = new Cat("Clap", 2, Feed.Hungry, Mood.Grumpy | Mood.IgnoringYou);
            Cat c3 = new Cat("Rnd Blob");
            Cat c4 = new Cat("Rnd Pap");

            Console.WriteLine(c1.ToString());
            Console.WriteLine(c2.ToString());
            Console.WriteLine(c3.ToString());
            Console.WriteLine(c4.ToString());
            Console.WriteLine("\nOldest possible age for a cat: " + Cat.MaxAge);
        }
    }
}