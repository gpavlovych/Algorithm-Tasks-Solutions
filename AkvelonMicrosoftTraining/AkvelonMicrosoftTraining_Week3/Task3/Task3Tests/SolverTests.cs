using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3;

namespace Task3Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void PowerTest_1_0_1()
        {

            Assert.AreEqual(1, Solver.Power(1, 0));
        }

        [TestMethod]
        public void PowerTest_1_1_1()
        {

            Assert.AreEqual(1, Solver.Power(1, 1));
        }

        [TestMethod]
        public void PowerTest_2_1_2()
        {

            Assert.AreEqual(2, Solver.Power(2, 1));
        }

        [TestMethod]
        public void PowerTest_2_10_1024()
        {

            Assert.AreEqual(1024, Solver.Power(2, 10));
        }
    }
}