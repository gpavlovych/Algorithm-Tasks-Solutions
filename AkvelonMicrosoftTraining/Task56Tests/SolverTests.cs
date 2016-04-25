using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BaseTests.Tests;

namespace Task56.Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void FindDuplicatesTest()
        {
            //act
            var result = Solver.FindDuplicates(
                new[]
                    {
                        1,
                        1,
                        2,
                        2,
                        3,
                        5,
                        5
                    });

            //assert
            TestHelper.AssertCollectionsEqual(
                new[]
                    {
                        1,
                        2,
                        5
                    },
                result);
        }

        [TestMethod]
        public void FindDuplicatesTestNoDuplicates()
        {
            //act
            var result = Solver.FindDuplicates(
                new[]
                    {
                        1,
                        2,
                        3,
                        5
                    });

            //assert
            TestHelper.AssertCollectionsEqual(new int[] {}, result);
        }

        [TestMethod]
        public void FindDuplicatesTestSingleItem()
        {
            //act
            var result = Solver.FindDuplicates(
                new[]
                    {
                        1
                    });

            //assert
            TestHelper.AssertCollectionsEqual(new int[] { }, result);
        }

        [TestMethod]
        public void FindDuplicatesTestEmpty()
        {
            //act
            var result = Solver.FindDuplicates(
                new int[]
                    {
                    });

            //assert
            TestHelper.AssertCollectionsEqual(new int[] { }, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindDuplicatesTestNotSorted()
        {
            foreach (var source in Solver.FindDuplicates(
                new[]
                    {
                        1,
                        2,
                        3,
                        4,
                        3
                    }))
            {
                
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindDuplicatesTestNull()
        {
            foreach (var source in Solver.FindDuplicates(null))
            {
                
            }
        }
    }
}