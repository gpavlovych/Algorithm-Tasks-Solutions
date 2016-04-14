namespace Task38Tests
{
    using System;

    using BaseTests.Tests;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Task38;

    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void FindMaximumSubarrayTest()
        {
            //arrange
            var input = new double[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            var expectedOutput = new double[] { 4, -1, 2, 1 };

            //act
            var actualOutput = Solver.FindMaximumSubarray(input);

            //assert
            TestHelper.AssertCollectionsEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void FindMaximumSubarrayTestEmptyValue()
        {
            //arrange
            var input = new double[] { };
            var expectedOutput = new double[] { };

            //act
            var actualOutput = Solver.FindMaximumSubarray(input);

            //assert
            TestHelper.AssertCollectionsEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindMaximumSubarrayTestNullValue()
        {
            //act
            Solver.FindMaximumSubarray(null);
        }
    }
}