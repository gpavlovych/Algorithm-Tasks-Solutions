using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task68.Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void ReverseBitsTest11111111()
        {
            Assert.AreEqual(0x88888888u, Solver.ReverseBits(0x11111111u));
        }
        [TestMethod]
        public void ReverseBitsTest11()
        {
            Assert.AreEqual(0x88000000u, Solver.ReverseBits(0x00000011u));
        }
        [TestMethod]
        public void ReverseBitsTest01()
        {
            Assert.AreEqual(0x80000000u, Solver.ReverseBits(0x00000001u));
        }
        [TestMethod]
        public void ReverseBitsTest00()
        {
            Assert.AreEqual(0x00000000u, Solver.ReverseBits(0x00000000u));
        }
        [TestMethod]
        public void ReverseBitsTestFF()
        {
            Assert.AreEqual(0xFF000000u, Solver.ReverseBits(0x000000FFu));
        }
        [TestMethod]
        public void ReverseBitsTestFFFFFFFF()
        {
            Assert.AreEqual(0xFFFFFFFFu, Solver.ReverseBits(0xFFFFFFFFu));
        }
    }
}