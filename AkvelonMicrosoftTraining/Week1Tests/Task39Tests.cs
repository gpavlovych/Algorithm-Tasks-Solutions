namespace Week1.Tests
{
    using System.Collections.Generic;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Task39Tests
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
            result.Should().Contain(expectedOutput);
        }
    }
}