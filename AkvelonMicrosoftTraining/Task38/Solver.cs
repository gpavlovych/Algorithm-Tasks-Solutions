namespace Task38
{
    using System;

    /// <summary>
    /// Given an array containing both positive and negative integers and required to find the sub-array with the largest sum (O(N)).
    /// </summary>
    /// <remarks>Sub-array should be contiguous.</remarks>
    public static class Solver
    {
        public static double[] FindMaximumSubarray(double[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            if (input.Length == 0)
            {
                return new double[] {};
            }
            var maxCurrent = input[0];
            var maxSoFar = input[0];
            var startIndex = 0;
            var currentIndex = 0;
            var maxSoFarStartIndex = 0;
            var maxSoFarCurrentIndex = 0;
            for (var i = 1; i < input.Length; i++)
            {
                var newValue = maxCurrent + input[i];
                if (newValue > input[i])
                {
                    currentIndex = i;
                    maxCurrent = newValue;
                }
                else
                {
                    startIndex = i;
                    currentIndex = i;
                    maxCurrent = input[i];
                }
                if (maxSoFar < maxCurrent)
                {
                    maxSoFarStartIndex = startIndex;
                    maxSoFarCurrentIndex = currentIndex;
                    maxSoFar = maxCurrent;
                }
            }
            var result = new double[maxSoFarCurrentIndex - maxSoFarStartIndex + 1];
            for (var i = maxSoFarStartIndex; i <= maxSoFarCurrentIndex; i++)
            {
                result[i - maxSoFarStartIndex] = input[i];
            }
            return result;
            // return new [] {maxSoFar};
        }
    }
}
