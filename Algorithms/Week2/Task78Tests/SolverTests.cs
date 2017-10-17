using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;
using Moq;

namespace Task78.Tests
{
    [TestClass]
    public class SolverTests
    {
        private StringBuilder result;
        private Mock<TextWriter> textWriterMock;

        [TestInitialize]
        public void Init()
        {
            //arrange
            result = new StringBuilder();
            textWriterMock = new Mock<TextWriter>();
            textWriterMock.Setup(it => it.Write(It.IsAny<string>(), It.IsAny<object>()))
                          .Callback<string, object>((str, obj) => result.Append(string.Format(str, obj)));
        }

        [TestMethod]
        public void PrintFibonacciTest0()
        {
            //act
            Solver.PrintFibonacci(textWriterMock.Object, 0);

            //assert
            Assert.AreEqual("", result.ToString());
        }

        [TestMethod]
        public void PrintFibonacciTest1()
        {
            //act
            Solver.PrintFibonacci(textWriterMock.Object, 1);

            //assert
            Assert.AreEqual("1 1 ", result.ToString());
        }

        [TestMethod]
        public void PrintFibonacciTest2()
        {
            //act
            Solver.PrintFibonacci(textWriterMock.Object, 2);

            //assert
            Assert.AreEqual("1 1 2 ", result.ToString());
        }

        [TestMethod]
        public void PrintFibonacciTest3()
        {
            //act
            Solver.PrintFibonacci(textWriterMock.Object, 3);

            //assert
            Assert.AreEqual("1 1 2 3 ", result.ToString());
        }

        [TestMethod]
        public void PrintFibonacciTest4()
        {
            //act
            Solver.PrintFibonacci(textWriterMock.Object, 4);

            //assert
            Assert.AreEqual("1 1 2 3 ", result.ToString());
        }

        [TestMethod]
        public void PrintFibonacciTest5()
        {
            //act
            Solver.PrintFibonacci(textWriterMock.Object, 5);

            //assert
            Assert.AreEqual("1 1 2 3 5 ", result.ToString());
        }
    }
}