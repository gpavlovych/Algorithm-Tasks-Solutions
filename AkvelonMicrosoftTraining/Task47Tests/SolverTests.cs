namespace Task47Tests
{
    using System;

    using BaseTests.Tests;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Task47;

    [TestClass]
    public class SolverTests : UnitTestBase
    {
        [TestMethod]
        public void AddLastTest()
        {
            //arrange
            var head = new Node<int> { Value = 3, Next = new Node<int>() { Value = 4 } };

            //act
            Solver.AddLast(ref head, 8);

            //assert
            Assert.AreEqual(8, head.Next.Next.Value);
        }

        [TestMethod]
        public void AddLastTestSingleItem()
        {
            //arrange
            var head = new Node<int> { Value = 3 };

            //act
            Solver.AddLast(ref head, 8);

            //assert
            Assert.AreEqual(8, head.Next.Value);
        }

        [TestMethod]
        public void AddLastTestNull()
        {
            //arrange
            Node<int> head = null;

            //act
            Solver.AddLast(ref head, 8);

            //assert
            Assert.AreEqual(8, head.Next.Value);
        }

        [TestMethod]
        public void AddAtIndexTest()
        {
            //arrange
            var head = new Node<int>
                           {
                               Value = 3,
                               Next = new Node<int> { Value = 4, Next = new Node<int> { Value = 5 } }
                           };

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
            var head = new Node<int>
                           {
                               Value = 3,
                               Next = new Node<int> { Value = 4, Next = new Node<int> { Value = 5 } }
                           };

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
            var head = new Node<int>
                           {
                               Value = 3,
                               Next = new Node<int> { Value = 4, Next = new Node<int> { Value = 5 } }
                           };

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
            var head = new Node<int> { Value = 3 };

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
            var head = new Node<int> { Value = 3 };

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
            Node<int> head = null;

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
            Node<int> head = null;

            //act
            Solver.AddAtIndex(ref head, 8, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddAtIndexTestMinusOneNullItem()
        {
            //arrange
            Node<int> head = null;

            //act
            Solver.AddAtIndex(ref head, 8, 11);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddAtIndexTestSecondSingleItem()
        {
            //arrange
            var head = new Node<int> { Value = 3 };

            //act
            Solver.AddAtIndex(ref head, 8, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddAtIndexTestMinusOneSingleItem()
        {
            //arrange
            var head = new Node<int> { Value = 3 };

            //act
            Solver.AddAtIndex(ref head, 8, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddAtIndexTestSecondTwoItems()
        {
            //arrange
            var head = new Node<int> { Value = 3, Next = new Node<int> { Value = 4 } };

            //act
            Solver.AddAtIndex(ref head, 8, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddAtIndexTestMinusOneTwoItems()
        {
            //arrange
            var head = new Node<int> { Value = 3, Next = new Node<int> { Value = 4 } };

            //act
            Solver.AddAtIndex(ref head, 8, -1);
        }

        [TestMethod]
        public void DeleteTest()
        {
            //arrange
            var head = new Node<int> { Value = 3 };

            //act
            Solver.Delete(ref head, 0);

            //assert
            Assert.IsNull(head);
        }

        [TestMethod]
        public void DeleteTestTwoItems()
        {
            //arrange
            var head = new Node<int> { Value = 3, Next = new Node<int> { Value = 4 } };

            //act
            Solver.Delete(ref head, 0);

            //assert
            Assert.AreEqual(4, head.Value);
        }

        [TestMethod]
        public void DeleteTestTwoItemsLast()
        {
            //arrange
            var head = new Node<int> { Value = 3, Next = new Node<int> { Value = 4 } };

            //act
            Solver.Delete(ref head, 1);

            //assert
            Assert.AreEqual(3, head.Value);
            Assert.IsNull(head.Next);
        }

        [TestMethod]
        public void DeleteTestThreeItemsFirst()
        {
            //arrange
            var head = new Node<int>
                           {
                               Value = 3,
                               Next = new Node<int> { Value = 4, Next = new Node<int> { Value = 5 } }
                           };

            //act
            Solver.Delete(ref head, 1);

            //assert
            Assert.AreEqual(3, head.Value);
            Assert.AreEqual(5, head.Next.Value);
        }

        [TestMethod]
        public void DeleteTestThreeItemsMiddle()
        {
            //arrange
            var head = new Node<int>
                           {
                               Value = 3,
                               Next = new Node<int> { Value = 4, Next = new Node<int> { Value = 5 } }
                           };

            //act
            Solver.Delete(ref head, 1);

            //assert
            Assert.AreEqual(3, head.Value);
            Assert.AreEqual(5, head.Next.Value);
        }

        [TestMethod]
        public void DeleteTestThreeItemsLast()
        {
            //arrange
            var head = new Node<int>
                           {
                               Value = 3,
                               Next = new Node<int> { Value = 4, Next = new Node<int> { Value = 5 } }
                           };

            //act
            Solver.Delete(ref head, 2);

            //assert
            Assert.AreEqual(3, head.Value);
            Assert.AreEqual(4, head.Next.Value);
            Assert.IsNull(head.Next.Next);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteTestNull()
        {
            //arrange
            Node<int> head = null;

            //act
            Solver.Delete(ref head, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void DeleteTestThreeItemsMinusOne()
        {
            //arrange
            var head = new Node<int>
                           {
                               Value = 3,
                               Next = new Node<int> { Value = 4, Next = new Node<int> { Value = 5 } }
                           };

            //act
            Solver.Delete(ref head, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void DeleteTestThreeItemsIndexOutOfRange()
        {
            //arrange
            var head = new Node<int>
                           {
                               Value = 3,
                               Next = new Node<int> { Value = 4, Next = new Node<int> { Value = 5 } }
                           };

            //act
            Solver.Delete(ref head, 4);
        }
    }
}