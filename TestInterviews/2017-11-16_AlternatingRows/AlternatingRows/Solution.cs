using System;

namespace AlternatingRows
{
    /// <summary>
    /// You should print below number sequence 
    /// If(n= 3)
    /// then 
    /// 1*2*3 
    /// 7*8*9 
    /// 4*5*6 
    /// 
    /// if n=5 
    /// 1*2*3*4*5 
    /// 11*12*13*14*15 
    /// 21*22*23*24*25 
    /// 16*17*18*19*20 
    /// 6*7*8*9*10 
    ///
    /// Can anyone also tell me what kind of pattern it is? Implement code.
    ///
    /// </summary>
    public static class Solution
    {
        /// <summary>
        /// Naive 'bruteforce' approach
        /// </summary>
        /// <param name="n">Amount of rows</param>
        public static void OutputAlternatingRows(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n), "n should be non-negative.");
            }

            for (var rowIndex = 0; rowIndex < n; rowIndex++)
            {
                var start = GetFirstNumberInRow(n, rowIndex);
                for (var columnIndex = 0; columnIndex < n; columnIndex++)
                {
                    var currentNumber = start + columnIndex;
                    Console.Write(currentNumber);
                    if (columnIndex < n - 1)
                    {
                        Console.Write("*");
                    }
                }

                Console.WriteLine();
            }
        }

        private static int GetFirstNumberInRow(int n, int rowIndex)
        {
            var start = 2 * rowIndex;
            if (rowIndex == n / 2)
            {
                start = n - 1;
            }
            else if (rowIndex > n / 2)
            {
                start = n - 1 - (rowIndex - n / 2) * 2 + n % 2;
            }

            start *= n;
            start += 1;
            return start;
        }
    }

}
