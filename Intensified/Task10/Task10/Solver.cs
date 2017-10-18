using System;
using System.CodeDom;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace Task10
{
    /// <summary>
    /// 10. Given a random function with equal probability of getting 1 or 0 ie 50% each. Write a custom
    /// function which uses the above random function such that your function should return 1 with 75%
    /// probability and 0 with 25% probability.
    /// </summary>
    public static class Solver
    {
        #region LCG

        private static int seed = 0;

        // the LCG parameters below are the recommended ones from literature
        private const long multiplier = 1664525;
        private const long increment = 1013904223;
        private const int modulus = int.MaxValue;

        /// <summary>
        /// Initializes the random generator
        /// </summary>
        public static void InitSeed()
        {
            seed = (int)DateTime.UtcNow.Ticks;
        }

        /// <summary>
        /// Linear congruential generator aka LCG (uniformly distributed 0 to modulus-1 values)
        /// </summary>
        /// <returns></returns>
        private static int Rand()
        {
            seed = (int)((multiplier * seed + increment) % modulus);
            return seed;
        }

        #endregion

        /// <summary>
        /// Returns 1 or 0 with 50% probability each
        /// </summary>
        /// <returns></returns>
        private static int Rand50()
        {
            return Rand() & 0x1;//or Rand()%2;
        }

        /// <summary>
        /// Returns 1 or 0 with 75% and 25% probability, respectively.
        /// </summary>
        /// <returns></returns>
        public static int Rand75()
        {
            return Rand50() | Rand50();
        }
    }
}