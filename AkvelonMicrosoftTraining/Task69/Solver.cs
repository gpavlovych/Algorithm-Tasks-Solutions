using System;

namespace Task69
{
    /// <summary>
    /// 69. Compute the discrete log of an unsigned integer.
    /// </summary>
    public static class Solver
    {
        public static int DiscreteLog(uint a, ulong b)
        {
            if (a <= 1)
            {
                throw new ArgumentOutOfRangeException("a");
            }
            int k = 0;
            ulong pow = 1u;
            while (pow <= b)
            {
                pow *= a;
                k++;
            }
            return k - 1;
        }
    }
}
