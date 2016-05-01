using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Task61.Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void FindMinMaxTestDoubleItems()
        {
            //arrange
            string min;
            string max;

            //act
            Solver.FindMinMax(
                new string[]
                    {
                        "aaa",
                        "aba"
                    },
                out min,
                out max);

            //assert
            Assert.AreEqual("aaa", min);
            Assert.AreEqual("aba", max);
        }

        [TestMethod]
        public void FindMinMaxTestSingleItem()
        {
            string min;
            string max;
            Solver.FindMinMax(new string[] { "some" }, out min, out max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindMinMaxTestSingleNullItem()
        {
            string min;
            string max;
            Solver.FindMinMax(
                new string[]
                    {
                        null
                    },
                out min,
                out max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindMinMaxTestDoubleNullItem()
        {
            string min;
            string max;
            Solver.FindMinMax(
                new string[]
                    {
                        null,
                        null
                    },
                out min,
                out max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindMinMaxTestEmpty()
        {
            string min;
            string max;
            Solver.FindMinMax(new string[] { }, out min, out max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindMinMaxTestNull()
        {
            string min;
            string max;
            Solver.FindMinMax(null, out min, out max);
        }
    }
}