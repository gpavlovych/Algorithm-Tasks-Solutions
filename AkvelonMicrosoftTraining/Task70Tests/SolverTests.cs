using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task70.Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void ClearHighestSignificantBitTest()
        {
            Assert.AreEqual(0x7FFFFFFFu, Solver.ClearHighestSignificantBit(0xFFFFFFFFu));
        }

        [TestMethod]
        public void ClearHighestSignificantBitTestAlreadyClear()
        {
            Assert.AreEqual(0x7FFFFFFFu, Solver.ClearHighestSignificantBit(0x7FFFFFFFu));
        }

        [TestMethod]
        public void ClearHighestSignificantBitTestZero()
        {
            Assert.AreEqual(0u, Solver.ClearHighestSignificantBit(0u));
        }
    }
}