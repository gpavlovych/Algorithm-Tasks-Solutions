using System;

namespace Task61
{
    /// <summary>
    /// 61.An array of pointers to (very long) strings. Find pointers to the (lexicographically) smallest and largest strings.
    /// </summary>
    public static class Solver
    {
        public static void FindMinMax(string[] input, out string min, out string max)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            if (input.Length == 0)
            {
                throw new ArgumentException("input should not be empty");
            }
            for (var index = 0; index < input.Length; index++)
            {
                if (input[index] == null)
                {
                    throw new ArgumentException(string.Format("input[{0}] should not be null", index));
                }
            }
            min = input[0];
            max = input[0];
            for (var index = 1; index < input.Length; index++)
            {
                var currentString = input[index];
                if (string.Compare(currentString, max, StringComparison.Ordinal) > 0)
                {
                    max = currentString;
                }
                if (string.Compare(currentString, min, StringComparison.Ordinal) < 0)
                {
                    min = currentString;
                }
            }
        }
    }
}
