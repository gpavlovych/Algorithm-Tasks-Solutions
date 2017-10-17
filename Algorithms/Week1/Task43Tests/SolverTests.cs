namespace Task43Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Task43;

    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void ReverseWordsTest()
        {
            //arrange
            char[] input = "very good words choice counts a lot".ToCharArray();
            char[] expectedArray = "lot a counts choice words good very".ToCharArray();

            //act
            Solver.ReverseWords(input);

            //assert
            CollectionAssert.AreEqual(expectedArray, input);
        }

        [TestMethod]
        public void ReverseWordsTestSingleWord()
        {
            //arrange
            char[] input = "very".ToCharArray();
            char[] expectedArray = "very".ToCharArray();

            //act
            Solver.ReverseWords(input);

            //assert
            CollectionAssert.AreEqual(expectedArray, input);
        }

        [TestMethod]
        public void ReverseWordsTestEmpty()
        {
            //arrange
            char[] input = "".ToCharArray();
            char[] expectedArray = "".ToCharArray();

            //act
            Solver.ReverseWords(input);

            //assert
            CollectionAssert.AreEqual(expectedArray, input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReverseWordsTestNull()
        {
            //act
            Solver.ReverseWords(null);
        }
    }
}