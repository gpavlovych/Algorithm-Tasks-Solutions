namespace Week1Tests
{
    using BaseTests.Tests;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Week1;

    [TestClass]
    public class Task41Tests : UnitTestBase
    {
        private void PutLongTest(ulong number)
        {
            //act
            var actual = Task41.PutLong(number);

            //assert
            Assert.AreEqual(number.ToString(), actual);
        }

        [TestMethod]
        public void PutLongTest1054352312400()
        {
            PutLongTest(1054352312400);
        }

        [TestMethod]
        public void PutLongTest100()
        {
            PutLongTest(100);
        }

        [TestMethod]
        public void PutLongTest10()
        {
            PutLongTest(10);
        }

        [TestMethod]
        public void PutLongTest1()
        {
            PutLongTest(1);
        }

        [TestMethod]
        public void PutLongTest0()
        {
            PutLongTest(0);
        }
    }
}
