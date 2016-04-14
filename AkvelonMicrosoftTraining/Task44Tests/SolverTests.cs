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
            var head = new Node<int>
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
            Solver.ReverseNode(ref head);

            //assert
            Assert.AreEqual(6, head.Value);
            Assert.AreEqual(5, head.Next.Value);
            Assert.AreEqual(4, head.Next.Next.Value);
            Assert.AreEqual(3, head.Next.Next.Next.Value);
        }

        [TestMethod]
        public void ReverseNodeSingleTest()
        {
            //arrange
            var head = new Node<int> { Value = 3, Next = null };

            //act
            Solver.ReverseNode(ref head);

            //assert
            Assert.AreEqual(3, head.Value);
            Assert.IsNull(head.Next);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReverseNodeTestNull()
        {
            //arrange
            Node<int> head = null;

            //act
            Solver.ReverseNode(ref head);
        }

        #endregion Generic Node
    }
}