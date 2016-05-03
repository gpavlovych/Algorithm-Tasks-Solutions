using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task73.Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void IsPalindromeTestToyot()
        {
            Assert.IsTrue(Solver.IsPalindrome("toyot"));
        }

        [TestMethod]
        public void IsPalindromeTestToyota()
        {
            Assert.IsFalse(Solver.IsPalindrome("toyota"));
        }

        [TestMethod]
        public void IsPalindromeTestMam()
        {
            Assert.IsTrue(Solver.IsPalindrome("mam"));
        }

        [TestMethod]
        public void IsPalindromeTestMm()
        {
            Assert.IsTrue(Solver.IsPalindrome("mm"));
        }

        [TestMethod]
        public void IsPalindromeTestA()
        {
            Assert.IsTrue(Solver.IsPalindrome("a"));
        }

        [TestMethod]
        public void IsPalindromeTestAb()
        {
            Assert.IsFalse(Solver.IsPalindrome("ab"));
        }

        [TestMethod]
        public void IsPalindromeTestEmpty()
        {
            Assert.IsTrue(Solver.IsPalindrome(""));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsPalindromeTestNull()
        {
            Solver.IsPalindrome(null);
        }
    }
}