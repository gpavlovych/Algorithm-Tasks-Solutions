using System;
using GreaterSumPairs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreaterSumPairsTests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CountPairsGreaterSumNull()
        {
            CountPairsGreaterSum(0, null, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CountPairsGreaterSumUnsorted()
        {
            CountPairsGreaterSum(0, new int[] { 2, 1, 3 }, 0);
        }

        [TestMethod]
        public void CountPairsGreaterSumAscending()
        {
            CountPairsGreaterSum(3, new int[] { 1, 2, 3 }, 0);
        }

        [TestMethod]
        public void CountPairsGreaterSumDescending()
        {
            CountPairsGreaterSum(3, new int[] { 3, 2, 1 }, 0);
        }

        [TestMethod]
        public void CountPairsGreaterSumAscending2()
        {
            CountPairsGreaterSum(11, new int[] { -2, 1, 4, 6, 8, 10 }, 6);
        }

        [TestMethod]
        public void CountPairsGreaterSumDescending2()
        {
            CountPairsGreaterSum(11, new int[] { 10, 8, 6, 4, 1, -2 }, 6);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CountPairsGreaterSumHashSetNull()
        {
            CountPairsGreaterSum(0, null, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CountPairsGreaterSumHashSetUnsorted()
        {
            CountPairsGreaterSumHashSet(0, new int[] { 2, 1, 3 }, 0);
        }

        [TestMethod]
        public void CountPairsGreaterSumHashSetAscending()
        {
            CountPairsGreaterSumHashSet(3, new int[] { 1, 2, 3 }, 0);
        }

        [TestMethod]
        public void CountPairsGreaterSumHashSetDescending()
        {
            CountPairsGreaterSumHashSet(3, new int[] { 3, 2, 1 }, 0);
        }

        [TestMethod]
        public void CountPairsGreaterSumHashSetAscending2()
        {
            CountPairsGreaterSumHashSet(11, new int[] { -2, 1, 4, 6, 8, 10 }, 6);
        }

        [TestMethod]
        public void CountPairsGreaterSumHashSetDescending2()
        {
            CountPairsGreaterSumHashSet(11, new int[] { 10, 8, 6, 4, 1, -2 }, 6);
        }

        private static void CountPairsGreaterSum(int expectedOutput, int[] input, int number)
        {
            // act 
            var result = Solver.CountPairsGreaterSum(input, number);

            // assert
            Assert.AreEqual(expectedOutput, result);
        }

        private static void CountPairsGreaterSumHashSet(int expectedOutput, int[] input, int number)
        {
            // act 
            var result = Solver.CountPairsGreaterSumHashSet(input, number);

            // assert
            Assert.AreEqual(expectedOutput, result);
        }
    }
}
