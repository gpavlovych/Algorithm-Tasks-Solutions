using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using BaseTests.Tests;

namespace Task72.Tests
{
    [TestClass]
    public class SolverTests
    {
        #region PermutateIteratively

        [TestMethod]
        public void PermutateIterativelyTest2x2()
        {
            PermutateTest(2, 2, Solver.PermutateIteratively);
        }

        [TestMethod]
        public void PermutateIterativelyTest1x2()
        {
            PermutateTest(1, 2, Solver.PermutateIteratively);
        }

        [TestMethod]
        public void PermutateIterativelyTest2x1()
        {
            PermutateTest(2, 1, Solver.PermutateIteratively);
        }

        [TestMethod]
        public void PermutateIterativelyTest1x1()
        {
            PermutateTest(1, 1, Solver.PermutateIteratively);
        }

        [TestMethod]
        public void PermutateIterativelyTestEmpty()
        {
            PermutateTest(0, 0, Solver.PermutateIteratively);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PermutateIterativelyTestNull()
        {
            Solver.PermutateIteratively(
                null,
                (permutation) =>
                    {
                    });
        }

        #endregion PermutateIteratively

        #region PermutateRecursively

        [TestMethod]
        public void PermutateRecursivelyTest2x2()
        {
            PermutateTest(2, 2, Solver.PermutateRecursively);
        }

        [TestMethod]
        public void PermutateRecursivelyTest1x2()
        {
            PermutateTest(1, 2, Solver.PermutateRecursively);
        }

        [TestMethod]
        public void PermutateRecursivelyTest2x1()
        {
            PermutateTest(2, 1, Solver.PermutateRecursively);
        }

        [TestMethod]
        public void PermutateRecursivelyTest1x1()
        {
            PermutateTest(1, 1, Solver.PermutateRecursively);
        }

        [TestMethod]
        public void PermutateRecursivelyTestEmpty()
        {
            PermutateTest(0, 0, Solver.PermutateRecursively);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PermutateRecursivelyTestNull()
        {
            Solver.PermutateRecursively(
                null,
                (permutation) =>
                    {
                    });
        }

        #endregion PermutateRecursively

        #region Helper methods

        private static void PermutateTest(int columns, int rows, Action<string[,], Action<string[,]>> permutateAction)
        {
            int number = 0;
            PermutateTest(columns, rows, (i, j) => ( ++number ).ToString(), permutateAction);
        }

        private static void PermutateTest(
            int columns,
            int rows,
            Func<int, int, string> getItem,
            Action<string[,], Action<string[,]>> permutateAction)
        {
            //arrange
            //setup input with unique values like {{"1","2"},{"3","4"}}
            var input = new string[rows, columns];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    input[ i, j ] = getItem(i, j);
                }
            }
            var initialInput = (string[,]) input.Clone();
            var numberOfItems = input.Length;
            var expectedIterationsCount = 1;
            for (var i = 1; i <= numberOfItems; i++)
            {
                expectedIterationsCount *= i;
            }
            var iterations = new List<string[,]>();

            //act
            permutateAction(
                input,
                (permutation) =>
                    {
                        iterations.Add((string[,]) permutation.Clone());
                    });

            //assert
            Assert.AreEqual(expectedIterationsCount, iterations.Count);
            TestHelper.AssertCollectionsEqual(
                initialInput.ToEnumerable<string>(),
                iterations.First().ToEnumerable<string>());
            foreach (var iteration1 in iterations)
            {
                foreach (var iteration2 in iterations)
                {
                    if (!ReferenceEquals(iteration1, iteration2))
                    {
                        //verify each permutation is different in order but the same in elements
                        TestHelper.AssertCollectionsNotEqual(
                            iteration1.ToEnumerable<string>(),
                            iteration2.ToEnumerable<string>());
                        TestHelper.AssertCollectionsEqual(
                            iteration1.ToEnumerable<string>().OrderBy(it => it),
                            iteration2.ToEnumerable<string>().OrderBy(it => it));
                    }
                }
            }
        }

        #endregion Helper methods
    }
}