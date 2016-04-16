namespace Task49Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Task49;

    [TestClass]
    public class SolverTests
    {
        #region DeleteByValue

        [TestMethod]
        public void DeleteByValueTestNull()
        {
            //arrange
            Node start = null;

            //act
            Solver.DeleteByValue(ref start, 8);

            //assert
            Assert.IsNull(start);
        }

        [TestMethod]
        public void DeleteByValueTest()
        {
            //arrange
            var doublyLinkedListNode1 = new Node() { Value = 3 };
            var doublyLinkedListNode2 = new Node() { Value = 4 };
            var doublyLinkedListNode3 = new Node() { Value = 5 };
            var start = doublyLinkedListNode1;
            doublyLinkedListNode1.Previous = null;
            doublyLinkedListNode1.Next = doublyLinkedListNode2;
            doublyLinkedListNode2.Previous = doublyLinkedListNode1;
            doublyLinkedListNode2.Next = doublyLinkedListNode3;
            doublyLinkedListNode3.Previous = doublyLinkedListNode2;
            doublyLinkedListNode3.Next = null;

            //act
            Solver.DeleteByValue(ref start, 8);

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
        public void DeleteByValueTestExisting()
        {
            //arrange
            var doublyLinkedListNode1 = new Node() { Value = 3 };
            var doublyLinkedListNode2 = new Node() { Value = 4 };
            var doublyLinkedListNode3 = new Node() { Value = 5 };
            var start = doublyLinkedListNode1;
            doublyLinkedListNode1.Previous = null;
            doublyLinkedListNode1.Next = doublyLinkedListNode2;
            doublyLinkedListNode2.Previous = doublyLinkedListNode1;
            doublyLinkedListNode2.Next = doublyLinkedListNode3;
            doublyLinkedListNode3.Previous = doublyLinkedListNode2;
            doublyLinkedListNode3.Next = null;

            //act
            Solver.DeleteByValue(ref start, 4);

            //assert
            Assert.IsNull(start.Previous);
            Assert.AreSame(start, doublyLinkedListNode1);
            Assert.AreSame(start.Next, doublyLinkedListNode3);
            Assert.AreSame(start.Next.Previous, doublyLinkedListNode1);
            Assert.IsNull(start.Next.Next);
        }

        [TestMethod]
        public void DeleteByValueTestFirst()
        {
            //arrange
            var doublyLinkedListNode1 = new Node() { Value = 3 };
            var doublyLinkedListNode2 = new Node() { Value = 4 };
            var doublyLinkedListNode3 = new Node() { Value = 5 };
            var start = doublyLinkedListNode1;
            doublyLinkedListNode1.Previous = null;
            doublyLinkedListNode1.Next = doublyLinkedListNode2;
            doublyLinkedListNode2.Previous = doublyLinkedListNode1;
            doublyLinkedListNode2.Next = doublyLinkedListNode3;
            doublyLinkedListNode3.Previous = doublyLinkedListNode2;
            doublyLinkedListNode3.Next = null;

            //act
            Solver.DeleteByValue(ref start, 3);

            //assert
            Assert.IsNull(start.Previous);
            Assert.AreSame(start, doublyLinkedListNode2);
            Assert.AreSame(start.Next, doublyLinkedListNode3);
            Assert.AreSame(start.Next.Previous, doublyLinkedListNode2);
            Assert.IsNull(start.Next.Next);
        }

        [TestMethod]
        public void DeleteByValueTestLast()
        {
            //arrange
            var doublyLinkedListNode1 = new Node() { Value = 3 };
            var doublyLinkedListNode2 = new Node() { Value = 4 };
            var doublyLinkedListNode3 = new Node() { Value = 5 };
            var start = doublyLinkedListNode1;
            doublyLinkedListNode1.Previous = null;
            doublyLinkedListNode1.Next = doublyLinkedListNode2;
            doublyLinkedListNode2.Previous = doublyLinkedListNode1;
            doublyLinkedListNode2.Next = doublyLinkedListNode3;
            doublyLinkedListNode3.Previous = doublyLinkedListNode2;
            doublyLinkedListNode3.Next = null;

            //act
            Solver.DeleteByValue(ref start, 5);

            //assert
            Assert.IsNull(start.Previous);
            Assert.AreSame(start, doublyLinkedListNode1);
            Assert.AreSame(start.Next, doublyLinkedListNode2);
            Assert.AreSame(start.Next.Previous, doublyLinkedListNode1);
            Assert.IsNull(start.Next.Next);
        }

        #endregion DeleteByValue

        #region DeleteAtIndex

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeleteAtIndexTestArgumentOutOfRange0Null()
        {
            //arrange
            Node start = null;

            //act
            Solver.DeleteAtIndex(ref start, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeleteAtIndexTestArgumentOutOfRangeBelow0()
        {
            //arrange
            var doublyLinkedListNode1 = new Node() { Value = 3 };
            var doublyLinkedListNode2 = new Node() { Value = 4 };
            var doublyLinkedListNode3 = new Node() { Value = 5 };
            var start = doublyLinkedListNode1;
            doublyLinkedListNode1.Previous = null;
            doublyLinkedListNode1.Next = doublyLinkedListNode2;
            doublyLinkedListNode2.Previous = doublyLinkedListNode1;
            doublyLinkedListNode2.Next = doublyLinkedListNode3;
            doublyLinkedListNode3.Previous = doublyLinkedListNode2;
            doublyLinkedListNode3.Next = null;

            //act
            Solver.DeleteAtIndex(ref start, -8);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeleteAtIndexTestArgumentOutOfRangeAboveSize()
        {
            //arrange
            var doublyLinkedListNode1 = new Node() { Value = 3 };
            var doublyLinkedListNode2 = new Node() { Value = 4 };
            var doublyLinkedListNode3 = new Node() { Value = 5 };
            var start = doublyLinkedListNode1;
            doublyLinkedListNode1.Previous = null;
            doublyLinkedListNode1.Next = doublyLinkedListNode2;
            doublyLinkedListNode2.Previous = doublyLinkedListNode1;
            doublyLinkedListNode2.Next = doublyLinkedListNode3;
            doublyLinkedListNode3.Previous = doublyLinkedListNode2;
            doublyLinkedListNode3.Next = null;

            //act
            Solver.DeleteAtIndex(ref start, 8);
        }

        [TestMethod]
        public void DeleteAtIndexTestExisting()
        {
            //arrange
            var doublyLinkedListNode1 = new Node() { Value = 3 };
            var doublyLinkedListNode2 = new Node() { Value = 4 };
            var doublyLinkedListNode3 = new Node() { Value = 5 };
            var start = doublyLinkedListNode1;
            doublyLinkedListNode1.Previous = null;
            doublyLinkedListNode1.Next = doublyLinkedListNode2;
            doublyLinkedListNode2.Previous = doublyLinkedListNode1;
            doublyLinkedListNode2.Next = doublyLinkedListNode3;
            doublyLinkedListNode3.Previous = doublyLinkedListNode2;
            doublyLinkedListNode3.Next = null;

            //act
            Solver.DeleteAtIndex(ref start, 1);

            //assert
            Assert.IsNull(start.Previous);
            Assert.AreSame(start, doublyLinkedListNode1);
            Assert.AreSame(start.Next, doublyLinkedListNode3);
            Assert.AreSame(start.Next.Previous, doublyLinkedListNode1);
            Assert.IsNull(start.Next.Next);
        }

        [TestMethod]
        public void DeleteAtIndexTestFirst()
        {
            //arrange
            var doublyLinkedListNode1 = new Node() { Value = 3 };
            var doublyLinkedListNode2 = new Node() { Value = 4 };
            var doublyLinkedListNode3 = new Node() { Value = 5 };
            var start = doublyLinkedListNode1;
            doublyLinkedListNode1.Previous = null;
            doublyLinkedListNode1.Next = doublyLinkedListNode2;
            doublyLinkedListNode2.Previous = doublyLinkedListNode1;
            doublyLinkedListNode2.Next = doublyLinkedListNode3;
            doublyLinkedListNode3.Previous = doublyLinkedListNode2;
            doublyLinkedListNode3.Next = null;

            //act
            Solver.DeleteAtIndex(ref start, 0);

            //assert
            Assert.IsNull(start.Previous);
            Assert.AreSame(start, doublyLinkedListNode2);
            Assert.AreSame(start.Next, doublyLinkedListNode3);
            Assert.AreSame(start.Next.Previous, doublyLinkedListNode2);
            Assert.IsNull(start.Next.Next);
        }

        [TestMethod]
        public void DeleteAtIndexTestLast()
        {
            //arrange
            var doublyLinkedListNode1 = new Node() { Value = 3 };
            var doublyLinkedListNode2 = new Node() { Value = 4 };
            var doublyLinkedListNode3 = new Node() { Value = 5 };
            var start = doublyLinkedListNode1;
            doublyLinkedListNode1.Previous = null;
            doublyLinkedListNode1.Next = doublyLinkedListNode2;
            doublyLinkedListNode2.Previous = doublyLinkedListNode1;
            doublyLinkedListNode2.Next = doublyLinkedListNode3;
            doublyLinkedListNode3.Previous = doublyLinkedListNode2;
            doublyLinkedListNode3.Next = null;

            //act
            Solver.DeleteAtIndex(ref start, 2);

            //assert
            Assert.IsNull(start.Previous);
            Assert.AreSame(start, doublyLinkedListNode1);
            Assert.AreSame(start.Next, doublyLinkedListNode2);
            Assert.AreSame(start.Next.Previous, doublyLinkedListNode1);
            Assert.IsNull(start.Next.Next);
        }

        #endregion DeleteAtIndex
    }
}
