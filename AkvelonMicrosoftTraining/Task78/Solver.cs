using System.IO;

namespace Task78
{
    /// <summary>
    /// 78.Write a program that prints Fibonacci series up to N number.
    /// </summary>
    public static class Solver
    {
        public static void PrintFibonacci(TextWriter writer, int n)
        {
            var f1 = 1; // item before previous
            var f2 = 1; // previous item
            if (n >= 1)
            {
                writer.Write("{0} ", f1);
            }
            if (n >= 2)
            {
                writer.Write("{0} ", f2);
            }
            for (var i = 3; i <= n; i++)
            {
                var f = f1 + f2;
                writer.Write("{0} ", f);
                f2 = f1;
                f1 = f;
            }
        }
    }
}
