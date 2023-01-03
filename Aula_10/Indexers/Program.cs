using System;

namespace Indexers
{
    class Program
    {
        static void Main(string[] args)
        {
            MyVector v1 = new MyVector(7, 10);

            Console.WriteLine(v1[0]);
            Console.WriteLine(v1["b"]);

            v1[0] = 2;

            Console.WriteLine(v1["x"]);
        }
    }
}
