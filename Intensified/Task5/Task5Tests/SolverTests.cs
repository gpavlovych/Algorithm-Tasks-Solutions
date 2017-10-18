using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task5;

namespace Task5Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DigitsCountTestNegativeK()
        {
            this.DigitsCountTest(0, -1, new int[] { });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DigitsCountTestKMoreThan9()
        {
            this.DigitsCountTest(0, 10, new int[] { });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DigitsCountTestNumbersNull()
        {
            this.DigitsCountTest(0, 0, null);
        }

        [TestMethod]
        public void DigitsCountTestNumbersEmpty()
        {
            this.DigitsCountTest(0, 0, new int[] { });
        }

        [TestMethod]
        public void DigitsCountTestNumbersSingle()
        {
            this.DigitsCountTest(1, 0, new int[] {0});
        }

        [TestMethod]
        public void DigitsCountTestNumbersSingleOne()
        {
            this.DigitsCountTest(1, 1, new int[] { 1 });
        }

        [TestMethod]
        public void DigitsCountTestNumbersDouble()
        {
            this.DigitsCountTest(2, 1, new int[] { 1, 10 });
        }

        [TestMethod]
        public void DigitsCountTestNumbersNone()
        {
            this.DigitsCountTest(0, 1, new int[] { 2, 2440 });
        }

        [TestMethod]
        public void DigitsCountTestNumbersZeroNone()
        {
            this.DigitsCountTest(0, 0, new int[] { 2, 244 });
        }

        [TestMethod]
        public void DigitsCountTestNumbersZeroDouble()
        {
            this.DigitsCountTest(2, 0, new int[] { 0, 10 });
        }

        private void DigitsCountTest(int expectedCount, int k, int[] numbers)
        {
            // act
            var result = Solver.DigitsCount(k, numbers);

            // assert
            Assert.AreEqual(expectedCount, result);
        }
    }
}