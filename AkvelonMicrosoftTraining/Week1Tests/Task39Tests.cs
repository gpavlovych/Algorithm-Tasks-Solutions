namespace Week1.Tests
{
    using BaseTests.Tests;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Task39Tests: UnitTestBase
    {
        [TestMethod]
        public void TestSolve()
        {
            //arrange
            var input = new[] { 1, 1, 2, 3, 2 };
            var expectedOutput = new[]
                                     {
                                         new Task39.Duplicate() { Index = 1, Value = 1 },
                                         new Task39.Duplicate() { Index = 4, Value = 2 }
                                     };

            //act
            var result = Task39.Solve(input);

            //assert
            AssertCollectionsEqual(expectedOutput, result);
        }
    }
}