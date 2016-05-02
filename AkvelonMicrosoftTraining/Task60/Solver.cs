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
    /// <remarks>Implement your own rand_n function giving [1..n] value with equal probability.</remarks>
    public static class Solver
    {
        private static ulong _sNext = (ulong)DateTime.UtcNow.Ticks;

        private const ulong A = 1103515245;

        private const ulong C = 12345;

        private static uint Rand(uint maxRand)
        {
            _sNext = _sNext * A + C;
            return 1u + (uint)(_sNext / 65536) % maxRand;
        }

        public static void Permutate(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            uint n = (uint)input.Length;
            while (n > 1)
            {
                n--;
                uint i = Rand(n + 1u) - 1u;
                int temp = input[ i ];
                input[ i ] = input[ n ];
                input[ n ] = temp;
            }
        }
    }
}
