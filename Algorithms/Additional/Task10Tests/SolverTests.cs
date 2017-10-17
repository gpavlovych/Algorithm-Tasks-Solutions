using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task10;

namespace Task10Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetCombinationsGivingSumNull()
        {
            // act
            Solver.GetCombinationsGivingSum(null, 6);
        }

        [TestMethod]
        public void GetCombinationsGivingSumEmpty()
        {
            // act
            var result = Solver.GetCombinationsGivingSum(new int[] {}, 6);


            // assert
            AssertJaggedArraysEquivalent(new int[][] { }, result);
        }

        [TestMethod]
        public void GetCombinationsGivingSum2()
        {
            // act
            var result = Solver.GetCombinationsGivingSum(new int[] { 7, 1, 2, 3, 4, 5 }, 9);

            // assert
            AssertJaggedArraysEquivalent(new int[2][] { new int[] { 5, 4 }, new int[] { 2, 7 },  }, result);
        }

        [TestMethod]
        public void GetCombinationsGivingSum1()
        {
            // act
            var result = Solver.GetCombinationsGivingSum(new int[] { 7, 1, 2, 3, 4, 5 }, 3);

            // assert
            AssertJaggedArraysEquivalent(new int[][] { new int[] { 2, 1 } }, result);
        }

        [TestMethod]
        public void GetCombinationsGivingSumNone()
        {
            // act
            var result = Solver.GetCombinationsGivingSum(new int[] { 7, 1, 2, 3, 4, 5 }, 900);

            // assert
            AssertJaggedArraysEquivalent(new int[][] { }, result);
        }

        private static void AssertJaggedArraysEquivalent<T>(T[][] expected, T[][] actual)
        {
            Assert.AreEqual(expected.Length, actual.Length);
            for (var index = 0; index < expected.Length; index++)
            {
                var expectedItem = expected[index];
                var actualItem = actual[index];
                CollectionAssert.AreEqual(expectedItem, actualItem);
            }
        }
    }
}
