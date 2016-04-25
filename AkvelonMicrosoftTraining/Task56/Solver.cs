using System;
using System.Collections.Generic;

namespace Task56
{
    /// <summary>
    /// 56.Write, efficient code for extracting unique elements from a sorted list of array. 
    /// e.g. (1, 1, 3, 3, 3, 5, 5, 5, 9, 9, 9, 9) -> (1, 3, 5, 9).
    /// </summary>
    public static class Solver
    {
        public static IEnumerable<int> FindDuplicates(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            if (input.Length == 0)
            {
                yield break;
            }
            for (var i = 1; i < input.Length; i++)
            {
                if (input[ i - 1 ] > input[ i ])
                {
                    throw new ArgumentException("Array is not sorted");
                }
            }
            var previous = input[ 0 ];
            for (var i = 1; i < input.Length; i++)
            {
                if (previous == input[ i ])
                {
                    yield return input[i];
                }

                else
                {
                    previous = input[ i ];
                }
            }
        }
    }
}
