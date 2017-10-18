namespace Task41Tests
{
    using BaseTests.Tests;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Task41;

    [TestClass]
    public class SolverTests
    {
        private void PutLongTest(ulong number)
        {
            //act
            var actual = Solver.PutLong(number);

            //assert
            CollectionAssert.AreEqual(number.ToString().ToCharArray(), actual);
        }

        [TestMethod]
        public void PutLongTest1054352312400()
        {
            this.PutLongTest(1054352312400);
        }

        [TestMethod]
        public void PutLongTest100()
        {
            this.PutLongTest(100);
        }

        [TestMethod]
        public void PutLongTest10()
        {
            this.PutLongTest(10);
        }

        [TestMethod]
        public void PutLongTest1()
        {
            this.PutLongTest(1);
        }

        [TestMethod]
        public void PutLongTest0()
        {
            this.PutLongTest(0);
        }
    }
}
