using System;

namespace Task57
{
    /// <summary>
    /// 57. Sort an array of size n containing integers between 1 and K, 
    /// given a temporary scratch integer array of size K.
    /// </summary>
    public static class Solver
    {
        public static void Sort(int[] sortedArray, int k)
        {
            #region Input verification
            if (sortedArray == null)
            {
                throw new ArgumentNullException("sortedArray");
            }
            if (k < 1)
            {
                throw new ArgumentOutOfRangeException("k");
            }
            for (var i = 0; i < sortedArray.Length; i++)
            {
                if (sortedArray[ i ] < 1 || sortedArray[i] > k)
                {
                    throw new ArgumentException("Every item of an array should be in range [1..k]");
                }
            }
            #endregion Input verification

            #region Initialize temp array

            var tempArray = new int[k];
            for (var i = 0; i < k; i++)
            {
                tempArray[ i ] = 0;
            }

            #endregion Initialize temp array

            for (var i = 0; i < sortedArray.Length; i++)
            {
                tempArray[ sortedArray[ i ] - 1 ]++;
            }

            int ind = 0;
            for (var i = 0; i < k; i++)
            {
                if (tempArray[i] == 0)
                    continue;
                for (var j = 0; j < tempArray[i]; j++)
                {
                    sortedArray[ind++] = (i + 1);
                }
            }
        }
    }
}
