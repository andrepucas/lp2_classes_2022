using System;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Joiner _joiner = new Joiner("yabadabadoo");

            Delegate _delegate = PrintUpper;

            _delegate += PrintLower;
            _delegate += _joiner.JoinAndPrint;

            _delegate.Invoke("maybe");
        }

        static void PrintUpper(string p_str) => 
            Console.WriteLine(p_str.ToUpper());

        static void PrintLower(string p_str) => 
            Console.WriteLine(p_str.ToLower());
    }
}