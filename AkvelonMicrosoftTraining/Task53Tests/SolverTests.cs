namespace Task53Tests
{
    using System;
    using System.IO;
    using System.Text;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using Task53;

    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void PrintInSpiralOrderTestSquare()
        {
            //arrange
            var textWriterMock = new Mock<TextWriter>();
            var array = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            StringBuilder result = new StringBuilder();
            textWriterMock.Setup(it => it.Write(It.IsAny<string>(), It.IsAny<object>()))
                .Callback<string, object>((s, i) => result.Append(string.Format(s, i)));

            //act
            Solver.PrintInSpiralOrder(textWriterMock.Object, array);

            //assert
            Assert.AreEqual("1 2 3 6 9 8 7 4 5 ", result.ToString());
        }

        [TestMethod]
        public void PrintInSpiralOrderTestNonSquare()
        {
            //arrange
            var textWriterMock = new Mock<TextWriter>();
            var array = new int[,] { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 }, { 11, 12, 13, 14, 15 } };
            StringBuilder result = new StringBuilder();
            textWriterMock.Setup(it => it.Write(It.IsAny<string>(), It.IsAny<object>()))
                .Callback<string, object>((s, i) => result.Append(string.Format(s, i)));

            //act
            Solver.PrintInSpiralOrder(textWriterMock.Object, array);

            //assert
            Assert.AreEqual("1 2 3 4 5 10 15 14 13 12 11 6 7 8 9 ", result.ToString());
        }

        [TestMethod]
        public void PrintInSpiralOrderTestSingleRow()
        {
            //arrange
            var textWriterMock = new Mock<TextWriter>();
            var array = new int[,] { { 1, 2, 3, 4, 5 } };
            StringBuilder result = new StringBuilder();
            textWriterMock.Setup(it => it.Write(It.IsAny<string>(), It.IsAny<object>()))
                .Callback<string, object>((s, i) => result.Append(string.Format(s, i)));

            //act
            Solver.PrintInSpiralOrder(textWriterMock.Object, array);

            //assert
            Assert.AreEqual("1 2 3 4 5 ", result.ToString());
        }

        [TestMethod]
        public void PrintInSpiralOrderTestSingleColumn()
        {
            //arrange
            var textWriterMock = new Mock<TextWriter>();
            var array = new int[,] { { 1 }, { 2 }, { 3 } };
            StringBuilder result = new StringBuilder();
            textWriterMock.Setup(it => it.Write(It.IsAny<string>(), It.IsAny<object>()))
                .Callback<string, object>((s, i) => result.Append(string.Format(s, i)));

            //act
            Solver.PrintInSpiralOrder(textWriterMock.Object, array);

            //assert
            Assert.AreEqual("1 2 3 ", result.ToString());
        }

        [TestMethod]
        public void PrintInSpiralOrderTestEmpty()
        {
            //arrange
            var textWriterMock = new Mock<TextWriter>();
            var array = new int[,] { { } };
            StringBuilder result = new StringBuilder();
            textWriterMock.Setup(it => it.Write(It.IsAny<string>(), It.IsAny<object>()))
                .Callback<string, object>((s, i) => result.Append(string.Format(s, i)));

            //act
            Solver.PrintInSpiralOrder(textWriterMock.Object, array);

            //assert
            Assert.AreEqual("", result.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PrintInSpiralOrderTestTextOutNull()
        {
            //arrange
            var array = new int[,] { { } };

            //act
            Solver.PrintInSpiralOrder(null, array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PrintInSpiralOrderTestInputNull()
        {
            //arrange
            var textWriterMock = new Mock<TextWriter>();
            StringBuilder result = new StringBuilder();
            textWriterMock.Setup(it => it.Write(It.IsAny<string>(), It.IsAny<object>()))
                .Callback<string, object>((s, i) => result.Append(string.Format(s, i)));

            //act
            Solver.PrintInSpiralOrder<int>(textWriterMock.Object, null);
        }
    }
}
