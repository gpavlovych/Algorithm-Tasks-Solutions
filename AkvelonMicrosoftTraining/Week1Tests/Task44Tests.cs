using System;
using System.Collections.Generic;
using System.Linq;

using BaseTests.Tests;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Week1.Tests
{
    [TestClass]
    public class Task44Tests : UnitTestBase
    {
        #region Generic LinkedList

        [TestMethod]
        public void ReverseLinkedListTest()
        {
            //arrange
            var input = new LinkedList<int>(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            var expectedOutput = new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            //act
            var actualOutput = Task44.ReverseLinkedList(input);

            //assert
            AssertCollectionsEqual(expectedOutput, actualOutput.ToArray());
        }


        [TestMethod]
        public void ReverseLinkedListTestSingle()
        {
            //arrange
            var input = new LinkedList<int>(new[] { 1 });
            var expectedOutput = new[] { 1 };

            //act
            var actualOutput = Task44.ReverseLinkedList(input);

            //assert
            AssertCollectionsEqual(expectedOutput, actualOutput.ToArray());
        }

        [TestMethod]
        public void ReverseLinkedListTestEmpty()
        {
            //arrange
            var input = new LinkedList<int>(new int[] { });
            var expectedOutput = new int[] { };

            //act
            var actualOutput = Task44.ReverseLinkedList(input);

            //assert
            AssertCollectionsEqual(expectedOutput, actualOutput.ToArray());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReverseLinkedListTestNull()
        {
            //act
            Task44.ReverseLinkedList(default(LinkedList<int>));
        }

        #endregion Generic LinkedList

        #region Generic Node

        [TestMethod]
        public void ReverseNodeTest()
        {
            //arrange
            var firstNode = new Task44.Node<int>()
                                {
                                    Value = 3,
                                    Next =
                                        new Task44.Node<int>()
                                            {
                                                Value = 4,
                                                Next =
                                                    new Task44.Node<int>()
                                                        {
                                                            Value = 5,
                                                            Next =
                                                                new Task44
                                                                .Node
                                                                <int>
                                                                ()
                                                                    {
                                                                        Value
                                                                            =
                                                                            6
                                                                    }
                                                        }
                                            }
                                };
            //act
            var reversedNode = Task44.ReverseNode(firstNode);

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
            var firstNode = new Task44.Node<int>() { Value = 3, Next = null };

            //act
            var reversedNode = Task44.ReverseNode(firstNode);

            //assert
            Assert.AreEqual(3, reversedNode.Value);
            Assert.IsNull(reversedNode.Next);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReverseNodeTestNull()
        {
            Task44.ReverseNode(default(Task44.Node<int>));
        }

        #endregion Generic Node
    }
}