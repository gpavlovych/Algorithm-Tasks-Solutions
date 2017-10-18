using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task5;

namespace Task5Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void BinaryTree2DoublyLinkedListTestEmpty()
        {
            // arrange
            Node root = null;

            // act
            var result = Solver.BinaryTree2DoublyLinkedList(root);

            // assert
            AssertDoubleLinkedList(new int[] { }, result);
        }

        [TestMethod]
        public void BinaryTree2DoublyLinkedListTestSingleNode()
        {
            // arrange
            var root = new Node(4);

            // act
            var result = Solver.BinaryTree2DoublyLinkedList(root);

            // assert
            AssertDoubleLinkedList(new int[] { 4 }, result);
        }

        [TestMethod]
        public void BinaryTree2DoublyLinkedListTestRightNodes()
        {
            // arrange
            var root = new Node(4) { Right = new Node(5) { Left = new Node(6), Right = new Node(7) } };

            // act
            var result = Solver.BinaryTree2DoublyLinkedList(root);

            // assert
            AssertDoubleLinkedList(new int[] { 4, 6, 5, 7 }, result);
        }

        [TestMethod]
        public void BinaryTree2DoublyLinkedListTestAllNodes()
        {
            // arrange
            var root = new Node(10) { Left = new Node(12) { Left = new Node(25), Right = new Node(30) }, Right = new Node(15) { Left = new Node(36) } };

            // act
            var result = Solver.BinaryTree2DoublyLinkedList(root);

            // assert
            AssertDoubleLinkedList(new int[] { 25, 12, 30, 10, 36, 15 }, result);
        }

        private void AssertDoubleLinkedList(int[] expectedValues, Node head)
        {
            if (expectedValues.Length == 0)
            {
                Assert.IsNull(head);
            }

            Node prevHead = null;
            var index = 0;
            while(head != null)
            {
                Assert.AreSame(prevHead, head.Left);
                if (index < expectedValues.Length)
                {
                    Assert.AreEqual(expectedValues[index], head.Value);
                }

                index++;
                prevHead = head;
                head = head.Right;
            }

            var actualCount = index;
            Assert.AreEqual(expectedValues.Length, actualCount);
        }
    }
}
