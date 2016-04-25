using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Task58.Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void ExistDuplicatesTestExistDuplicates()
        {
            //arrange
            var input = new int[]
                            {
                                1,
                                2,
                                4,
                                2
                            };

            //act
            var result = Solver.ExistDuplicates(input);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ExistDuplicatesTestNoDuplicates()
        {
            //arrange
            var input = new int[]
                            {
                                1,
                                2,
                                4,
                                3
                            };

            //act
            var result = Solver.ExistDuplicates(input);

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ExistDuplicatesTestEmpty()
        {
            //arrange
            var input = new int[]
                            {
                            };

            //act
            var result = Solver.ExistDuplicates(input);

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExistDuplicatesTestNull()
        {
            Solver.ExistDuplicates(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExistDuplicatesTestItemBelow1()
        {
            Solver.ExistDuplicates(
                new int[]
                    {
                        0
                    });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExistDuplicatesTestItemExceedsLength()
        {
            Solver.ExistDuplicates(
                new int[]
                    {
                        2
                    });
        }
    }
}