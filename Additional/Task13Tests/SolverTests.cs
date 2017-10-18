using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task13;

namespace Task13Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetCollapsedStringTestNull()
        {
            // act
            Solver.GetCollapsedString(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetCollapsedStringTestInvalidInputs()
        {
            // arrange
            var input = "aaabzzzAaafff";

            // act
            Solver.GetCollapsedString(input);
        }

        [TestMethod]
        public void GetCollapsedStringTest()
        {
            // arrange
            var input = "aaabzzzaafff";

            // act
            var result = Solver.GetCollapsedString(input);

            // assert
            Assert.AreEqual("3a1b3z2a3f", result);
        }

        [TestMethod]
        public void GetCollapsedStringTestEmpty()
        {
            // arrange
            var input = "";

            // act
            var result = Solver.GetCollapsedString(input);

            // assert
            Assert.AreEqual("", result);
        }
    }
}
