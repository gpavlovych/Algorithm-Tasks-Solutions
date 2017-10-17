using System;
using GreaterNumbersFinder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreaterNumbersFinderTests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindGreaterNumbersTestNullArg()
        {
            this.FindGreaterNumbersTest(null, null);
        }

        [TestMethod]
        public void FindGreaterNumbersTestEmpty()
        {
            this.FindGreaterNumbersTest(new int[]{}, new int[]{});
        }

        [TestMethod]
        public void FindGreaterNumbersTestSingle()
        {
            this.FindGreaterNumbersTest(new int[]{0}, new int[]{1});
        }
        
        [TestMethod]
        public void FindGreaterNumbersTestDoubleAscending()
        {
            this.FindGreaterNumbersTest(new int[]{1, 0}, new int[]{1, 2});
        }

        [TestMethod]
        public void FindGreaterNumbersTestDoubleDescending()
        {
            this.FindGreaterNumbersTest(new int[]{0, 0}, new int[]{3, 2});
        }

        [TestMethod]
        public void FindGreaterNumbersTest()
        {
            this.FindGreaterNumbersTest(new int[]{3, 3, 0, 0, 1, 0}, new int[]{5, 3, 9, 8, 2, 6});
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindGreaterNumbersRecTestNullArg()
        {
            this.FindGreaterNumbersRecTest(null, null);
        }

        [TestMethod]
        public void FindGreaterNumbersRecTestEmpty()
        {
            this.FindGreaterNumbersRecTest(new int[] { }, new int[] { });
        }

        [TestMethod]
        public void FindGreaterNumbersRecTestSingle()
        {
            this.FindGreaterNumbersRecTest(new int[] { 0 }, new int[] { 1 });
        }

        [TestMethod]
        public void FindGreaterNumbersRecTestDoubleAscending()
        {
            this.FindGreaterNumbersRecTest(new int[] { 1, 0 }, new int[] { 1, 2 });
        }

        [TestMethod]
        public void FindGreaterNumbersRecTestDoubleDescending()
        {
            this.FindGreaterNumbersRecTest(new int[] { 0, 0 }, new int[] { 3, 2 });
        }

        [TestMethod]
        public void FindGreaterNumbersRecTest()
        {
            this.FindGreaterNumbersRecTest(new int[] { 3, 3, 0, 0, 1, 0 }, new int[] { 5, 3, 9, 8, 2, 6 });
        }

        private void FindGreaterNumbersTest(int [] expectedOutput, int [] input)
        {
            // act
            Solver.FindGreaterNumbers(input);
            
            // assert
            CollectionAssert.AreEquivalent(expectedOutput, input);
        }

        private void FindGreaterNumbersRecTest(int[] expectedOutput, int[] input)
        {
            // act
            Solver.FindGreaterNumbersRec(input);

            // assert
            CollectionAssert.AreEquivalent(expectedOutput, input);
        }
    }
}