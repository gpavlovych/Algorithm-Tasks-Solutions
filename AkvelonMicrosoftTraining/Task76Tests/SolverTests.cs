using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Task76.Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void MirrorTest9()
        {
            Mirror(9);
        }

        [TestMethod]
        public void MirrorTest3()
        {
            Mirror(3);
        }

        [TestMethod]
        public void MirrorTest2()
        {
            Mirror(2);
        }

        [TestMethod]
        public void MirrorTest1()
        {
            Mirror(1);
        }

        [TestMethod]
        public void MirrorTestEmpty()
        {
            Mirror(0);
        }

        #region Helper methods

        private static void Mirror(int number)
        {
            //arrange
            var input = new int[number];
            for (var i = 0; i < input.Length; i++)
            {
                input[ i ] = i + 1;
            }
            BinaryTreeNode parentNode = BuildTree(input, 0, input.Length - 1);

            //act
            Solver.Mirror(parentNode);

            //assert
            var result = new List<int>();
            InOrder(parentNode, nodeValue => result.Add(nodeValue));
            Assert.AreEqual(input.Length, result.Count);
            for (var i = 0; i < input.Length; i++)
                Assert.AreEqual(input[ i ], result[ input.Length - i - 1 ]);
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

        public static void InOrder(BinaryTreeNode node, Action<int> visitNodeAction)
        {
            if (node != null)
            {
                InOrder(node.LeftChild, visitNodeAction);
                if (visitNodeAction != null)
                {
                    visitNodeAction(node.Value);
                }
                InOrder(node.RightChild, visitNodeAction);
            }
        }

        #endregion Helper methods
    }
}