using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task60
{
    /// <summary>
    /// 60. An array of integers of size n. Generate a random permutation of the array, given a function 
    /// rand_n() that returns an integer between 1 and n, both inclusive, 
    /// with equal probability.What is the expected time of your algorithm?
    /// </summary>
    public static class Solver
    {
        public static void Permutate(int[] input, Func<int, int> rand_n)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            if (rand_n == null)
            {
                throw new ArgumentNullException("rand_n");
            }
            int n = input.Length;
            while (n > 1)
            {
                n--;
                int i = rand_n(n + 1) - 1;
                int temp = input[ i ];
                input[ i ] = input[ n ];
                input[ n ] = temp;
            }
        }
    }
}
