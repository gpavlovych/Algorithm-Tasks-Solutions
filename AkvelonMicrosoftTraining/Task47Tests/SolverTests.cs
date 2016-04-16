namespace Task47Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Task47;

    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void AddLastTest()
        {
            //arrange
            var head = new Node { Value = 3, Next = new Node() { Value = 4 } };

            //act
            Solver.AddLast(ref head, 8);

            //assert
            Assert.AreEqual(8, head.Next.Next.Value);
        }

        [TestMethod]
        public void AddLastTestSingleItem()
        {
            //arrange
            var head = new Node { Value = 3 };

            //act
            Solver.AddLast(ref head, 8);

            //assert
            Assert.AreEqual(8, head.Next.Value);
        }

        [TestMethod]
        public void AddLastTestNull()
        {
            //arrange
            Node head = null;

            //act
            Solver.AddLast(ref head, 8);

            //assert
            Assert.AreEqual(8, head.Next.Value);
        }

        [TestMethod]
        public void AddAtIndexTest()
        {
            //arrange
            var head = new Node { Value = 3, Next = new Node { Value = 4, Next = new Node { Value = 5 } } };

            //act
            Solver.AddAtIndex(ref head, 8, 1);

            //assert
            Assert.AreEqual(3, head.Value);
            Assert.AreEqual(8, head.Next.Value);
            Assert.AreEqual(4, head.Next.Next.Value);
            Assert.AreEqual(5, head.Next.Next.Next.Value);
        }

        [TestMethod]
        public void AddAtIndexTestFirst()
        {
            //arrange
            var head = new Node { Value = 3, Next = new Node { Value = 4, Next = new Node { Value = 5 } } };

            //act
            Solver.AddAtIndex(ref head, 8, 0);

            //assert
            Assert.AreEqual(8, head.Value);
            Assert.AreEqual(3, head.Next.Value);
            Assert.AreEqual(4, head.Next.Next.Value);
            Assert.AreEqual(5, head.Next.Next.Next.Value);
        }

        [TestMethod]
        public void AddAtIndexTestLast()
        {
            //arrange
            var head = new Node { Value = 3, Next = new Node { Value = 4, Next = new Node { Value = 5 } } };

            //act
            Solver.AddAtIndex(ref head, 8, 3);

            //assert
            Assert.AreEqual(3, head.Value);
            Assert.AreEqual(4, head.Next.Value);
            Assert.AreEqual(5, head.Next.Next.Value);
            Assert.AreEqual(8, head.Next.Next.Next.Value);
        }

        [TestMethod]
        public void AddAtIndexTestLastSingleItem()
        {
            //arrange
            var head = new Node { Value = 3 };

            //act
            Solver.AddAtIndex(ref head, 8, 1);

            //assert
            Assert.AreEqual(3, head.Value);
            Assert.AreEqual(8, head.Next.Value);
        }

        [TestMethod]
        public void AddAtIndexTestFirstSingleItem()
        {
            //arrange
            var head = new Node { Value = 3 };

            //act
            Solver.AddAtIndex(ref head, 8, 0);

            //assert
            Assert.AreEqual(8, head.Value);
            Assert.AreEqual(3, head.Next.Value);
        }

        [TestMethod]
        public void AddAtIndexTestFirstNullItem()
        {
            //arrange
            Node head = null;

            //act
            Solver.AddAtIndex(ref head, 8, 0);

            //assert
            Assert.AreEqual(8, head.Value);
            Assert.IsNull(head.Next);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddAtIndexTestSecondNullItem()
        {
            //arrange
            Node head = null;

            //act
            Solver.AddAtIndex(ref head, 8, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddAtIndexTestMinusOneNullItem()
        {
            //arrange
            Node head = null;

            //act
            Solver.AddAtIndex(ref head, 8, 11);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddAtIndexTestSecondSingleItem()
        {
            //arrange
            var head = new Node { Value = 3 };

            //act
            Solver.AddAtIndex(ref head, 8, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddAtIndexTestMinusOneSingleItem()
        {
            //arrange
            var head = new Node { Value = 3 };

            //act
            Solver.AddAtIndex(ref head, 8, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddAtIndexTestSecondTwoItems()
        {
            //arrange
            var head = new Node { Value = 3, Next = new Node { Value = 4 } };

            //act
            Solver.AddAtIndex(ref head, 8, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddAtIndexTestMinusOneTwoItems()
        {
            //arrange
            var head = new Node { Value = 3, Next = new Node { Value = 4 } };

            //act
            Solver.AddAtIndex(ref head, 8, -1);
        }

        [TestMethod]
        public void DeleteAtIndexTest()
        {
            //arrange
            var head = new Node { Value = 3 };

            //act
            Solver.DeleteAtIndex(ref head, 0);

            //assert
            Assert.IsNull(head);
        }

        [TestMethod]
        public void DeleteAtIndexTestTwoItems()
        {
            //arrange
            var head = new Node { Value = 3, Next = new Node { Value = 4 } };

            //act
            Solver.DeleteAtIndex(ref head, 0);

            //assert
            Assert.AreEqual(4, head.Value);
        }

        [TestMethod]
        public void DeleteAtIndexTestTwoItemsLast()
        {
            //arrange
            var head = new Node { Value = 3, Next = new Node { Value = 4 } };

            //act
            Solver.DeleteAtIndex(ref head, 1);

            //assert
            Assert.AreEqual(3, head.Value);
            Assert.IsNull(head.Next);
        }

        [TestMethod]
        public void DeleteAtIndexTestThreeItemsFirst()
        {
            //arrange
            var head = new Node { Value = 3, Next = new Node { Value = 4, Next = new Node { Value = 5 } } };

            //act
            Solver.DeleteAtIndex(ref head, 1);

            //assert
            Assert.AreEqual(3, head.Value);
            Assert.AreEqual(5, head.Next.Value);
        }

        [TestMethod]
        public void DeleteAtIndexTestThreeItemsMiddle()
        {
            //arrange
            var head = new Node { Value = 3, Next = new Node { Value = 4, Next = new Node { Value = 5 } } };

            //act
            Solver.DeleteAtIndex(ref head, 1);

            //assert
            Assert.AreEqual(3, head.Value);
            Assert.AreEqual(5, head.Next.Value);
        }

        [TestMethod]
        public void DeleteAtIndexTestThreeItemsLast()
        {
            //arrange
            var head = new Node { Value = 3, Next = new Node { Value = 4, Next = new Node { Value = 5 } } };

            //act
            Solver.DeleteAtIndex(ref head, 2);

            //assert
            Assert.AreEqual(3, head.Value);
            Assert.AreEqual(4, head.Next.Value);
            Assert.IsNull(head.Next.Next);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void DeleteAtIndexTestNull()
        {
            //arrange
            Node head = null;

            //act
            Solver.DeleteAtIndex(ref head, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void DeleteAtIndexTestThreeItemsMinusOne()
        {
            //arrange
            var head = new Node { Value = 3, Next = new Node { Value = 4, Next = new Node { Value = 5 } } };

            //act
            Solver.DeleteAtIndex(ref head, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void DeleteAtIndexTestThreeItemsIndexOutOfRange()
        {
            //arrange
            var head = new Node { Value = 3, Next = new Node { Value = 4, Next = new Node { Value = 5 } } };

            //act
            Solver.DeleteAtIndex(ref head, 4);
        }

        [TestMethod]
        public void DeleteByValueTesEmptyList()
        {
            //arrange
            Node head = null;

            //act
            Solver.DeleteByValue(ref head, 3);

            //assert
            Assert.IsNull(head);
        }

        [TestMethod]
        public void DeleteByValueTestSingleItem()
        {
            //arrange
            var head = new Node { Value = 3 };

            //act
            Solver.DeleteByValue(ref head, 3);

            //assert
            Assert.IsNull(head);
        }

        [TestMethod]
        public void DeleteByValueTestDoubleItemsStart()
        {
            //arrange
            var head = new Node { Value = 3, Next = new Node() { Value = 4 } };

            //act
            Solver.DeleteByValue(ref head, 3);

            //assert
            Assert.AreEqual(4, head.Value);
            Assert.IsNull(head.Next);
        }

        [TestMethod]
        public void DeleteByValueTestDoubleItemsEnd()
        {
            //arrange
            var head = new Node { Value = 3, Next = new Node() { Value = 4 } };

            //act
            Solver.DeleteByValue(ref head, 4);

            //assert
            Assert.AreEqual(3, head.Value);
            Assert.IsNull(head.Next);
        }

        [TestMethod]
        public void DeleteByValueTestTripleItemsMiddle()
        {
            //arrange
            var head = new Node { Value = 3, Next = new Node() { Value = 4, Next = new Node() { Value = 5 } } };

            //act
            Solver.DeleteByValue(ref head, 4);

            //assert
            Assert.AreEqual(3, head.Value);
            Assert.AreEqual(5, head.Next.Value);
            Assert.IsNull(head.Next.Next);
        }

        [TestMethod]
        public void DeleteByValueTestTripleItemsNoValueExist()
        {
            //arrange
            var head = new Node { Value = 3, Next = new Node() { Value = 4, Next = new Node() { Value = 5 } } };

            //act
            Solver.DeleteByValue(ref head, 6);

            //assert
            Assert.AreEqual(3, head.Value);
            Assert.AreEqual(4, head.Next.Value);
            Assert.AreEqual(5, head.Next.Next.Value);
            Assert.IsNull(head.Next.Next.Next);
        }

        [TestMethod]
        public void DeleteByValueTestDuplicatesStart()
        {
            //arrange
            var head = new Node { Value = 4, Next = new Node() { Value = 4, Next = new Node() { Value = 5 } } };

            //act
            Solver.DeleteByValue(ref head, 4);

            //assert
            Assert.AreEqual(5, head.Value);
            Assert.IsNull(head.Next);
        }

        [TestMethod]
        public void DeleteByValueTestDuplicatesAll()
        {
            //arrange
            var head = new Node { Value = 4, Next = new Node() { Value = 4, Next = new Node() { Value = 4 } } };

            //act
            Solver.DeleteByValue(ref head, 4);

            //assert
            Assert.IsNull(head);
        }

        [TestMethod]
        public void DeleteByValueTestDuplicatesEnd()
        {
            //arrange
            var head = new Node { Value = 5, Next = new Node() { Value = 4, Next = new Node() { Value = 4 } } };

            //act
            Solver.DeleteByValue(ref head, 4);

            //assert
            Assert.AreEqual(5, head.Value);
            Assert.IsNull(head.Next);
        }

        [TestMethod]
        public void DeleteByValueTestDuplicatesSparse()
        {
            //arrange
            var head = new Node { Value = 4, Next = new Node() { Value = 5, Next = new Node() { Value = 4 } } };

            //act
            Solver.DeleteByValue(ref head, 4);

            //assert
            Assert.AreEqual(5, head.Value);
            Assert.IsNull(head.Next);
        }
    }
}