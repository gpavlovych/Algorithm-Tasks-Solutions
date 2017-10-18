using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task71.Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void GetFTest0Is1()
        {
            Assert.AreEqual(1u, Solver.GetF(0x00u));
        }

        [TestMethod]
        public void GetFTest1Is1()
        {
            Assert.AreEqual(1u, Solver.GetF(0x01u));
        }

        [TestMethod]
        public void GetFTest2Is2()
        {
            Assert.AreEqual(2u, Solver.GetF(0x02u));
        }

        [TestMethod]
        public void GetFTest3Is1()
        {
            Assert.AreEqual(1u, Solver.GetF(0x03u));
        }

        [TestMethod]
        public void GetFTest4Is3()
        {
            Assert.AreEqual(3u, Solver.GetF(0x04u));
        }

        [TestMethod]
        public void GetFTest5Is2()
        {
            Assert.AreEqual(2u, Solver.GetF(0x05u));
        }

        [TestMethod]
        public void GetFTest6Is3()
        {
            Assert.AreEqual(3u, Solver.GetF(0x06u));
        }

        [TestMethod]
        public void GetFTest7Is1()
        {
            Assert.AreEqual(1u, Solver.GetF(0x07u));
        }

        [TestMethod]
        public void GetFTest8Is4()
        {
            Assert.AreEqual(4u, Solver.GetF(0x08u));
        }

        [TestMethod]
        public void GetFTest9Is4()
        {
            Assert.AreEqual(4u, Solver.GetF(0x09u));
        }

        [TestMethod]
        public void GetFTestAIs5()
        {
            Assert.AreEqual(5u, Solver.GetF(0x0Au));
        }

        [TestMethod]
        public void GetFTestBIs2()
        {
            Assert.AreEqual(2u, Solver.GetF(0x0Bu));
        }

        [TestMethod]
        public void GetFTestCIs6()
        {
            Assert.AreEqual(6u, Solver.GetF(0x0Cu));
        }

        [TestMethod]
        public void GetFTestDIs3()
        {
            Assert.AreEqual(3u, Solver.GetF(0x0Du));
        }

        [TestMethod]
        public void GetFTestEIs4()
        {
            Assert.AreEqual(4u, Solver.GetF(0x0Eu));
        }

        [TestMethod]
        public void GetFTestFIs1()
        {
            Assert.AreEqual(1u, Solver.GetF(0x0Fu));
        }
    }
}