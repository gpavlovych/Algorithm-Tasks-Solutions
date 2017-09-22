using System;
using System.CodeDom;
using System.Runtime.ExceptionServices;

namespace Task1
{
    /// <summary>
    /// 1. Given f(n) = n⁄2, when n is even and f(n)=f(3n+1), when n is odd. Write recursive function to compute f(n).
    /// </summary>
    public static class Solver
    {
        public static int RecFunc(int n)
        {
            if (n % 2 != 0)
            {
                //n is odd,
                //downstream n will become even (always, 3n+1 for even number, even number can be represented as n=2k+1, where k is integer => 3(2k+1)+1 = 6k+4 - always even)
                return RecFunc(3 * n + 1);
            }

            return n / 2;
        }

        public static int PlainFunc(int n)
        {
            if (n % 2 != 0)
            {
                //n is odd,
                //downstream n will become even
                return (3 * n + 1)/2;
            }

            return n / 2;
        }
    }
}