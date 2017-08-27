using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task9;

namespace Task9Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindTopOfNull()
        {
            // act
            Solver.RetrieveTopNumbers(null, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindTop3Of0()
        {
            // arrange
            var input = new int[] { };
            var top = 3;

            // act
            Solver.RetrieveTopNumbers(input, top);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindTopNegOf0()
        {
            // arrange
            var input = new int[] { };
            var top = -1;

            // act
            Solver.RetrieveTopNumbers(input, top);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindTop3Of2()
        {
            // arrange
            var input = new int[] { 22, 32 };
            var top = 3;

            // act
            Solver.RetrieveTopNumbers(input, top);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindTopNegOf2()
        {
            // arrange
            var input = new int[] { 22, 33 };
            var top = -1;

            // act
            Solver.RetrieveTopNumbers(input, top);
        }
        [TestMethod]
        public void FindTop0Of0()
        {
            // arrange
            var input = new int[] { };
            var top = 0;

            // act
            var result = Solver.RetrieveTopNumbers(input, top);

            // assert
            CollectionAssert.AreEquivalent(new int[] { }, result);
        }

        [TestMethod]
        public void FindTop0Of2()
        {
            // arrange
            var input = new int[] { 32, 21 };
            var top = 0;

            // act
            var result = Solver.RetrieveTopNumbers(input, top);

            // assert
            CollectionAssert.AreEquivalent(new int[] { }, result);
        }

        [TestMethod]
        public void FindTop3Of4()
        {
            // arrange
            var input = new int[] { 33, 2, 110, 17 };
            var top = 3;

            // act
            var result = Solver.RetrieveTopNumbers(input, top);

            // assert
            CollectionAssert.AreEquivalent(new int[] { 33, 17, 110 }, result);
        }

        [TestMethod]
        public void FindTop3Of3()
        {
            // arrange
            var input = new int[] { 33, 2, 110 };
            var top = 3;

            // act
            var result = Solver.RetrieveTopNumbers(input, top);

            // assert
            CollectionAssert.AreEquivalent(new int[] { 33, 2, 110 }, result);
        }

        [TestMethod]
        public void FindTop3Of5()
        {
            // arrange
            var input = new int[] { 33, 2, 110, 21, 17 };
            var top = 3;

            // act
            var result = Solver.RetrieveTopNumbers(input, top);

            // assert
            CollectionAssert.AreEquivalent(new int[] { 33, 21, 110 }, result);
        }
    }
}