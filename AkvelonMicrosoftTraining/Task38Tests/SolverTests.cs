namespace Task38Tests
{
    using System;

    using BaseTests.Tests;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Task38;

    [TestClass]
    public class SolverTests
    {
        /// <summary>
        /// Finds the subarray having maximal sum if there exist multiple subarrays with the same sum. Algorithm should return first one
        /// </summary>
        [TestMethod]
        public void FindMaximumSubarrayTestNumbersEquivalent()
        {
            //arrange
            var input = new double[] { 3, 3, -6, 2, 2, 2 };
            var expectedOutput = new double[] { 3, 3 };

            //act
            var actualOutput = Solver.FindMaximumSubarray(input);

            //assert
            TestHelper.AssertCollectionsEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void FindMaximumSubarrayTestOnlyNegativeValuesMultiplePositiveAmongNegative()
        {
            //arrange
            var input = new double[] { -3, 2, -5, 2, -4 };
            var expectedOutput = new double[] { 2 };

            //act
            var actualOutput = Solver.FindMaximumSubarray(input);

            //assert
            TestHelper.AssertCollectionsEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void FindMaximumSubarrayTestOnlyNegativeValuesMultipleMax()
        {
            //arrange
            var input = new double[] { -3, -2, -5, -2, -4 };
            var expectedOutput = new double[] { -2 };

            //act
            var actualOutput = Solver.FindMaximumSubarray(input);

            //assert
            TestHelper.AssertCollectionsEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void FindMaximumSubarrayTestOnlyNegativeValuesMiddleMax()
        {
            //arrange
            var input = new double[] { -3, -5, -2, -4};
            var expectedOutput = new double[] { -2 };

            //act
            var actualOutput = Solver.FindMaximumSubarray(input);

            //assert
            TestHelper.AssertCollectionsEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void FindMaximumSubarrayTestOnlyNegativeValuesLastMax()
        {
            //arrange
            var input = new double[] { -3, -5, -4, -2};
            var expectedOutput = new double[] { -2 };

            //act
            var actualOutput = Solver.FindMaximumSubarray(input);

            //assert
            TestHelper.AssertCollectionsEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void FindMaximumSubarrayTestOnlyNegativeValues()
        {
            //arrange
            var input = new double[] { -2, -3, -5, -4 };
            var expectedOutput = new double[] { -2 };

            //act
            var actualOutput = Solver.FindMaximumSubarray(input);

            //assert
            TestHelper.AssertCollectionsEqual(expectedOutput, actualOutput);
        }

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