namespace Task49Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Task49;

    [TestClass]
    public class SolverTests
    {
        #region DeleteNodesHavingValue

        [TestMethod]
        public void DeleteNodeTestNull()
        {
            //arrange
            Node<int> start = null;

            //act
            Solver.DeleteNodesHavingValue(ref start, 8);

            //assert
            Assert.IsNull(start);
        }

        [TestMethod]
        public void DeleteNodeTest()
        {
            //arrange
            var doublyLinkedListNode1 = new Node<int>() { Value = 3 };
            var doublyLinkedListNode2 = new Node<int>() { Value = 4 };
            var doublyLinkedListNode3 = new Node<int>() { Value = 5 };
            var start = doublyLinkedListNode1;
            doublyLinkedListNode1.Previous = null;
            doublyLinkedListNode1.Next = doublyLinkedListNode2;
            doublyLinkedListNode2.Previous = doublyLinkedListNode1;
            doublyLinkedListNode2.Next = doublyLinkedListNode3;
            doublyLinkedListNode3.Previous = doublyLinkedListNode2;
            doublyLinkedListNode3.Next = null;

            //act
            Solver.DeleteNodesHavingValue(ref start, 8);

            //assert
            Assert.IsNull(start.Previous);
            Assert.AreSame(start, doublyLinkedListNode1);
            Assert.AreSame(start.Next, doublyLinkedListNode2);
            Assert.AreSame(start.Next.Previous, doublyLinkedListNode1);
            Assert.AreSame(start.Next.Next, doublyLinkedListNode3);
            Assert.AreSame(start.Next.Next.Previous, doublyLinkedListNode2);
            Assert.IsNull(start.Next.Next.Next);
        }

        [TestMethod]
        public void DeleteNodeTestExisting()
        {
            //arrange
            var doublyLinkedListNode1 = new Node<int>() { Value = 3 };
            var doublyLinkedListNode2 = new Node<int>() { Value = 4 };
            var doublyLinkedListNode3 = new Node<int>() { Value = 5 };
            var start = doublyLinkedListNode1;
            doublyLinkedListNode1.Previous = null;
            doublyLinkedListNode1.Next = doublyLinkedListNode2;
            doublyLinkedListNode2.Previous = doublyLinkedListNode1;
            doublyLinkedListNode2.Next = doublyLinkedListNode3;
            doublyLinkedListNode3.Previous = doublyLinkedListNode2;
            doublyLinkedListNode3.Next = null;

            //act
            Solver.DeleteNodesHavingValue(ref start, 4);

            //assert
            Assert.IsNull(start.Previous);
            Assert.AreSame(start, doublyLinkedListNode1);
            Assert.AreSame(start.Next, doublyLinkedListNode3);
            Assert.AreSame(start.Next.Previous, doublyLinkedListNode1);
            Assert.IsNull(start.Next.Next);
        }

        [TestMethod]
        public void DeleteNodeTestFirst()
        {
            //arrange
            var doublyLinkedListNode1 = new Node<int>() { Value = 3 };
            var doublyLinkedListNode2 = new Node<int>() { Value = 4 };
            var doublyLinkedListNode3 = new Node<int>() { Value = 5 };
            var start = doublyLinkedListNode1;
            doublyLinkedListNode1.Previous = null;
            doublyLinkedListNode1.Next = doublyLinkedListNode2;
            doublyLinkedListNode2.Previous = doublyLinkedListNode1;
            doublyLinkedListNode2.Next = doublyLinkedListNode3;
            doublyLinkedListNode3.Previous = doublyLinkedListNode2;
            doublyLinkedListNode3.Next = null;

            //act
            Solver.DeleteNodesHavingValue(ref start, 3);

            //assert
            Assert.IsNull(start.Previous);
            Assert.AreSame(start, doublyLinkedListNode2);
            Assert.AreSame(start.Next, doublyLinkedListNode3);
            Assert.AreSame(start.Next.Previous, doublyLinkedListNode2);
            Assert.IsNull(start.Next.Next);
        }

        [TestMethod]
        public void DeleteNodeTestLast()
        {
            //arrange
            var doublyLinkedListNode1 = new Node<int>() { Value = 3 };
            var doublyLinkedListNode2 = new Node<int>() { Value = 4 };
            var doublyLinkedListNode3 = new Node<int>() { Value = 5 };
            var start = doublyLinkedListNode1;
            doublyLinkedListNode1.Previous = null;
            doublyLinkedListNode1.Next = doublyLinkedListNode2;
            doublyLinkedListNode2.Previous = doublyLinkedListNode1;
            doublyLinkedListNode2.Next = doublyLinkedListNode3;
            doublyLinkedListNode3.Previous = doublyLinkedListNode2;
            doublyLinkedListNode3.Next = null;

            //act
            Solver.DeleteNodesHavingValue(ref start, 5);

            //assert
            Assert.IsNull(start.Previous);
            Assert.AreSame(start, doublyLinkedListNode1);
            Assert.AreSame(start.Next, doublyLinkedListNode2);
            Assert.AreSame(start.Next.Previous, doublyLinkedListNode1);
            Assert.IsNull(start.Next.Next);
        }

        #endregion DeleteNodesHavingValue

        #region DeleteNodeAt

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeleteNodeAtTestArgumentOutOfRange0Null()
        {
            //arrange
            Node<int> start = null;

            //act
            Solver.DeleteNodeAt(ref start, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeleteNodeAtTestArgumentOutOfRangeBelow0()
        {
            //arrange
            var doublyLinkedListNode1 = new Node<int>() { Value = 3 };
            var doublyLinkedListNode2 = new Node<int>() { Value = 4 };
            var doublyLinkedListNode3 = new Node<int>() { Value = 5 };
            var start = doublyLinkedListNode1;
            doublyLinkedListNode1.Previous = null;
            doublyLinkedListNode1.Next = doublyLinkedListNode2;
            doublyLinkedListNode2.Previous = doublyLinkedListNode1;
            doublyLinkedListNode2.Next = doublyLinkedListNode3;
            doublyLinkedListNode3.Previous = doublyLinkedListNode2;
            doublyLinkedListNode3.Next = null;

            //act
            Solver.DeleteNodeAt(ref start, -8);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeleteNodeAtTestArgumentOutOfRangeAboveSize()
        {
            //arrange
            var doublyLinkedListNode1 = new Node<int>() { Value = 3 };
            var doublyLinkedListNode2 = new Node<int>() { Value = 4 };
            var doublyLinkedListNode3 = new Node<int>() { Value = 5 };
            var start = doublyLinkedListNode1;
            doublyLinkedListNode1.Previous = null;
            doublyLinkedListNode1.Next = doublyLinkedListNode2;
            doublyLinkedListNode2.Previous = doublyLinkedListNode1;
            doublyLinkedListNode2.Next = doublyLinkedListNode3;
            doublyLinkedListNode3.Previous = doublyLinkedListNode2;
            doublyLinkedListNode3.Next = null;

            //act
            Solver.DeleteNodeAt(ref start, 8);
        }

        [TestMethod]
        public void DeleteNodeAtTestExisting()
        {
            //arrange
            var doublyLinkedListNode1 = new Node<int>() { Value = 3 };
            var doublyLinkedListNode2 = new Node<int>() { Value = 4 };
            var doublyLinkedListNode3 = new Node<int>() { Value = 5 };
            var start = doublyLinkedListNode1;
            doublyLinkedListNode1.Previous = null;
            doublyLinkedListNode1.Next = doublyLinkedListNode2;
            doublyLinkedListNode2.Previous = doublyLinkedListNode1;
            doublyLinkedListNode2.Next = doublyLinkedListNode3;
            doublyLinkedListNode3.Previous = doublyLinkedListNode2;
            doublyLinkedListNode3.Next = null;

            //act
            Solver.DeleteNodeAt(ref start, 1);

            //assert
            Assert.IsNull(start.Previous);
            Assert.AreSame(start, doublyLinkedListNode1);
            Assert.AreSame(start.Next, doublyLinkedListNode3);
            Assert.AreSame(start.Next.Previous, doublyLinkedListNode1);
            Assert.IsNull(start.Next.Next);
        }

        [TestMethod]
        public void DeleteNodeAtTestFirst()
        {
            //arrange
            var doublyLinkedListNode1 = new Node<int>() { Value = 3 };
            var doublyLinkedListNode2 = new Node<int>() { Value = 4 };
            var doublyLinkedListNode3 = new Node<int>() { Value = 5 };
            var start = doublyLinkedListNode1;
            doublyLinkedListNode1.Previous = null;
            doublyLinkedListNode1.Next = doublyLinkedListNode2;
            doublyLinkedListNode2.Previous = doublyLinkedListNode1;
            doublyLinkedListNode2.Next = doublyLinkedListNode3;
            doublyLinkedListNode3.Previous = doublyLinkedListNode2;
            doublyLinkedListNode3.Next = null;

            //act
            Solver.DeleteNodeAt(ref start, 0);

            //assert
            Assert.IsNull(start.Previous);
            Assert.AreSame(start, doublyLinkedListNode2);
            Assert.AreSame(start.Next, doublyLinkedListNode3);
            Assert.AreSame(start.Next.Previous, doublyLinkedListNode2);
            Assert.IsNull(start.Next.Next);
        }

        [TestMethod]
        public void DeleteNodeAtTestLast()
        {
            //arrange
            var doublyLinkedListNode1 = new Node<int>() { Value = 3 };
            var doublyLinkedListNode2 = new Node<int>() { Value = 4 };
            var doublyLinkedListNode3 = new Node<int>() { Value = 5 };
            var start = doublyLinkedListNode1;
            doublyLinkedListNode1.Previous = null;
            doublyLinkedListNode1.Next = doublyLinkedListNode2;
            doublyLinkedListNode2.Previous = doublyLinkedListNode1;
            doublyLinkedListNode2.Next = doublyLinkedListNode3;
            doublyLinkedListNode3.Previous = doublyLinkedListNode2;
            doublyLinkedListNode3.Next = null;

            //act
            Solver.DeleteNodeAt(ref start, 2);

            //assert
            Assert.IsNull(start.Previous);
            Assert.AreSame(start, doublyLinkedListNode1);
            Assert.AreSame(start.Next, doublyLinkedListNode2);
            Assert.AreSame(start.Next.Previous, doublyLinkedListNode1);
            Assert.IsNull(start.Next.Next);
        }

        #endregion DeleteNodeAt
    }
}
