namespace Week1
{
    using System;

    /// <summary>
    /// Maximum subarray problem implementation: solve with O(N) complexity
    /// </summary>
    public static class Task38
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
            var maxEndingHere = 0.0;
            var maxSoFar = 0.0;
            var startIndex = 0;
            var maxSoFarIndex = 0;
            for (var i = 0; i < input.Length; i++)
            {
                if (maxEndingHere == 0.0)
                {
                    startIndex = i;
                }
                var newValue = maxEndingHere + input[i];
                if (newValue > 0)
                {
                    maxEndingHere = newValue;
                }
                else
                {
                    maxEndingHere = 0;
                }
                if (maxSoFar < maxEndingHere)
                {
                    maxSoFarIndex = i;
                    maxSoFar = maxEndingHere;
                }
            }
            var result = new double[maxSoFarIndex - startIndex + 1];
            for (var i = startIndex; i <= maxSoFarIndex; i++)
            {
                result[i - startIndex] = input[i];
            }
            return result;
        }
    }
}
