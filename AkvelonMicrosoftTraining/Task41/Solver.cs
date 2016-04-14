namespace Task41
{
    using System.Collections.Generic;

    /// <summary>
    /// Given only putchar (no sprintf, itoa, etc.) write a routine putlong that prints out an unsigned long in decimal.
    /// </summary>
    /// <remarks>Convert ulong to a sequence of chars.</remarks>
    public static class Solver
    {
        public static IEnumerable<char> PutLong(ulong number)
        {
            if (number == 0)
            {
                yield return '0';
                yield break;
            }
            var stack = new Stack<char>();
            while (number != 0)
            {
                stack.Push((char)(number % 10 + (byte)'0'));
                number /= 10;
            }
            while (stack.Count > 0)
            {
                yield return stack.Pop();
            }
        }
    }
}
