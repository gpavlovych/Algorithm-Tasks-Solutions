using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task7;

namespace Task7Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SolverTestNull()
        {
            SolverTest("Not Possible", null);
        }

        [TestMethod]
        public void SolverTestEmpty()
        {
            SolverTest("Possible", new int[] { });
        }

        [TestMethod]
        public void SolverTestSingle()
        {
            SolverTest("Possible", new int[] {1});
        }

        [TestMethod]
        public void SolverTestSorted()
        {
            SolverTest("Possible", new int[] {1, 2});
        }

        [TestMethod]
        public void SolverTestSortedDescending()
        {
            SolverTest("Possible", new int[] { 2, 1 });
        }

        [TestMethod]
        public void SolverTestImpossible()
        {
            SolverTest("Not Possible", new int[] { 2, 1, 3});
        }

        [TestMethod]
        public void SolverTestLongerPossible()
        {
            SolverTest("Possible", new int[] { 1, 2, 5, 4, 3, 6, 7 });
        }

        [TestMethod]
        public void SolverTestLongerImpossible()
        {
            SolverTest("Not Possible", new int[] { 1, 3, 2, 4, 5, 6, 7 });
        }

        private void SolverTest(string expectedResult, int[] input)
        {
            // act
            var result = Solver.CanBeSortedByReverse(input);

            // assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}