using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task7;

namespace Task7Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CalculateNeg()
        {
            Calculate1sOf11PowerNTest(0, -1);
        }

        [TestMethod]
        public void CalculateValid()
        {
            Calculate1sOf11PowerNTest(1, 0);
            Calculate1sOf11PowerNTest(2, 1);
            Calculate1sOf11PowerNTest(2, 2);
            Calculate1sOf11PowerNTest(2, 3);
            Calculate1sOf11PowerNTest(2, 4);
            Calculate1sOf11PowerNTest(3, 5);
            Calculate1sOf11PowerNTest(3, 6);
            Calculate1sOf11PowerNTest(3, 7);
            Calculate1sOf11PowerNTest(2, 8);
            Calculate1sOf11PowerNTest(1, 9);
            Calculate1sOf11PowerNTest(1, 10);
            Calculate1sOf11PowerNTest(4, 11);
            Calculate1sOf11PowerNTest(2, 12);
        }

        [TestMethod]
        public void Calculate1000()
        {
            Calculate1sOf11PowerNTest(105, 1000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CalculateTooMuch()
        {
            Calculate1sOf11PowerNTest(0, 1001);
        }

        private void Calculate1sOf11PowerNTest(int expectedOnes, int number)
        {
            // act
            var result = Solver.Calculate1sOf11PowerN(number);

            // assert
            Assert.AreEqual(expectedOnes, result);
        }
    }
}
