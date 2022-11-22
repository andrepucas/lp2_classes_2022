using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Observers
{
    public class KeyReader : AbstractStringSubject
    {
        public void ReadKeys()
        {
            ConsoleKey m_key;

            while ((m_key = Console.ReadKey(true).Key) != ConsoleKey.Escape)
            {
                Item = m_key.ToString();
            }
        }
    }
}