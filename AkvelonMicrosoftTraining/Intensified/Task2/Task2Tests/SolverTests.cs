using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;

namespace Task2Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetMaxPalindromeByRemoveOrShuffleTestNull()
        {
            this.GetMaxPalindromeByRemoveOrShuffleTest("", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetMaxPalindromeByRemoveOrShuffleTestInvalidCharacter()
        {
            this.GetMaxPalindromeByRemoveOrShuffleTest("", "A");
        }

        [TestMethod]
        public void GetMaxPalindromeByRemoveOrShuffleTestEmpty()
        {
            this.GetMaxPalindromeByRemoveOrShuffleTest("", "");
        }

        [TestMethod]
        public void GetMaxPalindromeByRemoveOrShuffleTestNoActionNeededEven()
        {
            this.GetMaxPalindromeByRemoveOrShuffleTest("aaaa", "aaaa");
        }

        [TestMethod]
        public void GetMaxPalindromeByRemoveOrShuffleTestNoActionNeededOdd()
        {
            this.GetMaxPalindromeByRemoveOrShuffleTest("aaaaa", "aaaaa");
        }

        [TestMethod]
        public void GetMaxPalindromeByRemoveOrShuffleTestNoActionNeededEvenDifferentChars()
        {
            this.GetMaxPalindromeByRemoveOrShuffleTest("abba", "abba");
        }

        [TestMethod]
        public void GetMaxPalindromeByRemoveOrShuffleTestNoActionNeededOddDifferentChars()
        {
            this.GetMaxPalindromeByRemoveOrShuffleTest("ababa", "ababa");
        }

        [TestMethod]
        public void GetMaxPalindromeByRemoveOrShuffleTestShuffleNeededEvenDifferentChars()
        {
            this.GetMaxPalindromeByRemoveOrShuffleTest("abba", "baba");
        }

        [TestMethod]
        public void GetMaxPalindromeByRemoveOrShuffleTestShuffleNeededOddDifferentChars()
        {
            this.GetMaxPalindromeByRemoveOrShuffleTest("ababa", "baaba");
        }

        [TestMethod]
        public void GetMaxPalindromeByRemoveOrShuffleTestShuffleNeededMoreEvenDifferentChars()
        {
            this.GetMaxPalindromeByRemoveOrShuffleTest("abccdccba", "aabcbcbdcc");
        }

        [TestMethod]
        public void GetMaxPalindromeByRemoveOrShuffleTestRemoveNeededOddDifferentChars()
        {
            this.GetMaxPalindromeByRemoveOrShuffleTest("abczcba", "abzcdabca");
        }

        private void GetMaxPalindromeByRemoveOrShuffleTest(string expectedResult, string arg)
        {
            //act
            var result = Solver.GetMaxPalindromeByRemoveOrShuffle(arg);

            //assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}