using System;
using System.Collections.Generic;
using System.Text;

namespace sayit
{
    public class LookAndSaySpan
    {
        protected static (int, char) NextSequence(ReadOnlySpan<char> str)
        {
            if (str.IsEmpty)
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
            return (count,lastChar); 
        }

        protected static char[] ExpandSequence(ReadOnlySpan<char> str)
        {
            var cb = new List<char>(10000);
            var next = 0; 
            var (count, ch) = NextSequence(str);
            while (count != 0)
            {
                cb.Add(((char)('0' + count)));
                cb.Add(ch);
                (count, ch) = NextSequence(str.Slice(next+=count));
            }
            return cb.ToArray();
        }

        public static string Say(int startDigit, int nthTerm)
        {
            var sequence = new[] { ((char)('0' + startDigit)) };
            for (var i=1; i < nthTerm; i++)
            {
                sequence = ExpandSequence(sequence);
            }
            return new string(sequence);
        }
    }
    
}