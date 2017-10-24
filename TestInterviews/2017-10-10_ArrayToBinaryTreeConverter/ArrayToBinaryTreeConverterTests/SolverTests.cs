using System;
using ArrayToBinaryTreeConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrayToBinaryTreeConverterTests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConvertToTreeNullTest()
        {
            ConvertToTreeTest(null, null);
        }

        [TestMethod]
        public void ConvertToTreeEmptyTest()
        {
            ConvertToTreeTest(null, new int[] { });
        }

        [TestMethod]
        public void ConvertToTreeSingleTest()
        {
            ConvertToTreeTest(new TreeNode(1), new int[] { 1 });
        }

        [TestMethod]
        public void ConvertToTreeDoubleTest()
        {
            ConvertToTreeTest(new TreeNode(2) { Child1 = new TreeNode(1) }, new int[] { 1, 2 });
        }

        [TestMethod]
        public void ConvertToTreeTripleTest()
        {
            ConvertToTreeTest(new TreeNode(2) { Child1 = new TreeNode(1), Child2 = new TreeNode(3) }, new int[] { 1, 2, 3});
        }

        private void ConvertToTreeTest(TreeNode expectedNode, int[] inputArray)
        {
            // act
            var result = Solver.ConvertToTree(inputArray);

            // assert
            AssertTreeNodeRecursively(expectedNode, result);
        }

        private void AssertTreeNodeRecursively(TreeNode expectedNode, TreeNode actualNode)
        {
            if (expectedNode == null)
            {
                Assert.IsNull(actualNode);
            }

            else
            {
                Assert.AreEqual(expectedNode?.Value, actualNode?.Value);
                AssertTreeNodeRecursively(expectedNode?.Child1, actualNode?.Child1);
                AssertTreeNodeRecursively(expectedNode?.Child2, actualNode?.Child2);
            }
        }
    }
}
