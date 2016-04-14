namespace Task55Tests
{
    using System;

    using BaseTests.Tests;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Task55;

    [TestClass]
    public class SolverTests: UnitTestBase
    {
        private void ToUpperTest(string input)
        {
            //arrange
            var expectedResult = input.ToUpper();

            //act
            var result = Solver.ToUpper(input);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ToUpperTestNonEmpty()
        {
            this.ToUpperTest("SomeTest");
        }

        [TestMethod]
        public void ToUpperTestEmpty()
        {
            this.ToUpperTest("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToUpperTestNull()
        {
            Solver.ToUpper(null);
        }
    }
}
