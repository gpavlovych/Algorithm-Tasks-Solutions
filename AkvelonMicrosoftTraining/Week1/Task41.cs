using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1
{
    /// <summary>
    /// Convert unsinged long to string, given putchar only
    /// </summary>
    public static class Task41
    {
        public static string PutLong(ulong number)
        {
            if (number == 0)
            {
                return "0";
            }
            var result = new StringBuilder();
            var stack = new Stack<char>();
            while (number != 0)
            {
                stack.Push((char)(number % 10 + (byte)'0'));
                number /= 10;
            }
            while (stack.Count > 0)
            {
                result.Append(stack.Pop());
            }
            return result.ToString();
        }
    }
}
