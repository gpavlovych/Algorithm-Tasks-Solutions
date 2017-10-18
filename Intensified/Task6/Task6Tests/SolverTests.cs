using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task6;

namespace Task6Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DivideByNegativeTest()
        {
            this.DivideTest(1, -10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DivideNegativeTest()
        {
            this.DivideTest(-10, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DivideByZeroTest()
        {
            this.DivideTest(1, 0);
        }

        [TestMethod]
        public void DivideByTwoTest()
        {
            this.DivideTest(1, 2);
        }

        [TestMethod]
        public void DivideTwoByThreeTest()
        {
            this.DivideTest(2, 3);
        }

        [TestMethod]
        public void DivideByOneTest()
        {
            this.DivideTest(1, 1);
        }

        [TestMethod]
        public void DivideThreeByFour()
        {
            this.DivideTest(3, 4);
        }

        [TestMethod]
        public void DivideFloatByFloat()
        {
            this.DivideTest((float)3.5325, (float)40.53151);
        }

        private void DivideTest(float x, float y)
        {
            // arrange
            const float epsilon = (float) 0.01;
            var expected = Math.Abs(y) > epsilon ? x / y : 0;

            // act
            var result = Solver.Divide(x, y, epsilon);

            // assert
            Assert.AreEqual(expected, result, epsilon);
        }
    }
}