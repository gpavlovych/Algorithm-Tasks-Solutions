using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1
{
    using System.CodeDom.Compiler;
    using System.ComponentModel;

    /// <summary>
    /// Reverse words (not characters) in sentence, given by array of characters
    /// </summary>
    public static class Task43
    {
        private static void Swap(char[] a, int i, int j)
        {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        private static void ReverseSubarray(char[] a, int startIndex, int length)
        {
            for (var i = 0; i < length / 2; i++)
            {
                Swap(a, startIndex + i, startIndex + length - i - 1);
            }
        }

        public static void ReverseWords(char[] a)
        {
            ReverseSubarray(a, 0, a.Length);
            int p = 0;
            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] == ' ')
                {
                    ReverseSubarray(a, p, i - p);
                    p = i + 1;
                }
            }
            ReverseSubarray(a, p, a.Length - p);
        }
    }
}
