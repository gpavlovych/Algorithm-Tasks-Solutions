namespace Task39Tests
{
    using System;
    using System.IO;

    using BaseTests.Tests;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using Task39;

    [TestClass]
    public class Task39Tests: UnitTestBase
    {
        [TestMethod]
        public void TestSolve()
        {
            //arrange
            var input = new[] { 1, 1, 2, 3, 2 };
            var textWriterMock = new Mock<TextWriter>();

            //act
            Solver.Solve(textWriterMock.Object, input);

            //assert
            textWriterMock.Verify(it => it.WriteLine("Item {0} is occured again at position {1}", 1, 1));
            textWriterMock.Verify(it => it.WriteLine("Item {0} is occured again at position {1}", 2, 4));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSolveInputNull()
        {
            //arrange
            var textWriterMock = new Mock<TextWriter>();

            //act
            Solver.Solve(textWriterMock.Object, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSolveWriterNull()
        {
            //arrange
            var input = new[] { 1, 1, 2, 3, 2 };

            //act
            Solver.Solve(null, input);
        }
    }
}