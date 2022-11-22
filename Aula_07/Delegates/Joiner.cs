using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delegates
{
    public class Joiner
    {
        private string _firstString;

        public Joiner(string p_str) =>
            _firstString = p_str;

        public void JoinAndPrint(string p_otherStr) =>
            Console.WriteLine(_firstString + p_otherStr);
    }
}