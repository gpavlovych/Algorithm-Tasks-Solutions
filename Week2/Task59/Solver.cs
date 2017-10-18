using System;

namespace Task59
{
    /// <summary>
    /// 59.An array of integers. The sum of the array is known not to overflow an integer. Compute the sum. 
    /// What if we know that integers are in 2's complement form?
    /// </summary>
    public static class Solver
    {
        public static uint ComputeSum(uint[] items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            uint sum = 0;
            for (var i = 0; i < items.Length; i++)
            {
                sum += items[ i ];
                if (sum < items[ i ])
                {
                    throw new OverflowException();
                }
            }

            return sum;
        }

        public static int ComputeSum(int[] items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            int sum = 0;
            for (var i = 0; i < items.Length; i++)
            {
                var signPositive = ( sum > 0 && items[ i ] > 0 );
                var signNegative = ( sum < 0 && items[ i ] < 0 );
                sum += items[ i ];

                if (( signPositive && ( sum <= 0 ) ) || ( signNegative && ( sum >= 0 ) ))
                {
                    throw new OverflowException();
                }
            }

            return sum;
        }
    }
}
