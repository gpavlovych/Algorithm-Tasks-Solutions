namespace Task41
{
    using System.Collections.Generic;

    /// <summary>
    /// Convert unsinged long to string, given putchar only
    /// </summary>
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
