using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task8;

namespace Task8Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void IsSortableByExchanging2ItemsTestFalseEmpty()
        {
            // arrange
            var input = new int[] { };

            // act
            var result = Solver.IsSortableBySwapping(input);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsSortableByExchanging2ItemsTestNull()
        {
            // act
            Solver.IsSortableBySwapping(null);
        }

        [TestMethod]
        public void IsSortableByExchanging2ItemsTestTrue()
        {
            // arrange
            var input = new int[] { 1, 5, 3, 3, 2, 6 };

            // act
            var result = Solver.IsSortableBySwapping(input);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsSortableByExchanging2ItemsTestFalse()
        {
            // arrange
            var input = new int[] { 1, 5, 3, 3, -1, 6 };

            // act
            var result = Solver.IsSortableBySwapping(input);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsSortableByExchanging2ItemsTestAlreadySortedFalse()
        {
            // arrange
            var input = new int[] { 1, 2, 3, 3, 5, 6 };

            // act
            var result = Solver.IsSortableBySwapping(input);

            // assert
            Assert.IsFalse(result);
        }
    }
}
