using System;
using System.CodeDom;
using System.Runtime.ExceptionServices;

namespace Task7
{
    /// <summary>
    /// 7. Consider an array A of N integers, only permitted operation in this array to reverse the
    /// subarray of any length, where the middle index of sub array and middle index of array a are equal.You
    /// need to find whether the given array can be sorted using multiple such reverse operations: if sorting is
    /// possiable print "Possible". "Not Possible" otherwise
    /// </summary>
    public static class Solver
    {
        public static string CanBeSortedByReverse(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var sortedAscending = Copy(input);
            Sort(sortedAscending, ascending: true);
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != sortedAscending[i] && input[input.Length - 1 - i] != sortedAscending[i])
                {
                    return "Not Possible";
                }
            }

            return "Possible";
        }

        private static int[] Copy(int[] array)
        {
            var result = new int[array.Length];
            for (var arrayIndex = 0; arrayIndex < array.Length; arrayIndex++)
            {
                result[arrayIndex] = array[arrayIndex];
            }

            return result;
        }

        private static void Sort(int[] array, bool ascending)
        {
            for (var arrayLeftIndex = 0; arrayLeftIndex < array.Length - 1; arrayLeftIndex++)
            {
                for (var arrayRightIndex = arrayLeftIndex + 1; arrayRightIndex < array.Length; arrayRightIndex++)
                {
                    if (ascending ^ array[arrayLeftIndex] < array[arrayRightIndex])
                    {
                        Swap(ref array[arrayLeftIndex], ref array[arrayRightIndex]);
                    }
                }
            }
        }

        private static void Swap(ref int a, ref int b)
        {
            var temp = a;
            a = b;
            b = temp;
        }
    }
}