namespace Task41
{
    using System;
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
                return new char[] { '0' };
            }
            int amountOfDigits = (int)Math.Truncate(Math.Log10(number)) + 1;
            char[] result = new char[amountOfDigits];
            for (var i = amountOfDigits - 1; i >= 0; i--)
            {
                result[i] = (char)(number % 10 + '0');
                number /= 10;
            }
            return result;
        }
    }
}
