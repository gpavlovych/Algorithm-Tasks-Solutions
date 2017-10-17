namespace Task51Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Task51;

    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void DeleteAndCleanTest()
        {
            //arrange
            var s1 = "Hello1";
            var s2 = "Hello2";

            //act
            var result = Solver.DeleteAndClean(s1, s2);

            //assert
            Assert.AreEqual("2", result);
        }

        [TestMethod]
        public void DeleteAndCleanTestSameStrings()
        {
            //arrange
            var s1 = "Hello1";
            var s2 = "Hello1";

            //act
            var result = Solver.DeleteAndClean(s1, s2);

            //assert
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void DeleteAndCleanTestEmptyStringS2()
        {
            //arrange
            var s1 = "Hello1";
            var s2 = "";

            //act
            var result = Solver.DeleteAndClean(s1, s2);

            //assert
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void DeleteAndCleanTestEmptyStringS1()
        {
            //arrange
            var s1 = "";
            var s2 = "Hello1";

            //act
            var result = Solver.DeleteAndClean(s1, s2);

            //assert
            Assert.AreEqual("Hello1", result);
        }

        [TestMethod]
        public void DeleteAndCleanTestEmptyStringsBoth()
        {
            //arrange
            var s1 = "";
            var s2 = "";

            //act
            var result = Solver.DeleteAndClean(s1, s2);

            //assert
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void DeleteAndCleanTestNullStringsBoth()
        {
            //arrange
            string s1 = null;
            string s2 = null;

            //act
            var result = Solver.DeleteAndClean(s1, s2);

            //assert
            Assert.AreEqual("", result);
        }
    }
}
