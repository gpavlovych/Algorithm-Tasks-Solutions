namespace Task47Tests
{
    using System;

    using BaseTests.Tests;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Task47;

    [TestClass]
    public class SolverTests: UnitTestBase
    {
        [TestMethod]
        public void AddLastTest()
        {
            //arrange
            var node = new Node<int> { Value = 3, Next = new Node<int>() { Value = 4 } };

            //act
            var lastNode = Solver.AddLast(node, 8);

            //assert
            Assert.AreEqual(8, lastNode.Next.Next.Value);
        }

        [TestMethod]
        public void AddLastTestSingleItem()
        {
            //arrange
            var node = new Node<int> { Value = 3 };

            //act
            var actualNode = Solver.AddLast(node, 8);

            //assert
            Assert.AreEqual(8, actualNode.Next.Value);
        }

        [TestMethod]
        public void AddLastTestNull()
        {
            //act
            var actualNode = Solver.AddLast(null, 8);

            //assert
            Assert.AreEqual(8, actualNode.Next.Value);
        }

        [TestMethod]
        public void AddAtIndexTest()
        {
            //arrange
            var node = new Node<int>
                           {
                               Value = 3,
                               Next = new Node<int> { Value = 4, Next = new Node<int> { Value = 5 } }
                           };

            //act
            var newNode = Solver.AddAtIndex(node, 8, 1);

            //assert
            Assert.AreEqual(3, newNode.Value);
            Assert.AreEqual(8, newNode.Next.Value);
            Assert.AreEqual(4, newNode.Next.Next.Value);
            Assert.AreEqual(5, newNode.Next.Next.Next.Value);
        }

        [TestMethod]
        public void AddAtIndexTestFirst()
        {
            //arrange
            var node = new Node<int>
                           {
                               Value = 3,
                               Next =
                                   new Node<int>
                                       {
                                           Value = 4,
                                           Next = new Node<int> { Value = 5 }
                                       }
                           };

            //act
            var newNode = Solver.AddAtIndex(node, 8, 0);

            //assert
            Assert.AreEqual(8, newNode.Value);
            Assert.AreEqual(3, newNode.Next.Value);
            Assert.AreEqual(4, newNode.Next.Next.Value);
            Assert.AreEqual(5, newNode.Next.Next.Next.Value);
        }

        [TestMethod]
        public void AddAtIndexTestLast()
        {
            //arrange
            var node = new Node<int>
                           {
                               Value = 3,
                               Next =
                                   new Node<int>
                                       {
                                           Value = 4,
                                           Next = new Node<int> { Value = 5 }
                                       }
                           };

            //act
            var newNode = Solver.AddAtIndex(node, 8, 3);

            //assert
            Assert.AreEqual(3, newNode.Value);
            Assert.AreEqual(4, newNode.Next.Value);
            Assert.AreEqual(5, newNode.Next.Next.Value);
            Assert.AreEqual(8, newNode.Next.Next.Next.Value);
        }

        [TestMethod]
        public void AddAtIndexTestLastSingleItem()
        {
            //arrange
            var node = new Node<int> { Value = 3 };

            //act
            var newNode = Solver.AddAtIndex(node, 8, 1);

            //assert
            Assert.AreEqual(3, newNode.Value);
            Assert.AreEqual(8, newNode.Next.Value);
        }

        [TestMethod]
        public void AddAtIndexTestFirstSingleItem()
        {
            //arrange
            var node = new Node<int> { Value = 3 };

            //act
            var newNode = Solver.AddAtIndex(node, 8, 0);

            //assert
            Assert.AreEqual(8, newNode.Value);
            Assert.AreEqual(3, newNode.Next.Value);
        }

        [TestMethod]
        public void AddAtIndexTestFirstNullItem()
        {
            //act
            var newNode = Solver.AddAtIndex(null, 8, 0);

            //assert
            Assert.AreEqual(8, newNode.Value);
            Assert.IsNull(newNode.Next);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddAtIndexTestSecondNullItem()
        {
            //act
            Solver.AddAtIndex(null, 8, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddAtIndexTestMinusOneNullItem()
        {
            //act
            Solver.AddAtIndex(null, 8, 11);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddAtIndexTestSecondSingleItem()
        {
            //act
            Solver.AddAtIndex(new Node<int> { Value = 3 }, 8, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddAtIndexTestMinusOneSingleItem()
        {
            //act
            Solver.AddAtIndex(new Node<int> { Value = 3 }, 8, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddAtIndexTestSecondTwoItems()
        {
            //act
            Solver.AddAtIndex(new Node<int> { Value = 3, Next = new Node<int> { Value = 4 } }, 8, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddAtIndexTestMinusOneTwoItems()
        {
            //act
            Solver.AddAtIndex(new Node<int> { Value = 3, Next = new Node<int> { Value = 4 } }, 8, -1);
        }

        [TestMethod]
        public void DeleteTest()
        {
            //arrange
            var node = new Node<int> { Value = 3 };

            //act
            var newNode = Solver.Delete(node, 0);

            //assert
            Assert.IsNull(newNode);
        }

        [TestMethod]
        public void DeleteTestTwoItems()
        {
            //arrange
            var node = new Node<int> { Value = 3, Next = new Node<int> { Value = 4 } };

            //act
            var newNode = Solver.Delete(node, 0);

            //assert
            Assert.AreEqual(4, newNode.Value);
        }

        [TestMethod]
        public void DeleteTestTwoItemsLast()
        {
            //arrange
            var node = new Node<int> { Value = 3, Next = new Node<int> { Value = 4 } };

            //act
            var newNode = Solver.Delete(node, 1);

            //assert
            Assert.AreEqual(3, newNode.Value);
            Assert.IsNull(newNode.Next);
        }

        [TestMethod]
        public void DeleteTestThreeItemsFirst()
        {
            //arrange
            var node = new Node<int>
                           {
                               Value = 3,
                               Next = new Node<int> { Value = 4, Next = new Node<int> { Value = 5 } }
                           };

            //act
            var newNode = Solver.Delete(node, 1);

            //assert
            Assert.AreEqual(3, newNode.Value);
            Assert.AreEqual(5, newNode.Next.Value);
        }

        [TestMethod]
        public void DeleteTestThreeItemsMiddle()
        {
            //arrange
            var node = new Node<int>
                           {
                               Value = 3,
                               Next =
                                   new Node<int>
                                       {
                                           Value = 4,
                                           Next = new Node<int> { Value = 5 }
                                       }
                           };

            //act
            var newNode = Solver.Delete(node, 1);

            //assert
            Assert.AreEqual(3, newNode.Value);
            Assert.AreEqual(5, newNode.Next.Value);
        }

        [TestMethod]
        public void DeleteTestThreeItemsLast()
        {
            //arrange
            var node = new Node<int>
                           {
                               Value = 3,
                               Next =
                                   new Node<int>
                                       {
                                           Value = 4,
                                           Next = new Node<int> { Value = 5 }
                                       }
                           };

            //act
            var newNode = Solver.Delete(node, 2);

            //assert
            Assert.AreEqual(3, newNode.Value);
            Assert.AreEqual(4, newNode.Next.Value);
            Assert.IsNull(newNode.Next.Next);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteTestNull()
        {
            //act
            Solver.Delete(default(Node<int>), -1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void DeleteTestThreeItemsMinusOne()
        {
            //arrange
            var node = new Node<int>
                           {
                               Value = 3,
                               Next =
                                   new Node<int>
                                       {
                                           Value = 4,
                                           Next = new Node<int> { Value = 5 }
                                       }
                           };

            //act
            Solver.Delete(node, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void DeleteTestThreeItemsIndexOutOfRange()
        {
            //arrange
            var node = new Node<int>
                           {
                               Value = 3,
                               Next =
                                   new Node<int>
                                       {
                                           Value = 4,
                                           Next = new Node<int> { Value = 5 }
                                       }
                           };

            //act
            Solver.Delete(node, 4);
        }
    }
}