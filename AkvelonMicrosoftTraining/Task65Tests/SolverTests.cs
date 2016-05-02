using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Task65.Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void PrintReverseOrderTriple()
        {
            PrintReverseOrderTest(
                new int[]
                    {
                        1,
                        2,
                        3
                    });
        }

        [TestMethod]
        public void PrintReverseOrderDouble()
        {
            PrintReverseOrderTest(
                new int[]
                    {
                        1,
                        2
                    });
        }

        [TestMethod]
        public void PrintReverseOrderSingle()
        {
            PrintReverseOrderTest(
                new int[]
                    {
                        1
                    });
        }

        [TestMethod]
        public void PrintReverseOrderEmpty()
        {
            PrintReverseOrderTest(
                new int[]
                    {
                    });
        }

        private static void PrintReverseOrderTest(int[] items)
        {
            //arrange
            var textWriterMoq = new Mock<TextWriter>();
            var resultingStr = string.Empty;
            textWriterMoq.Setup(it => it.Write(It.IsAny<string>(), It.IsAny<object>()))
                         .Callback<string, object>(
                             (s, arg) =>
                                 {
                                     resultingStr += string.Format(s, arg);
                                 });
            Node head = items.Length == 0 ? null : new Node(items[ 0 ]);
            Node node = head;
            for (var i = 1; i < items.Length; i++)
            {
                node.Next = new Node(items[ i ]);
                node = node.Next;
            }
            var expectedResultStr = items.Aggregate(string.Empty, (acc, item) => string.Format("{0} ", item) + acc);

            //act
            Solver.PrintReverseOrder(textWriterMoq.Object, head);

            //assert
            //verify correct output
            Assert.AreEqual(expectedResultStr, resultingStr);
            //verify linked list intact
            node = head;
            for (var i = 0; i < items.Length; i++)
            {
                Assert.AreEqual(items[ i ], node.Value);
                node = node.Next;
            }
            Assert.IsNull(node);
        }
    }
}