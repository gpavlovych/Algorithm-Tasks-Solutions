using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Task57.Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void SortTest()
        {
            SortTest(new[] {1, 1, 2, 3, 4, 5}, new[] {1, 5, 4, 2, 3, 1}, 5);
        }

        [TestMethod]
        public void SortTestDuplicatedItems()
        {
            SortTest(new[] { 1, 1, 1, 1 }, new[] { 1, 1, 1, 1 }, 1);
        }

        [TestMethod]
        public void SortTestSingleItem()
        {
            SortTest(new[] { 1 }, new[] { 1 }, 1);
        }

        [TestMethod]
        public void SortTestEmpty()
        {
            SortTest(new int[] { }, new int[] { }, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortTestNullInput()
        {
            SortTest(new int[] { }, null, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SortTestKZero()
        {

            SortTest(new int[] { }, new[] {1}, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SortTestKBelowZero()
        {
            SortTest(new int[] { }, new[] { 1 }, -10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortTestArrayItemsExceedK()
        {
            SortTest(new int[] { }, new[] { 3 }, 2);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortTestArrayItemsZero()
        {

            SortTest(new int[] { }, new[] { 0 }, 2);
        }

        private static void SortTest(int[] expectedOutput, int[] input, int k)
        {
            // act
            Solver.Sort(input, k);

            // assert
            CollectionAssert.AreEqual(expectedOutput, input);
        }
    }
}