using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Task62.Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void RemoveDuplicatesTestDescending()
        {
            RemoveDuplicatesTest(
                new[]
                    {
                        3,
                        2,
                        1
                    });
        }

        [TestMethod]
        public void RemoveDuplicatesTestAscending()
        {
            RemoveDuplicatesTest(
                new[]
                    {
                        1,
                        2,
                        3
                    });
        }

        [TestMethod]
        public void RemoveDuplicatesTestAllThesame()
        {
            RemoveDuplicatesTest(
                new[]
                    {
                        2,
                        2,
                        2,
                        2,
                        2
                    });
        }

        [TestMethod]
        public void RemoveDuplicatesTestDuplicates()
        {
            RemoveDuplicatesTest(
                new[]
                    {
                        2,
                        2,
                        2,
                        2,
                        2,
                        3,
                        3,
                        3,
                        3,
                        5
                    });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveDuplicatesTestNotSorted()
        {
            Solver.RemoveDuplicates(
                new int[]
                    {
                        2,
                        2,
                        2,
                        2,
                        3,
                        2
                    });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveDuplicatesTestNotSorted2()
        {
            Solver.RemoveDuplicates(
                new int[]
                    {
                        2,
                        2,
                        2,
                        2,
                        3,
                        3,
                        3,
                        3,
                        3,
                        3,
                        3,
                        3,
                        2,
                        2,
                        2,
                        2,
                        2,
                        1,
                        2,
                        2,
                        3,
                        2
                    });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveDuplicatesTestNull()
        {
            Solver.RemoveDuplicates(null);
        }

        private static void RemoveDuplicatesTest(int[] initialInput)
        {
            var input = (int[]) initialInput.Clone();
            var expectedOutput = initialInput.Distinct().ToArray();

            //act
            var length = Solver.RemoveDuplicates(input);

            //assert
            Assert.AreEqual(expectedOutput.Length, length);
            for (var i = 0; i < length; i++)
            {
                Assert.AreEqual(expectedOutput[ i ], input[ i ]);
            }
        }
    }
}