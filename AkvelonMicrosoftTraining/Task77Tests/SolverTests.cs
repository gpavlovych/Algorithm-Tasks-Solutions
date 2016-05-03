using System;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Task77.Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void PrintFizzBuzzTestStringWriter()
        {
            //arrange
            var result = new StringBuilder();
            using (var writer = new StringWriter(result))
            {
                //act
                Solver.PrintFizzBuzz(writer);

                //assert
                AssertOutput(result);
            }
        }

        [TestMethod]
        public void PrintFizzBuzzTestMoq()
        {
            //arrange
            var result = new StringBuilder();
            var textWriterMock = new Mock<TextWriter>();
            textWriterMock.Setup(it => it.WriteLine(It.IsAny<string>())).Callback<string>(str => result.AppendLine(str));
            textWriterMock.Setup(it => it.WriteLine(It.IsAny<int>()))
                          .Callback<int>(num => result.AppendLine(num.ToString()));

            //act
            Solver.PrintFizzBuzz(textWriterMock.Object);

            //assert
            AssertOutput(result);
        }

        #region Helper methods

        private static void AssertOutput(StringBuilder result)
        {
            var numbers = result.ToString().Split(
                new[]
                    {
                        "\n"
                    },
                StringSplitOptions.RemoveEmptyEntries).Select(it => it.Trim()).ToArray();
            Assert.AreEqual(100, numbers.Length);
            for (var i = 1; i <= numbers.Length; i++)
            {
                if (i % 3 != 0 && i % 5 != 0)
                {
                    Assert.AreEqual(i.ToString(), numbers[ i - 1 ]);
                }
                if (i % 3 == 0 && i % 5 != 0)
                {
                    Assert.AreEqual("Fizz", numbers[ i - 1 ]);
                }
                if (i % 3 != 0 && i % 5 == 0)
                {
                    Assert.AreEqual("Buzz", numbers[ i - 1 ]);
                }
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Assert.AreEqual("FizzBuzz", numbers[ i - 1 ]);
                }
            }
        }

        #endregion Helper methods
    }
}