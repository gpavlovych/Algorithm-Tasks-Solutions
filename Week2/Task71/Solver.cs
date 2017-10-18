namespace Task71
{
    /// <summary>
    /// 71. Let f(k) = y where k is the y-th number in the increasing sequence of non-negative integers with 
    /// the same number of ones in its binary representation as y, e.g.f(1) = 1, f(2) = 2, f(3) = 1, f(4) = 3, f(5) = 2,
    /// f(6) = 3 and so on.Given k >= 0, compute f(k).
    /// binary/k/number of ones/y
    /// 0000 0 0 1
    /// 0001 1 1 1
    /// 0010 2 1 2
    /// 0011 3 2 1
    /// 0100 4 1 3
    /// 0101 5 2 2
    /// 0110 6 2 3
    /// 0111 7 3 1
    /// 1000 8 1 4
    /// 1001 9 2 4
    /// 1010 10 2 5
    /// 1011 11 3 2
    /// 1100 12 2 6
    /// 1101 13 3 3
    /// 1110 14 3 4
    /// 1111 15 4 1
    /// </summary>
    /// <remarks>complexity O(n log 32)</remarks>
    public static class Solver
    {
        private static uint CountOnes(uint n)
        {
            uint count = 0;
            while (n != 0)
            {
                n &= ( n - 1 );
                count++;
            }
            return count;
        }

        public static uint GetF(uint k)
        {
            uint count = 1u;
            uint numberOfOnesInK = CountOnes(k);
            for (var i = 0u; i < k; i++)
            {
                if (CountOnes(i) == numberOfOnesInK)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
