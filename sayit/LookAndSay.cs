using System;
using System.Text;

namespace sayit
{
    public class LookAndSay
    {
        public static (string,string) NextSequence(string str)
        {
            if (string.IsNullOrEmpty(str))
                return ("","");
            var lastChar = str[0];
            var count = 0;
            for (var i = 0; i < str.Length; i++)
            {
                if (str[i] == lastChar)
                    count++;
                else
                    break;
            }
            return (count.ToString() + lastChar.ToString(),str.Substring(count)); 
        }

        public static string ExpandSequence(string str)
        {
            var sb = new StringBuilder();
            var (next, tail) = NextSequence(str);
            sb.Append(next);
            while (!string.IsNullOrEmpty(tail))
            {
                (next, tail) = NextSequence(tail);
                sb.Append(next);
            }
            return sb.ToString();
        }

        public static string Say(int startDigit, int nthTerm)
        {
            var sequence = startDigit.ToString();
            for (var i=1; i < nthTerm; i++)
            {
                sequence = ExpandSequence(sequence);
            }
            return sequence;
        }
    }
    
}