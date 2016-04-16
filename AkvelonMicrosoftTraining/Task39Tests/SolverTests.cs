namespace Task39Tests
{
    using System;
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using Task39;

    [TestClass]
    public class Task39Tests
    {
        [TestMethod]
        public void TestSolveWithoutDuplicates()
        {
            //arrange
            var input = new[] { 1, 2, 3, 4, 5 };
            var textWriterMock = new Mock<TextWriter>();

            //act
            Solver.Solve(textWriterMock.Object, input);

            //assert
            textWriterMock.Verify(
                it => it.WriteLine(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<object>()),
                Times.Never);
        }

        [TestMethod]
        public void TestSolveFullySorted()
        {
            //arrange
            var input = new[] { 1, 1, 2, 3, 5 };
            var textWriterMock = new Mock<TextWriter>();

            //act
            Solver.Solve(textWriterMock.Object, input);

            //assert
            textWriterMock.Verify(it => it.WriteLine("Item {0} is occured again at position {1}", 1, 1));
            //verify that above were the only calls
            textWriterMock.Verify(
                it => it.WriteLine(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<object>()),
                Times.Exactly(1));
        }

        [TestMethod]
        public void TestSolveFullyUnsorted()
        {
            //arrange
            var input = new[] { 5, 5, 3, 1, 3 };
            var textWriterMock = new Mock<TextWriter>();

            //act
            Solver.Solve(textWriterMock.Object, input);

            //assert
            textWriterMock.Verify(it => it.WriteLine("Item {0} is occured again at position {1}", 5, 1));
            textWriterMock.Verify(it => it.WriteLine("Item {0} is occured again at position {1}", 3, 4));
            //verify that above were the only calls
            textWriterMock.Verify(
                it => it.WriteLine(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<object>()),
                Times.Exactly(2));
        }

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
            //verify that above were the only calls
            textWriterMock.Verify(
                it => it.WriteLine(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<object>()),
                Times.Exactly(2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSolveInputInvalidItemNegativeExceedsLength()
        {
            //arrange
            var input = new[] { 1, -5 };
            var textWriterMock = new Mock<TextWriter>();

            //act
            Solver.Solve(textWriterMock.Object, input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSolveInputInvalidItemPositiveExceedsLength()
        {
            //arrange
            var input = new[] { 1, 5 };
            var textWriterMock = new Mock<TextWriter>();

            //act
            Solver.Solve(textWriterMock.Object, input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSolveInputInvalidItemNegative()
        {
            //arrange
            var input = new[] { 1, -1 };
            var textWriterMock = new Mock<TextWriter>();

            //act
            Solver.Solve(textWriterMock.Object, input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSolveInputInvalidItem0()
        {
            //arrange
            var input = new[] { 1, 0 };
            var textWriterMock = new Mock<TextWriter>();

            //act
            Solver.Solve(textWriterMock.Object, input);
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