using BaseTests.Tests;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Week1.Tests
{
    [TestClass]
    public class Task42Tests : UnitTestBase
    {
        [TestMethod]
        public void IsPowerOf2TestTrue()
        {
            //act
            var value = Task42.IsPowerOf2(128);

            //assert
            Assert.IsTrue(value);
        }

        [TestMethod]
        public void IsPowerOf2TestZeroFalse()
        {
            //act
            var value = Task42.IsPowerOf2(0);

            //assert
            Assert.IsFalse(value);
        }

        [TestMethod]
        public void IsPowerOf2TestOneTrue()
        {
            //act
            var value = Task42.IsPowerOf2(1);

            //assert
            Assert.IsTrue(value);
        }

        [TestMethod]
        public void IsPowerOf2TestFalsePositive()
        {
            //act
            var value = Task42.IsPowerOf2(231);

            //assert
            Assert.IsFalse(value);
        }

        [TestMethod]
        public void IsPowerOf2TestFalseNegative()
        {
            //act
            var value = Task42.IsPowerOf2(-321);

            //assert
            Assert.IsFalse(value);
        }
    }
}