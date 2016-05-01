using System;

namespace Task62
{
    /// <summary>
    /// 62.Write a program to remove duplicates from a sorted array.
    /// </summary>
    public static class Solver
    {
        public static int RemoveDuplicates(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            var index = 0;
            while (index < input.Length - 1 && input[ index ] == input[ index + 1 ])
            {
                index++;
            }
            var isAscending = index < input.Length - 1 && ( input[ index ] < input[ index + 1 ] );
            for (var i = index; i < input.Length - 1; i++)
            {
                if (isAscending ^ ( input[ i ] <= input[ i + 1 ] ))
                    //all items of an input array should satisfy input[i]<=input[i+1] (it is sorted in ascending order) 
                    //or should satisfy input[i]>=input[i+1] (descending one)
                {
                    throw new ArgumentException("Array is not sorted");
                }
            }
            if (input.Length == 0)
            {
                return 0;
            }
            var currentIndex = 0;
            for (var i = 1; i < input.Length && currentIndex < input.Length; i++)
            {
                if (input[currentIndex] != input[i])
                {
                    currentIndex++;
                    input[currentIndex] = input[i];
                }
            }
            return currentIndex + 1;
        }
    }
}
