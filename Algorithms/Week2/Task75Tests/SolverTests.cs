using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Task75.Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void ConvertTestNine()
        {
            ConvertTest(9);
        }

        [TestMethod]
        public void ConvertTestTriple()
        {
            ConvertTest(3);
        }

        [TestMethod]
        public void ConvertTestDouble()
        {
            ConvertTest(2);
        }

        [TestMethod]
        public void ConvertTestSingle()
        {
            ConvertTest(1);
        }

        [TestMethod]
        public void ConvertTestNull()
        {
            var head = Solver.Convert(null);
            Assert.IsNull(head);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConvertTestInvalidBstLeftChildGreater()
        {
            Solver.Convert(
                new BinaryTreeNode(2)
                    {
                        LeftChild = new BinaryTreeNode(3)
                    });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConvertTestInvalidBstRightChildLess()
        {
            Solver.Convert(
                new BinaryTreeNode(2)
                    {
                        RightChild = new BinaryTreeNode(1)
                    });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConvertTestInvalidBstLeftChildRightChildGreater()
        {
            Solver.Convert(
                new BinaryTreeNode(3)
                    {
                        LeftChild = new BinaryTreeNode(2)
                                        {
                                            LeftChild = new BinaryTreeNode(1),
                                            RightChild = new BinaryTreeNode(4)
                                        },
                        RightChild = new BinaryTreeNode(5)
                    });
        }
        
        #region Helper methods

        private static void ConvertTest(int number)
        {
            //arrange
            var input = new int[number];
            for (var i = 0; i < input.Length; i++)
            {
                input[ i ] = i + 1;
            }
            BinaryTreeNode parentNode = BuildTree(input, 0, input.Length - 1);

            //act
            var head = Solver.Convert(parentNode);

            //assert
            BinaryTreeNode expectedLeft = null;
            for (var i = 0; i < input.Length; i++)
            {
                Assert.AreSame(expectedLeft, head.LeftChild);
                Assert.AreEqual(input[ i ], head.Value);
                expectedLeft = head;
                head = head.RightChild;
            }
            Assert.IsNull(head);
        }

        private static BinaryTreeNode BuildTree(int[] input, int start, int end)
        {
            if (start > end)
            {
                return null;
            }
            int mid = ( start + end ) / 2;
            BinaryTreeNode root = new BinaryTreeNode(input[ mid ])
                                      {
                                          LeftChild = BuildTree(input, start, mid - 1),
                                          RightChild = BuildTree(input, mid + 1, end)
                                      };
            return root;
        }

        #endregion Helper methods
    }
}