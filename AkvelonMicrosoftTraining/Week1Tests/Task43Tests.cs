using BaseTests.Tests;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Week1.Tests
{
    [TestClass]
    public class Task43Tests : UnitTestBase
    {
        [TestMethod]
        public void ReverseWordsTest()
        {
            //arrange
            char[] input = "very good words choice counts a lot".ToCharArray();
            char[] expectedArray = "lot a counts choice words good very".ToCharArray();

            //act
            Task43.ReverseWords(input);

            //assert
            AssertCollectionsEqual(expectedArray, input);
        }
    }
}