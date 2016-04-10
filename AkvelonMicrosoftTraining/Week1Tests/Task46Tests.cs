using BaseTests.Tests;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Week1.Tests
{
    [TestClass]
    public class Task46Tests : UnitTestBase
    {
        private void MultiplyBy7Test(int value)
        {
            //arrange
            var expectedResult = value * 7;

            //act
            var actualResult = Task46.MultiplyBy7(value);

            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Multiply0By7Test()
        {
            MultiplyBy7Test(0);
        }

        [TestMethod]
        public void Multiply9By7Test()
        {
            MultiplyBy7Test(9);
        }

        [TestMethod]
        public void MultiplyMinus19By7Test()
        {
            MultiplyBy7Test(-19);
        }
    }
}