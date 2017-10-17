using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4;

namespace Task4Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void FindMultipleMissingNumberNonUniqueTest()
        {
            // arrange
            var missingNumbers = new int[] { 2, 13, 23, 42, 50 };
            var numbers = new int[] { 1, 1, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 15, 16, 17, 18, 19, 20, 21, 22, 22, 22, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 40, 43, 44, 45, 46, 47, 48, 49, 55, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, };

            // act
            var result = Solver.FindMissingNumber(numbers);

            // assert
            CollectionAssert.AreEquivalent(missingNumbers, result);
        }

        [TestMethod]
        public void FindSingleMissingNumberNonUniqueTest()
        {
            // arrange
            var missingNumbers = new int[] { 2 };
            var numbers = new int[] { 1, 1, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, };

            // act
            var result = Solver.FindMissingNumber(numbers);

            // assert
            CollectionAssert.AreEquivalent(missingNumbers, result);
        }

        [TestMethod]
        public void FindMultipleMissingNumberUniqueTest()
        {
            // arrange
            var missingNumbers = new int[] { 2, 8 };
            var numbers = new int[] { 1, 3, 4, 5, 6, 7, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, };

            // act
            var result = Solver.FindMissingNumber(numbers);

            // assert
            CollectionAssert.AreEquivalent(missingNumbers, result);
        }

        [TestMethod]
        public void FindSingleMissingNumberUniqueTest()
        {
            // arrange
            var missingNumbers = new int[] { 2 };
            var numbers = new int[] { 1, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, };

            // act
            var result = Solver.FindMissingNumber(numbers);

            // assert
            CollectionAssert.AreEquivalent(missingNumbers, result);
        }

        [TestMethod]
        public void FindNoMissingNumberUniqueTest()
        {
            // arrange
            var missingNumbers = new int[] { };
            var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, };

            // act
            var result = Solver.FindMissingNumber(numbers);

            // assert
            CollectionAssert.AreEquivalent(missingNumbers, result);
        }

        [TestMethod]
        public void FindNoMissingNumberNonUniqueTest()
        {
            // arrange
            var missingNumbers = new int[] { };
            var numbers = new int[] { 1, 2, 3, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, };

            // act
            var result = Solver.FindMissingNumber(numbers);

            // assert
            CollectionAssert.AreEquivalent(missingNumbers, result);
        }

        [TestMethod]
        public void FindMissingNumberEmptyTest()
        {
            // arrange
            var missingNumbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, };
            var numbers = new int[] { };

            // act
            var result = Solver.FindMissingNumber(numbers);

            // assert
            CollectionAssert.AreEquivalent(missingNumbers, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindMissingNumberNullNumbersTest()
        {
            // act
            Solver.FindMissingNumber(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindMissingNumberTooBigNumbersTest()
        {
            // act
            Solver.FindMissingNumber(new int[] { 101 });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindMissingNumberZeroNumbersTest()
        {
            // act
            Solver.FindMissingNumber(new int[] { 0 });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindMissingNumberNegativeNumbersTest()
        {
            // act
            Solver.FindMissingNumber(new int[] { -10 });
        }
    }
}
