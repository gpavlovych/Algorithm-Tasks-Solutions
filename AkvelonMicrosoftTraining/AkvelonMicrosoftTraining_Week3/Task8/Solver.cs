using System;

namespace Task8
{
    /// <summary>
    /// 8. Given an array with elements check if you can get a sorted array by exchanging only 2 elements of the original array.
    /// Notes for task: complexity restriction - O(nlogn) or less; memory restriction - 2n.
    /// </summary>
    /// <remarks>
    /// Ask the following questions:
    /// array size limitations? array item types?sort order? what to do with the empty input?
    /// </remarks>
    public static class Solver
    {
        public static bool IsSortableBySwapping(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            int leftIndex = FindLeftIndex(input);
            int rightIndex = FindRightIndex(input);
            if (leftIndex == rightIndex || leftIndex == -1 || rightIndex == -1)
            {
                return false; // check these edge cases just to be on safe side.
            }

            var temp = input[leftIndex];
            input[leftIndex] = input[rightIndex];
            input[rightIndex] = temp;

            return IsSorted(input);
        }

        private static int FindRightIndex(int[] a)
        {
            for (int i = a.Length - 1; i >= 1; i--)
            {
                if (a[i - 1] > a[i])
                {
                    return i;
                }
            }
            return -1;
        }

        private static int FindLeftIndex(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                if (a[i] > a[i + 1])
                {
                    return i;
                }
            }
            return -1;
        }

        private static bool IsSorted(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                if (a[i] > a[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
