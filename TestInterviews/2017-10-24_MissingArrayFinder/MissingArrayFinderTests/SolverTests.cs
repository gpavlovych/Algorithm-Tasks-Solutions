using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MissingArrayFinder;

namespace MissingArrayFinderTests
{
    [TestClass]
    public class SolutionTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindMinimumNullTest()
        {
            FindMinimumTest(0, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindMinimumEmptyTest()
        {
            FindMinimumTest(0, new int[] { });
        }

        [TestMethod]
        public void FindMinimumSingleTest()
        {
            FindMinimumTest(0, new int[] { 1 });
        }

        [TestMethod]
        public void FindMinimumNegativeTest()
        {
            FindMinimumTest(-5, new int[] { -4, -3, -2, -1 });
        }

        [TestMethod]
        public void FindMinimumPositiveTest()
        {
            FindMinimumTest(0, new int[] { 1, 2, 3, 4, 5 });
        }

        [TestMethod]
        public void FindMinimumMissingNumbersTest()
        {
            FindMinimumTest(-16, new int[] { -1, 3, 5, -17, 25 });
        }

        [TestMethod]
        public void FindMinimumMissingNumbers2Test()
        {
            FindMinimumTest(-14, new int[] { -1, -15, 3, 5, -17, -16, 25 });
        }

        private static void FindMinimumTest(int expectedOutput, int[] input)
        {
            // act
            var actualOutput = Solver.FindMinimum(input);

            // assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindMinimumSortedSortedNullTest()
        {
            FindMinimumSortedTest(0, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindMinimumSortedEmptyTest()
        {
            FindMinimumSortedTest(0, new int[] { });
        }

        [TestMethod]
        public void FindMinimumSortedSingleTest()
        {
            FindMinimumSortedTest(0, new int[] { 1 });
        }

        [TestMethod]
        public void FindMinimumSortedNegativeTest()
        {
            FindMinimumSortedTest(-5, new int[] { -4, -3, -2, -1 });
        }

        [TestMethod]
        public void FindMinimumSortedPositiveTest()
        {
            FindMinimumSortedTest(0, new int[] { 1, 2, 3, 4, 5 });
        }

        [TestMethod]
        public void FindMinimumSortedMissingNumbersTest()
        {
            FindMinimumSortedTest(-16, new int[] { -1, 3, 5, -17, 25 });
        }

        [TestMethod]
        public void FindMinimumSortedMissingNumbers2Test()
        {
            FindMinimumSortedTest(-14, new int[] { -1, -15, 3, 5, -17, -16, 25 });
        }

        private static void FindMinimumSortedTest(int expectedOutput, int[] input)
        {
            // act
            var actualOutput = Solver.FindMinimumSorted(input);

            // assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}