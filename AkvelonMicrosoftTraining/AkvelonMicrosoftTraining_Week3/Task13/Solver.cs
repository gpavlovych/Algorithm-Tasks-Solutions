using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task13
{
    /// <summary>
    /// 13.Given a string, entirely consisting of lowercase letters a-z, collapse runs of these characters into
    /// the number of repeats followed by the character itself.For example:
    /// Input: "aaabzzzaafff"
    /// Output: "3a1b3z2a3f".
    /// </summary>
    /// <remarks>Ask questions? Can StringBuilder be used?</remarks>
    public static class Solver
    {
        public static string GetCollapsedString(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var stringBuilder = new StringBuilder();
            var currentChar = '\0';
            var currentCount = 1;

            foreach (var c in input)
            {
                if (c < 'a' || c > 'z')
                {
                    throw new ArgumentOutOfRangeException(nameof(input),"input should contain characters a-z");
                }

                if (currentChar == c)
                {
                    currentCount++;
                }
                else
                {
                    if (currentChar != '\0')
                    {
                        stringBuilder.Append(currentCount);
                        stringBuilder.Append(currentChar);
                    }
                    currentChar = c;
                    currentCount = 1;
                }
            }

            if (currentChar != '\0')
            {
                stringBuilder.Append(currentCount);
                stringBuilder.Append(currentChar);
            }

            return stringBuilder.ToString();
        }
    }
}
