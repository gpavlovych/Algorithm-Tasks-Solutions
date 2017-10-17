using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Task74.Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void FindItemMoreN2TestTripleSame()
        {
            Assert.AreEqual(
                1,
                Solver.FindItemMoreN2(
                    new int[]
                        {
                            1,
                            1,
                            1
                        }));
        }

        [TestMethod]
        public void FindItemMoreN2TestTripleMajority()
        {
            Assert.AreEqual(
                1,
                Solver.FindItemMoreN2(
                    new int[]
                        {
                            1,
                            1,
                            2
                        }));
        }

        [TestMethod]
        public void FindItemMoreN2TestTripleUnique()
        {
            Assert.IsNull(
                Solver.FindItemMoreN2(
                    new int[]
                        {
                            1,
                            2,
                            3
                        }));
        }

        [TestMethod]
        public void FindItemMoreN2TestDoubleSame()
        {
            Assert.AreEqual(
                1,
                Solver.FindItemMoreN2(
                    new int[]
                        {
                            1,
                            1
                        }));
        }

        [TestMethod]
        public void FindItemMoreN2TestDoubleUnique()
        {
            Assert.IsNull(
                Solver.FindItemMoreN2(
                    new int[]
                        {
                            1,
                            2
                        }));
        }

        [TestMethod]
        public void FindItemMoreN2TestSingle()
        {
            Assert.AreEqual(
                3,
                Solver.FindItemMoreN2(
                    new int[]
                        {
                            3
                        }));
        }

        [TestMethod]
        public void FindItemMoreN2TestEmpty()
        {
            Assert.IsNull(
                Solver.FindItemMoreN2(
                    new int[]
                        {
                        }));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindItemMoreN2TestNull()
        {
            Solver.FindItemMoreN2(null);
        }
    }
}