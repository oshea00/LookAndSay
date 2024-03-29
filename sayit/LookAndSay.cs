﻿using System;
using System.Text;

namespace sayit
{
    public class LookAndSay
    {
        protected static (int,char) NextSequence(string str)
        {
            if (string.IsNullOrEmpty(str))
                return (0,'\0');
            var lastChar = str[0];
            var count = 0;
            for (var i = 0; i < str.Length; i++)
            {
                if (str[i] == lastChar)
                    count++;
                else
                    break;
            }
            return (count, lastChar); 
        }

        protected static string ExpandSequence(string str)
        {
            var sb = new StringBuilder();
            var next = 0;
            var (count, ch) = NextSequence(str);
            while (count != 0)
            {
                sb.Append($"{count}{ch}");
                (count, ch) = NextSequence(str.Substring(next += count));
            }
            return sb.ToString();
        }

        public static string Say(int startDigit, int nthTerm)
        {
            var sequence = $"{startDigit}";
            for (var i=1; i < nthTerm; i++)
            {
                sequence = ExpandSequence(sequence);
            }
            return sequence;
        }
    }
    
}