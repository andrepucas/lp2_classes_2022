using System;

namespace LazySingleFloat
{
    class Program
    {
        private static void Main(string[] args)
        {
            SetValue();
            PrintValue();
        }

        private static void SetValue()
        {
            SingletonManager.Instance.FloatValue = 8;
        }

        private static void PrintValue()
        {
            Console.WriteLine(SingletonManager.Instance.FloatValue);
        }
    }
}
