using System;

namespace ExceptionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Insere um numero inteiro: ");
            
            try
            {
                int i = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Numero inserido: {i}");
            } 
            catch (FormatException){
                Console.WriteLine("Don't. Not a number.");
            }

            catch (OverflowException){
                Console.WriteLine("Don't. Chill with the size");
            }

            catch (Exception e){
                Console.WriteLine("Wtv this is: " + e.Message);
            }

            finally{
                Console.WriteLine("Wtv, bye.");
            }
        }
    }
}
