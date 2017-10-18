using System;
using System.Collections.Generic;

namespace Task69
{
    /// <summary>
    /// 69. Compute the discrete log of an unsigned integer.
    /// </summary>
    public static class Solver
    {
        public static int DiscreteLog(int a, int b)
        {
            if (a <= 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (b <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            int m = b;
            int n = (int) Math.Sqrt(m) + 1;

            int an = 1;
            for (int i = 0; i < n; ++i)
                an = ( an * a ) % m;

            Dictionary<int, int> vals = new Dictionary<int, int>();
            for (int i = 1,
                     cur = an;
                 i <= n;
                 ++i)
            {
                if (!vals.ContainsKey(cur))
                    vals[ cur ] = i;
                cur = ( cur * an ) % m;
            }

            for (int i = 0,
                     cur = b;
                 i <= n;
                 ++i)
            {
                if (vals.ContainsKey(cur))
                {
                    int ans = vals[ cur ] * n - i;
                    if (ans < m)
                        return ans;
                }
                cur = ( cur * a ) % m;
            }

            //if not found - less optimal algorithm is applied
            var result = 0;
            while (b >= a)
            {
                b /= a;
                result++;
            }
            return result;
        }
    }
}
