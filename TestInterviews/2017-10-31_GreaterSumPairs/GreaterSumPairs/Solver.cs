using System;

namespace GreaterSumPairs
{
    /// <summary>
    /// Given a sorted array and the number, find the number of sum of 2 numbers from array greater than or equal to the given number: -2, 1,4,6,8,10, sum=6
    /// </summary>
    /// <remarks>Only count is needed.</remarks>
    public static class Solver
    {
        /// <summary>
        /// Naive implementation.
        /// </summary>
        public static int CountPairsGreaterSum(int[] input, int number)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            VerifySorted(input);

            var result = 0;
            for (var leftIndex = 0; leftIndex < input.Length - 1; leftIndex++)
            {
                for (var rightIndex = leftIndex + 1; rightIndex < input.Length; rightIndex++)
                {
                    var pairSum = input[leftIndex] + input[rightIndex];
                    if (pairSum >= number)
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Efficient implementation.
        /// </summary>
        public static int CountPairsGreaterSumHashSet(int[] input, int number)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var isAscending = VerifySorted(input);
            if (!isAscending)
            {
                for (var currentIndex = 0; currentIndex < input.Length/2; currentIndex++)
                {
                    var oppositeIndex = input.Length - currentIndex - 1;
                    var currentBackup = input[currentIndex];
                    input[currentIndex] = input[oppositeIndex];
                    input[oppositeIndex] = currentBackup;
                }
            }

            var currentLeftIndex = 0;
            var currentRightIndex = input.Length - 1;
            var result = input.Length*(input.Length - 1)/2; // all possible pairs

            while (currentLeftIndex < currentRightIndex)
            {
                if (input[currentLeftIndex] + input[currentRightIndex] < number)
                {
                    result -= (currentRightIndex - currentLeftIndex);
                    currentLeftIndex++;
                }
                else
                {
                    currentRightIndex--;
                }
            }

            return result;
        }

        /// <summary>
        /// Verifies the array to be sorted in any direction. Throws <see cref="ArgumentException"/> if array is not sorted.
        /// </summary>
        private static bool VerifySorted(int[] input)
        {
            var descendingCount = 0;
            var ascendingCount = 0;
            for (var inputIndex = 0; inputIndex < input.Length - 1; inputIndex++)
            {
                var currentItem = input[inputIndex];
                var nextItem = input[inputIndex + 1];
                if (currentItem > nextItem)
                {
                    descendingCount++;
                }

                if (currentItem < nextItem)
                {
                    ascendingCount++;
                }
            }

            if (descendingCount != 0 && ascendingCount != 0)
            {
                throw new ArgumentException("input should be sorted!");
            }

            return descendingCount == 0;
        }
    }
}
