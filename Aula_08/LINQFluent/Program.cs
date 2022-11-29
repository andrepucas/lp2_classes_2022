using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace LINQFluent
{
    class Program
    {
        private static string[] _textLines;

        private static void Main(string[] args)
        {
            _textLines = File.ReadAllLines("roger1.txt");

            Console.WriteLine("Linhas com comprimento maior que 30 chars: "
                + _textLines.Count(s => s.Length > 30));

            Console.WriteLine("Média de caracteres por linha: "
                + _textLines.Average(s => s?.Length).ToString());

            Console.WriteLine("Existe alguma linha com mais de 120 chars? "
                + _textLines.Any(s => s?.Length > 120).ToString());

            Console.WriteLine("A primeira letra de linhas que contenham 'Y': ");

            foreach (string s in _textLines.Where(s => s.Contains("Y")).Select(s => s.Trim().Split()[0].ToRandomCase()))
                Console.WriteLine(s);

            // EM QUERY
            // IEnumerable<string> m_strings = 
            //     from s in _textLines
            //     where s.Contains("Y")
            //     select s.Trim().Split()[0].ToUpper(); 
        }
    }
}
