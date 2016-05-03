using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Moq;

namespace Task66.Tests
{
    [TestClass]
    public class SolverTests
    {
        #region PreOrder

        [TestMethod]
        public void PreOrderPrintTest()
        {
            TestPrint(
                "6 2 1 4 3 5 7 9 8 ",
                new BinaryTreeNode(6)
                    {
                        LeftChild = new BinaryTreeNode(2)
                                        {
                                            LeftChild = new BinaryTreeNode(1),
                                            RightChild = new BinaryTreeNode(4)
                                                             {
                                                                 LeftChild = new BinaryTreeNode(3),
                                                                 RightChild = new BinaryTreeNode(5)
                                                             }
                                        },
                        RightChild = new BinaryTreeNode(7)
                                         {
                                             RightChild = new BinaryTreeNode(9)
                                                              {
                                                                  LeftChild = new BinaryTreeNode(8)
                                                              }
                                         }
                    },
                Solver.PreOrderPrint);
        }

        [TestMethod]
        public void PreOrderPrintTestSingle()
        {
            TestPrint("1 ", new BinaryTreeNode(1), Solver.PreOrderPrint);
        }

        [TestMethod]
        public void PreOrderPrintTestEmpty()
        {
            TestPrint(string.Empty, null, Solver.PreOrderPrint);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PreOrderPrintTestTextWriterNull()
        {
            Solver.PreOrderPrint(null, new BinaryTreeNode(1));
        }

        #endregion PreOrder

        #region InOrder

        [TestMethod]
        public void InOrderPrintTest()
        {
            TestPrint(
                "1 2 3 4 5 6 7 8 9 ",
                new BinaryTreeNode(6)
                    {
                        LeftChild = new BinaryTreeNode(2)
                                        {
                                            LeftChild = new BinaryTreeNode(1),
                                            RightChild = new BinaryTreeNode(4)
                                                             {
                                                                 LeftChild = new BinaryTreeNode(3),
                                                                 RightChild = new BinaryTreeNode(5)
                                                             }
                                        },
                        RightChild = new BinaryTreeNode(7)
                                         {
                                             RightChild = new BinaryTreeNode(9)
                                                              {
                                                                  LeftChild = new BinaryTreeNode(8)
                                                              }
                                         }
                    },
                Solver.InOrderPrint);
        }

        [TestMethod]
        public void InOrderPrintTestSingle()
        {
            TestPrint("1 ", new BinaryTreeNode(1), Solver.InOrderPrint);
        }

        [TestMethod]
        public void InOrderPrintTestEmpty()
        {
            TestPrint(string.Empty, null, Solver.InOrderPrint);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InOrderPrintTestTextWriterNull()
        {
            Solver.InOrderPrint(null, new BinaryTreeNode(1));
        }

        #endregion InOrder

        #region PostOrder

        [TestMethod]
        public void PostOrderPrintTest()
        {
            TestPrint(
                "1 3 5 4 2 8 9 7 6 ",
                new BinaryTreeNode(6)
                    {
                        LeftChild = new BinaryTreeNode(2)
                                        {
                                            LeftChild = new BinaryTreeNode(1),
                                            RightChild = new BinaryTreeNode(4)
                                                             {
                                                                 LeftChild = new BinaryTreeNode(3),
                                                                 RightChild = new BinaryTreeNode(5)
                                                             }
                                        },
                        RightChild = new BinaryTreeNode(7)
                                         {
                                             RightChild = new BinaryTreeNode(9)
                                                              {
                                                                  LeftChild = new BinaryTreeNode(8)
                                                              }
                                         }
                    },
                Solver.PostOrderPrint);
        }

        [TestMethod]
        public void PostOrderPrintTestSingle()
        {
            TestPrint("1 ", new BinaryTreeNode(1), Solver.PostOrderPrint);
        }

        [TestMethod]
        public void PostOrderPrintTestEmpty()
        {
            TestPrint(string.Empty, null, Solver.PostOrderPrint);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PostOrderPrintTestTextWriterNull()
        {
            Solver.PostOrderPrint(null, new BinaryTreeNode(1));
        }

        #endregion PostOrder

        #region Helper methods

        private static void TestPrint(
            string expectedOutput,
            BinaryTreeNode node,
            Action<TextWriter, BinaryTreeNode> printAction)
        {
            //arrange
            var textWriterMock = new Mock<TextWriter>();
            var actualOutput = string.Empty;
            textWriterMock.Setup(it => it.Write(It.IsAny<string>(), It.IsAny<object>()))
                          .Callback<string, object>((str, obj) => actualOutput += string.Format(str, obj));

            //act
            printAction(textWriterMock.Object, node);

            //assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        #endregion Helper methods
    }
}