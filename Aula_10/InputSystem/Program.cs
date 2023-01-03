using System;
using System.Threading;
using System.Collections.Concurrent;

namespace InputSystem
{
    public class Program
    {
        // Coleção thread-safe, usa internamente uma Queue (primeira tecla a
        // entrar é a primeira a sair)
        private static BlockingCollection<ConsoleKey> _keyQueue;

        private static void Main()
        {
            Thread producer = new Thread(ReadKeys);
            Thread consumer = new Thread(ShowKeyOnScreen);

            _keyQueue = new BlockingCollection<ConsoleKey>();

            Console.WriteLine("Podes começar a carregar nas teclas");

            producer.Start();
            consumer.Start();

            producer.Join();
            consumer.Join();

            Console.WriteLine("Obrigado!");
        }

        // Método produtor:
        // Lé as teclas do teclado e coloca-as na fila
        private static void ReadKeys()
        {
            ConsoleKey m_key;

            do
            {
                m_key = Console.ReadKey(true).Key;

                _keyQueue.Add(m_key);

            } while (m_key != ConsoleKey.Escape);
        }

        // Método consumidor:
        // Obtém/retira as teclas da fila, e apresenta informação no ecrã
        private static void ShowKeyOnScreen()
        {
            ConsoleKey m_key;

            while ((m_key = _keyQueue.Take()) != ConsoleKey.Escape)
            {
                if (m_key == ConsoleKey.W || m_key == ConsoleKey.UpArrow)
                    Console.WriteLine("Cima");

                else if (m_key == ConsoleKey.A || m_key == ConsoleKey.LeftArrow)
                    Console.WriteLine("Esquerda");

                else if (m_key == ConsoleKey.S || m_key == ConsoleKey.DownArrow)
                    Console.WriteLine("Baixo");

                else if (m_key == ConsoleKey.D || m_key == ConsoleKey.RightArrow)
                    Console.WriteLine("Direita");
            }
        }
    }
}