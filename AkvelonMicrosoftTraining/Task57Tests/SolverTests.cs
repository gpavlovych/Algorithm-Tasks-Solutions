using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BaseTests.Tests;

namespace Task57.Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void SortTest()
        {
            //arrange
            var input = new[]
                            {
                                1,
                                5,
                                4,
                                2,
                                3,
                                1
                            };

            //act
            Solver.Sort(input, 5);

            //assert
            TestHelper.AssertCollectionsEqual(
                new[]
                    {
                        1,
                        1,
                        2,
                        3,
                        4,
                        5
                    },
                input);
        }

        [TestMethod]
        public void SortTestDuplicatedItems()
        {
            //arrange
            var input = new[]
                            {
                                1,
                                1,
                                1,
                                1
                            };

            //act
            Solver.Sort(input, 1);

            //assert
            TestHelper.AssertCollectionsEqual(
                new[]
                    {
                        1,
                        1,
                        1,
                        1
                    },
                input);
        }

        [TestMethod]
        public void SortTestSingleItem()
        {
            //arrange
            var input = new[]
                            {
                                1
                            };

            //act
            Solver.Sort(input, 1);

            //assert
            TestHelper.AssertCollectionsEqual(
                new[]
                    {
                        1
                    },
                input);
        }

        [TestMethod]
        public void SortTestEmpty()
        {
            //arrange
            var input = new int[]
                            {
                            };

            //act
            Solver.Sort(input, 1);

            //assert
            TestHelper.AssertCollectionsEqual(
                new int[]
                    {
                    },
                input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortTestNullInput()
        {
            Solver.Sort(null, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SortTestKZero()
        {
            //arrange
            var input = new[]
                            {
                                1
                            };

            //act
            Solver.Sort(input, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SortTestKBelowZero()
        {
            //arrange
            var input = new[]
                            {
                                1
                            };

            //act
            Solver.Sort(input, -10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortTestArrayItemsExceedK()
        {
            //arrange
            var input = new[]
                            {
                                3
                            };

            //act
            Solver.Sort(input, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortTestArrayItemsZero()
        {
            //arrange
            var input = new[]
                            {
                                0
                            };

            //act
            Solver.Sort(input, 2);
        }
    }
}