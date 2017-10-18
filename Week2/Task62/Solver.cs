using System;
using System.Net.Http.Headers;

namespace Task62
{
    /// <summary>
    /// 62.Write a program to remove duplicates from a sorted array.
    /// </summary>
    /// <remarks>It is not allowed to change the array but it is allowed to create new one. Sort order of an input array can be both asc and desc.</remarks>
    public static class Solver
    {
        public static int[] RemoveDuplicates(int[] input)
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
                return new int[] {};
            }
            //1st pass: determine how many distinct elements we have, to initialize resulting array
            var resultLength = 1;
            for (var i = 1; i < input.Length; i++)
            {
                if (input[i-1] != input[i])
                {
                    resultLength++;
                }
            }
            var result = new int[resultLength];
            //2nd pass: fill resulting array
            var currentIndex = 1;
            result[0] = input[0];
            for (var i = 1; i < input.Length; i++)
            {
                if (input[i-1] != input[i])
                {
                    result[currentIndex] = input[i];
                    currentIndex++;
                }
            }
            return result;
        }
    }
}
