using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Task56.Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void FindDuplicatesTest()
        {
            FindTest(
                new[]
                    {
                        1,
                        2,
                        5
                    },
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
        }

        [TestMethod]
        public void FindDuplicatesTestNoDuplicates()
        {
            FindTest(new int[] { }, new[]
            {
                1,
                2,
                3,
                5
            });
        }

        [TestMethod]
        public void FindDuplicatesTestSingleItem()
        {
            FindTest(new int[] { }, new int[] { 1 });
        }

        [TestMethod]
        public void FindDuplicatesTestEmpty()
        {
            FindTest(new int[] { }, new int[] { });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindDuplicatesTestNotSorted()
        {

            FindTest(new int[] { }, new[]
            {
                1,
                2,
                3,
                4,
                3
            });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindDuplicatesTestNull()
        {
            FindTest(new int[]{}, null);
        }

        private static void FindTest(int[] expectedResult, int[] argument)
        {
            // act
            var result = Solver.FindDuplicates(argument);

            // assert
            CollectionAssert.AreEqual(expectedResult, ToArray(result));
        }

        private static T[] ToArray<T>(IEnumerable<T> input)
        {
            var count = 0;
            foreach (var inputItem in input)
            {
                count++;
            }

            var result = new T[count];
            var index = 0;
            foreach (var inputItem in input)
            {
                result[index++] = inputItem;
            }

            return result;
        }
    }
}