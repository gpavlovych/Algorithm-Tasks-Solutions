using System;
using System.CodeDom;
using System.Runtime.ExceptionServices;

namespace Task6
{
    /// <summary>
    /// 6. Given two positive floating point numbers (x,y), calculate x/y to within a specified epsilon
    /// without using in-built functions.
    /// </summary>
    /// <remarks>Taylor sum</remarks>
    public static class Solver
    {
        public static float Divide(float x, float y, float epsilon)
        {
            if (x <= epsilon)
            {
                throw new ArgumentOutOfRangeException(nameof(x), "x should be positive");
            }

            if (y <= epsilon)
            {
                throw new ArgumentOutOfRangeException(nameof(y), "y should be positive");
            }

            float result1 = 0;
            float result2 = x * y;
            while (Abs(result1 - result2) > epsilon)
            {
                float m = (result1 + result2) * (float)0.5;
                float c = m * y - x;
                if (c < 0)
                {
                    result1 = m;
                }
                else
                {
                    result2 = m;
                }
            }
            return result1;
        }

        private static float Abs(float x)
        {
            if (x >= 0)
            {
                return x;
            }

            return -x;
        }
    }
}