using System;

namespace Task72
{
    /// <summary>
    /// 72.Given a 2-D array, which consists of words. Write, efficient code for generation of permutations using an iterative and recursive algorithms.e.g.
    /// {{white, red, green},{black, grey, blue},{pink, yellow, navy}} ->
    /// {{white, black, pink},{white, black, yellow}, etc.
    /// </summary>
    public static class Solver
    {
        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        private static void PermutateRecursively(string[,] input, int k, Action<string[,]> display)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            if (k == input.Length)
            {
                if (display != null)
                {
                    display(input);
                }
            }
            else
            {
                var columnCount = input.GetLength(1);
                for (var j = k; j < input.Length; j++)
                {
                    Swap(ref input[k / columnCount, k % columnCount], ref input[j / columnCount, j % columnCount]);
                    PermutateRecursively(input, k + 1, display);
                    Swap(ref input[k / columnCount, k % columnCount], ref input[j / columnCount, j % columnCount]);
                }
            }
        }

        public static void PermutateIteratively(string[,] input, Action<string[,]> display)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            var p = new int[input.Length];
            for (var pIndex = 0; pIndex < p.Length; pIndex++)
            {
                p[ pIndex ] = 0;
            }
            if (display != null)
            {
                display(input);
            }

            int i = 1; // setup first swap points to be 1 and 0 respectively (i & j)
            var columnCount = input.GetLength(1);
            while (i < input.Length)
            {
                if (p[ i ] < i)
                {
                    int j = i % 2 * p[ i ]; // if i is odd then j = p[i] otherwise j = 0
                    Swap(ref input[ i / columnCount, i % columnCount ], ref input[ j / columnCount, j % columnCount ]);
                    if (display != null)
                    {
                        display(input);
                    }
                    p[ i ]++; // increase index "weight" for i by one
                    i = 1; // reset index i to 1 (assumed)
                }
                else
                {
                    // otherwise p[i] == i
                    p[ i ] = 0; // reset p[i] to zero
                    i++; // set new index value for i (increase by one)
                }
            }
        }

        public static void PermutateRecursively(string[,] input, Action<string[,]> display)
        {
            PermutateRecursively(input, 0, display);
        }
    }
}