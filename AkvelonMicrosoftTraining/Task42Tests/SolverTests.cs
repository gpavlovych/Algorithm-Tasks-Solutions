namespace Task42Tests
{
    using BaseTests.Tests;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Task42;

    [TestClass]
    public class SolverTests : UnitTestBase
    {
        [TestMethod]
        public void IsPowerOf2TestTrue()
        {
            //act
            var value = Solver.IsPowerOf2(128);

            //assert
            Assert.IsTrue(value);
        }

        [TestMethod]
        public void IsPowerOf2TestZeroFalse()
        {
            //act
            var value = Solver.IsPowerOf2(0);

            //assert
            Assert.IsFalse(value);
        }

        [TestMethod]
        public void IsPowerOf2TestOneTrue()
        {
            //act
            var value = Solver.IsPowerOf2(1);

            //assert
            Assert.IsTrue(value);
        }

        [TestMethod]
        public void IsPowerOf2TestFalsePositive()
        {
            //act
            var value = Solver.IsPowerOf2(231);

            //assert
            Assert.IsFalse(value);
        }

        [TestMethod]
        public void IsPowerOf2TestFalseNegative()
        {
            //act
            var value = Solver.IsPowerOf2(-321);

            //assert
            Assert.IsFalse(value);
        }
    }
}