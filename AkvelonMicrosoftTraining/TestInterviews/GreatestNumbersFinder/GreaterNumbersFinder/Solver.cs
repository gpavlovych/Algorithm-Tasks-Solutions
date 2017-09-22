using System;
using System.Collections.Generic;

namespace GreaterNumbersFinder
{
    /// <summary>
    /// How to find total number of greater number after all number in an array ? 
    /// Eg. Given array is, 
    /// 5 3 9 8 2 6 
    /// o/p 
    /// 3 3 0 0 1 0
    /// </summary>
    /// <remarks>Dictionary/HashTable can't be used!</remarks>
    public static class Solver
    {    
        /// <summary>
        /// Implementation w/o using .NET generic structures, space complexity is O(1), time complexity is O(N^2)
        /// </summary>
        public static void FindGreaterNumbers(int[] input)
        {
            if (input == null)
            {    
                throw new ArgumentNullException(nameof(input));
            }
            
            for (var currentIndex = 0; currentIndex < input.Length; currentIndex++)
            {
                var currentItem = input[currentIndex];
                input[currentIndex] = 0;
                for (var nextIndex = currentIndex + 1; nextIndex < input.Length; nextIndex++)
                {
                     var nextItem = input[nextIndex];
                     if (currentItem < nextItem)
                     {
                         input[currentIndex]++;
                     }                
                }
            }
        }

        /// <summary>
        /// More sophisticated/efficient solution with the time complexity O(n log n)
        /// </summary>
        /// <param name="input"></param>
        public static void FindGreaterNumbersRec(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            
            for (var currentIndex = 0; currentIndex < input.Length; currentIndex++)
            {
                input[currentIndex] = CountLarger(input, input[currentIndex], currentIndex + 1,
                    input.Length - currentIndex - 1);
            }
        }

        private static int CountLarger(int[] input, int number, int start, int length)
        {
            if (length == 0)
            {
                return 0;
            }

            if (length == 1)
            {
                return number < input[start] ? 1 : 0;
            }

            var halfLength = length / 2;
            return CountLarger(input, number, start, halfLength) + CountLarger(input, number, start + halfLength, length - halfLength);
        }
    }
}