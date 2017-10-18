using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3;

namespace Task3Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindMedianNullTest()
        {
            this.FindMedianTest(-1, null);
        }

        [TestMethod]
        public void FindMedianEmptyTest()
        {
            this.FindMedianTest(-1, new int[] { });
        }

        [TestMethod]
        public void FindMedianSingleTest()
        {
            this.FindMedianTest(-1, new int[] {0});
        }

        [TestMethod]
        public void FindMedianDoubleNonEqualTest()
        {
            this.FindMedianTest(-1, new int[] {0, 1});
        }

        [TestMethod]
        public void FindMedianDoubleEqualTest()
        {
            this.FindMedianTest(0, new int[] {1, 1});
        }

        [TestMethod]
        public void FindMedianMultipleNegativeTest()
        {
            this.FindMedianTest(-1, new int[] {1, 0, -11, 1, 12});
        }

        [TestMethod]
        public void FindMedianMultiplePositiveTest()
        {
            this.FindMedianTest(1, new int[] { 1, 0, -11, 12 });
        }

        private void FindMedianTest(int expected, int[] inputs)
        {
            // act
            var result = Solver.FindMedian(inputs);

            // assert
            Assert.AreEqual(expected, result);
        }
    }
}