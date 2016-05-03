using System;

namespace Task73
{
    /// <summary>
    /// 73. Check string for palindrome. Palindrome is: mam, toyot, mm, a and so on. 
    /// The string you can read in both directions.
    /// </summary>
    public static class Solver
    {
        public static bool IsPalindrome(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            var result = true;
            for (var i = 0; i < input.Length / 2; i++)
            {
                if (input[ i ] != input[ input.Length - i -1])
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
    }
}
