using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BaseTests.Tests;

namespace Task60.Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void Permutate10ItemsSame()
        {
            GenerateAndTestPermutateTestArray(
                10,
                i => 2,
                10,
                (index, expectedArray, actualArray) =>CollectionAssert.AreEqual(expectedArray, actualArray));
        }

        [TestMethod]
        public void Permutate10ItemsUnique()
        {
            GenerateAndTestPermutateTestArray(
                10,
                i => i,
                10,
                (index, expectedArray, actualArray) => TestHelper.AssertCollectionsNotEqual(expectedArray, actualArray));
        }

        [TestMethod]
        public void PermutateSingleItem()
        {
            GenerateAndTestPermutateTestArray(
                1,
                i => i,
                10,
                (index, expectedArray, actualArray) =>CollectionAssert.AreEqual(expectedArray, actualArray));
        }

        [TestMethod]
        public void PermutateEmptyArray()
        {
            GenerateAndTestPermutateTestArray(
                0,
                i => i,
                10,
                (index, expectedArray, actualArray) =>CollectionAssert.AreEqual(expectedArray, actualArray));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PermutateTestArrayNull()
        {
            Solver.Permutate(null);
        }

        private static void GenerateAndTestPermutateTestArray(
            int numberOfItems,
            Func<int, int> item,
            int numberOfPermutations,
            Action<int, int[], int[]> assertions)
        {
            //arrange
            var initialInput = new int[numberOfItems];
            for (var i = 0; i < numberOfItems; i++)
            {
                initialInput[ i ] = item(i);
            }

            var input = (int[]) initialInput.Clone();

            for (var i = 0; i < numberOfPermutations; i++)
            {
                //act
                Solver.Permutate(input);

                //assert
                assertions(i, initialInput, input);
            }
        }
    }
}