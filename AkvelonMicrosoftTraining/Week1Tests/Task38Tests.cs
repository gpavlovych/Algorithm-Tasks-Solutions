namespace Week1.Tests
{
    using System;

    using BaseTests.Tests;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Task38Tests: UnitTestBase
    {
        [TestMethod]
        public void FindMaximumSubarrayTest()
        {
            //arrange
            var input = new double[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            var expectedOutput = new double[] { 4, -1, 2, 1 };

            //act
            var actualOutput = Task38.FindMaximumSubarray(input);

            //assert
            AssertCollectionsEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void FindMaximumSubarrayTestEmptyValue()
        {
            //arrange
            var input = new double[] { };
            var expectedOutput = new double[] { };

            //act
            var actualOutput = Task38.FindMaximumSubarray(input);

            //assert
            AssertCollectionsEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindMaximumSubarrayTestNullValue()
        {
            //act
            Task38.FindMaximumSubarray(null);
        }
    }
}