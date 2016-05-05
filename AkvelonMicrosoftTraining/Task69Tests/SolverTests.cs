using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Task69.Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void DiscreteLogTestBase10Argument11()
        {
            Assert.AreEqual(1, Solver.DiscreteLog(10, 11));
        }

        [TestMethod]
        public void DiscreteLogTestBase10Argument9()
        {
            Assert.AreEqual(0, Solver.DiscreteLog(10, 9));
        }

        [TestMethod]
        public void DiscreteLogTestBase10Argument1()
        {
            Assert.AreEqual(0, Solver.DiscreteLog(10, 1));
        }

        [TestMethod]
        public void DiscreteLogTestBase2Argument35()
        {
            Assert.AreEqual(5, Solver.DiscreteLog(2, 35));
        }

        [TestMethod]
        public void DiscreteLogTestBase2Argument32()
        {
            Assert.AreEqual(5, Solver.DiscreteLog(2, 32));
        }

        [TestMethod]
        public void DiscreteLogTestBase2Argument4()
        {
            Assert.AreEqual(2, Solver.DiscreteLog(2, 4));
        }

        [TestMethod]
        public void DiscreteLogTestBase2Argument3()
        {
            Assert.AreEqual(1, Solver.DiscreteLog(2, 3));
        }

        [TestMethod]
        public void DiscreteLogTestBase2Argument2()
        {
            Assert.AreEqual(1, Solver.DiscreteLog(2, 2));
        }

        [TestMethod]
        public void DiscreteLogTestBase2Argument1()
        {
            Assert.AreEqual(0, Solver.DiscreteLog(2, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DiscreteLogTestResult0()
        {
            Assert.AreEqual(0, Solver.DiscreteLog(2, 0));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DiscreteLogTestBase1()
        {
            Assert.AreEqual(0, Solver.DiscreteLog(1, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DiscreteLogTestBase0()
        {
            Assert.AreEqual(0, Solver.DiscreteLog(0, 1));
        }
    }
}