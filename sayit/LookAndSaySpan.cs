using System;
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

        protected static string ExpandSequence(ReadOnlySpan<char> str)
        {
            var sb = new StringBuilder(1000);
            var next = 0; 
            var (count, ch) = NextSequence(str);
            while (count != 0)
            {
                sb.Append($"{count}{ch}");
                (count, ch) = NextSequence(str.Slice(next+=count));
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