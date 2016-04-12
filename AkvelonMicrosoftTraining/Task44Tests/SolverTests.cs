namespace Task44Tests
{
    using System;

    using BaseTests.Tests;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Task44;

    [TestClass]
    public class SolverTests : UnitTestBase
    {
        #region Generic Node

        [TestMethod]
        public void ReverseNodeTest()
        {
            //arrange
            var firstNode = new Node<int>
                                {
                                    Value = 3,
                                    Next =
                                        new Node<int>
                                            {
                                                Value = 4,
                                                Next =
                                                    new Node<int>
                                                        {
                                                            Value = 5,
                                                            Next = new Node<int> { Value = 6 }
                                                        }
                                            }
                                };
            //act
            var reversedNode = Solver.ReverseNode(firstNode);

            //assert
            Assert.AreEqual(6, reversedNode.Value);
            Assert.AreEqual(5, reversedNode.Next.Value);
            Assert.AreEqual(4, reversedNode.Next.Next.Value);
            Assert.AreEqual(3, reversedNode.Next.Next.Next.Value);
        }

        [TestMethod]
        public void ReverseNodeSingleTest()
        {
            //arrange
            var firstNode = new Node<int> { Value = 3, Next = null };

            //act
            var reversedNode = Solver.ReverseNode(firstNode);

            //assert
            Assert.AreEqual(3, reversedNode.Value);
            Assert.IsNull(reversedNode.Next);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReverseNodeTestNull()
        {
            Solver.ReverseNode(default(Node<int>));
        }

        #endregion Generic Node
    }
}