using System;

namespace Task3
{
    /// <summary>
    /// 3. Write a function to calculate x in the power of y.
    /// </summary>
    /// <remarks>TODO put here answers of additional questions which help successfully solve the task.</remarks>
    public static class Solver
    {
        public static float Power(float input, int n)
        {
            var result = 1.0f;
            var p = 1;
            while (n != 0)
            {
                var t = n % 2;
                n = n / 2;
                if (t == 1)
                {
                    result *= input;
                }
                input *= input;
            }
            return result;
        }
    }
}
