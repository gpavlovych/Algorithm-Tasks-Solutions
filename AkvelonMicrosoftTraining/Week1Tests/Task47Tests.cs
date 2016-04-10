using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Week1.Tests
{
    [TestClass]
    public class Task47Tests
    {
        [TestMethod]
        public void AddLastTest()
        {
            //arrange
            var node = new Task47.Node<int> { Value = 3, Next = new Task47.Node<int>() { Value = 4 } };

            //act
            Task47.AddLast(node, 8);

            //assert
            Assert.AreEqual(8, node.Next.Next.Value);
        }

        [TestMethod]
        public void AddLastTestSingleItem()
        {
            //arrange
            var node = new Task47.Node<int> { Value = 3 };

            //act
            var actualNode = Task47.AddLast(node, 8);

            //assert
            Assert.AreEqual(8, actualNode.Next.Value);
        }

        [TestMethod]
        public void AddLastTestNull()
        {
            //act
            var actualNode = Task47.AddLast(null, 8);

            //assert
            Assert.AreEqual(8, actualNode.Next.Value);
        }

        [TestMethod]
        public void AddAtIndexTest()
        {
            //arrange
            var node = new Task47.Node<int>
                           {
                               Value = 3,
                               Next =
                                   new Task47.Node<int>
                                       {
                                           Value = 4,
                                           Next = new Task47.Node<int> { Value = 5 }
                                       }
                           };

            //act
            Task47.AddAtIndex(node, 8, 1);

            //assert
            Assert.AreEqual(3, node.Value);
            Assert.AreEqual(8, node.Next.Value);
            Assert.AreEqual(4, node.Next.Next.Value);
            Assert.AreEqual(5, node.Next.Next.Next.Value);
        }

        [TestMethod]
        public void AddAtIndexTestFirst()
        {
            //arrange
            var node = new Task47.Node<int>
                           {
                               Value = 3,
                               Next =
                                   new Task47.Node<int>
                                       {
                                           Value = 4,
                                           Next = new Task47.Node<int> { Value = 5 }
                                       }
                           };

            //act
            var newNode = Task47.AddAtIndex(node, 8, 0);

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
            var node = new Task47.Node<int>
                           {
                               Value = 3,
                               Next =
                                   new Task47.Node<int>
                                       {
                                           Value = 4,
                                           Next = new Task47.Node<int> { Value = 5 }
                                       }
                           };

            //act
            var newNode = Task47.AddAtIndex(node, 8, 3);

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
            var node = new Task47.Node<int> { Value = 3 };

            //act
            var newNode = Task47.AddAtIndex(node, 8, 1);

            //assert
            Assert.AreEqual(3, newNode.Value);
            Assert.AreEqual(8, newNode.Next.Value);
        }

        [TestMethod]
        public void AddAtIndexTestFirstSingleItem()
        {
            //arrange
            var node = new Task47.Node<int> { Value = 3 };

            //act
            var newNode = Task47.AddAtIndex(node, 8, 0);

            //assert
            Assert.AreEqual(8, newNode.Value);
            Assert.AreEqual(3, newNode.Next.Value);
        }

        [TestMethod]
        public void AddAtIndexTestFirstNullItem()
        {
            //act
            var newNode = Task47.AddAtIndex(null, 8, 0);

            //assert
            Assert.AreEqual(8, newNode.Value);
            Assert.IsNull(newNode.Next);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddAtIndexTestSecondNullItem()
        {
            //act
            Task47.AddAtIndex(null, 8, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddAtIndexTestMinusOneNullItem()
        {
            //act
            Task47.AddAtIndex(null, 8, 11);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddAtIndexTestSecondSingleItem()
        {
            //act
            Task47.AddAtIndex(new Task47.Node<int> { Value = 3 }, 8, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddAtIndexTestMinusOneSingleItem()
        {
            //act
            Task47.AddAtIndex(new Task47.Node<int> { Value = 3 }, 8, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddAtIndexTestSecondTwoItems()
        {
            //act
            Task47.AddAtIndex(new Task47.Node<int> { Value = 3, Next = new Task47.Node<int> { Value = 4 } }, 8, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddAtIndexTestMinusOneTwoItems()
        {
            //act
            Task47.AddAtIndex(new Task47.Node<int> { Value = 3, Next = new Task47.Node<int> { Value = 4 } }, 8, -1);
        }

        [TestMethod]
        public void DeleteTest()
        {
            //arrange
            var node = new Task47.Node<int> { Value = 3 };

            //act
            var newNode = Task47.Delete(node, 0);

            //assert
            Assert.IsNull(newNode);
        }

        [TestMethod]
        public void DeleteTestTwoItems()
        {
            //arrange
            var node = new Task47.Node<int> { Value = 3, Next = new Task47.Node<int> { Value = 4 } };

            //act
            var newNode = Task47.Delete(node, 0);

            //assert
            Assert.AreEqual(4, newNode.Value);
        }

        [TestMethod]
        public void DeleteTestTwoItemsLast()
        {
            //arrange
            var node = new Task47.Node<int> { Value = 3, Next = new Task47.Node<int> { Value = 4 } };

            //act
            var newNode = Task47.Delete(node, 1);

            //assert
            Assert.AreEqual(3, newNode.Value);
            Assert.IsNull(newNode.Next);
        }

        [TestMethod]
        public void DeleteTestThreeItemsFirst()
        {
            //arrange
            var node = new Task47.Node<int>
                           {
                               Value = 3,
                               Next =
                                   new Task47.Node<int>
                                       {
                                           Value = 4,
                                           Next = new Task47.Node<int> { Value = 5 }
                                       }
                           };

            //act
            var newNode = Task47.Delete(node, 1);

            //assert
            Assert.AreEqual(3, newNode.Value);
            Assert.AreEqual(5, newNode.Next.Value);
        }

        [TestMethod]
        public void DeleteTestThreeItemsMiddle()
        {
            //arrange
            var node = new Task47.Node<int>
                           {
                               Value = 3,
                               Next =
                                   new Task47.Node<int>
                                       {
                                           Value = 4,
                                           Next = new Task47.Node<int> { Value = 5 }
                                       }
                           };

            //act
            var newNode = Task47.Delete(node, 1);

            //assert
            Assert.AreEqual(3, newNode.Value);
            Assert.AreEqual(5, newNode.Next.Value);
        }

        [TestMethod]
        public void DeleteTestThreeItemsLast()
        {
            //arrange
            var node = new Task47.Node<int>
                           {
                               Value = 3,
                               Next =
                                   new Task47.Node<int>
                                       {
                                           Value = 4,
                                           Next = new Task47.Node<int> { Value = 5 }
                                       }
                           };

            //act
            var newNode = Task47.Delete(node, 2);

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
            Task47.Delete(default(Task47.Node<int>), -1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void DeleteTestThreeItemsMinusOne()
        {
            //arrange
            var node = new Task47.Node<int>
                           {
                               Value = 3,
                               Next =
                                   new Task47.Node<int>
                                       {
                                           Value = 4,
                                           Next = new Task47.Node<int> { Value = 5 }
                                       }
                           };

            //act
            Task47.Delete(node, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void DeleteTestThreeItemsIndexOutOfRange()
        {
            //arrange
            var node = new Task47.Node<int>
                           {
                               Value = 3,
                               Next =
                                   new Task47.Node<int>
                                       {
                                           Value = 4,
                                           Next = new Task47.Node<int> { Value = 5 }
                                       }
                           };

            //act
            Task47.Delete(node, 4);
        }
    }
}