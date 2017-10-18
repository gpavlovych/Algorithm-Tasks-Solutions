namespace Task46Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Task46;

    [TestClass]
    public class SolverTests
    {
        private void MultiplyBy7Test(int value)
        {
            //arrange
            var expectedResult = value * 7;

            //act
            var actualResult = Solver.MultiplyBy7(value);

            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Multiply0By7Test()
        {
            this.MultiplyBy7Test(0);
        }

        [TestMethod]
        public void Multiply9By7Test()
        {
            this.MultiplyBy7Test(9);
        }

        [TestMethod]
        public void MultiplyMinus19By7Test()
        {
            this.MultiplyBy7Test(-19);
        }
    }
}