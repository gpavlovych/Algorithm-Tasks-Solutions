using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;

namespace Task2Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void FindNthElementFromTheEnd3()
        {
            //arrange
            var head = new Node(3)
                           {
                               Next = new Node(4)
                                          {
                                              Next = new Node(5)
                                                         {
                                                             Next = new Node(6)
                                                         }
                                          }
                           };

            //act
            var result = Solver.FindNthElementFromTheEnd(ref head, 3);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Value);
        }

        [TestMethod]
        public void FindNthElementFromTheEnd1()
        {
            //arrange
            var head = new Node(3)
                           {
                               Next = new Node(4)
                                          {
                                              Next = new Node(5)
                                                         {
                                                             Next = new Node(6)
                                                         }
                                          }
                           };

            //act
            var result = Solver.FindNthElementFromTheEnd(ref head, 1);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(6, result.Value);
        }

        [TestMethod]
        public void FindNthElementFromTheEnd0()
        {
            //arrange
            var head = new Node(3)
                           {
                               Next = new Node(4)
                                          {
                                              Next = new Node(5)
                                                         {
                                                             Next = new Node(6)
                                                         }
                                          }
                           };

            //act
            var result = Solver.FindNthElementFromTheEnd(ref head, 0);

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void FindNthElementFromTheEnd4()
        {
            //arrange
            var head = new Node(3)
                           {
                               Next = new Node(4)
                                          {
                                              Next = new Node(5)
                                                         {
                                                             Next = new Node(6)
                                                         }
                                          }
                           };

            //act
            var result = Solver.FindNthElementFromTheEnd(ref head, 4);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Value);
        }

        [TestMethod]
        public void FindNthElementFromTheEndEmptyList0()
        {
            //arrange
            Node head = null;

            //act
            var result = Solver.FindNthElementFromTheEnd(ref head, 0);

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindNthElementFromTheEndHeadLessThan0()
        {
            //arrange
            Node head = null;

            //act
            Solver.FindNthElementFromTheEnd(ref head, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindNthElementFromTheEndHeadExceedingLength()
        {
            //arrange
            Node head = null;

            //act
            Solver.FindNthElementFromTheEnd(ref head, 1);
        }
    }
}