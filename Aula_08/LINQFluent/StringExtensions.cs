using System;
using System.Text;

namespace LINQFluent
{
    public static class StringExtensions
    {
        private static Random _rnd;

        static StringExtensions()
        {
            _rnd = new Random();
        }

        public static string ToRandomCase(this String s)
        {
            StringBuilder m_sb = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                if (_rnd.NextDouble() > 0.5f) 
                    m_sb.Append(char.ToLower(s[i]));

                else m_sb.Append(char.ToUpper(s[i]));
            }

            return m_sb.ToString();
        }
    }
}