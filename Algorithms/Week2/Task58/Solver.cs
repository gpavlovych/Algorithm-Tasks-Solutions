using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task58
{
    /// <summary>
    /// 58.Given an array of length N containing integers between 1 and N, 
    /// determine if it contains any duplicates.
    /// </summary>
    public static class Solver
    {
        public static bool ExistDuplicates(int[] input)
        {
            #region Input validation

            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            for (var i = 0; i < input.Length; i++)
            {
                if (input[ i ] < 1 || input[ i ] > input.Length)
                {
                    throw new ArgumentException("Array items should be in range [1..ArrayLength]");
                }
            }

            #endregion Input validation

            for (var i = 0; i < input.Length; i++)
            {
                if (input[ Math.Abs(input[ i ]) - 1 ] > 0)
                {
                    input[ Math.Abs(input[ i ]) - 1 ] = -input[ Math.Abs(input[ i ]) - 1 ];
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}
