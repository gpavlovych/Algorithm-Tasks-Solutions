using System;

namespace MissingArrayFinder
{
    /// <summary>
    /// Given an array with random integer numbers find a minimum number which is not present in array. 
    /// For example, { -1, 3, 5, -17, 25} the answer is -16,  
    /// { -1, -15, 3, 5, -17, -16, 25 } = &gt; { -17, -16, -15, -1, 3, 5, 25 } = &gt; -14
    /// </summary>
    /// <remarks>Dictionary/HashTable can't be used!</remarks>
    public static class Solver
    {
        /// <summary>
        /// Implementation using bool array, w/o modifying original, additional space complexity is O(max-min), time complexity is O(N)
        /// </summary>
        /// <param name="input">Input array</param>
        public static int FindMinimum(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (input.Length == 0)
            {
                throw new ArgumentException("input should not be em");
            }

            var min = input[0];
            var max = input[0];
            for (var inputIndex = 1; inputIndex < input.Length; inputIndex++)
            {
                var current = input[inputIndex];
                if (max < current)
                {
                    max = current;
                }

                if (min > current)
                {
                    min = current;
                }
            }

            var presenceLength = max - min + 1;
            var presence = new bool[presenceLength];

            for (var inputIndex = 0; inputIndex < input.Length; inputIndex++)
            {
                var current = input[inputIndex];
                presence[current - min] = true;
            }

            var maxIndex = -1;
            for (var presenceIndex = 1; presenceIndex < presence.Length - 1; presenceIndex++)
            {
                if (!presence[presenceIndex])
                {
                    maxIndex = presenceIndex;
                    break;
                }
            }

            return maxIndex + min;
        }

        /// <summary>
        /// Implementation using sorted array, modifying original (sorting is necessary), additional space complexity is O(1), time complexity is O(N*N) - the worst case
        /// </summary>
        /// <param name="input">Input array</param>
        public static int FindMinimumSorted(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (input.Length == 0)
            {
                throw new ArgumentException("input should not be em");
            }


            Sort(input);

            var result = input[0] - 1;
            for (var inputIndex = 0; inputIndex < input.Length - 1; inputIndex++)
            {
                var current = input[inputIndex];
                var next = input[inputIndex + 1];
                if (next - current >= 2)
                {
                    result = current + 1;
                    return result;
                }
            }

            return result;
        }

        /// <summary>
        /// Sorts the provided array (using bubble sort).
        /// </summary>
        /// <param name="input">Input array</param>
        private static void Sort(int[] input)
        {
            for (var leftIndex = 0; leftIndex < input.Length - 1; leftIndex++)
            {
                for (var rightIndex = leftIndex + 1; rightIndex < input.Length; rightIndex++)
                {
                    if (input[leftIndex] <= input[rightIndex])
                    {
                        continue;
                    }

                    var temp = input[leftIndex];
                    input[leftIndex] = input[rightIndex];
                    input[rightIndex] = temp;
                }
            }
        }
    }
}
