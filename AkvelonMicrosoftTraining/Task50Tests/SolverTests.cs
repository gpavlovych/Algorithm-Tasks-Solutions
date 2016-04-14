namespace Task50Tests
{
    using BaseTests.Tests;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Task50;

    [TestClass]
    public class SolverTests: UnitTestBase
    {
        [TestMethod]
        public void FindBinaryTreeDepth0Test()
        {
            //act
            var depth = Solver.FindBinaryTreeDepth(null);

            //assert
            Assert.AreEqual(0, depth);
        }

        [TestMethod]
        public void FindBinaryTreeDepthTest()
        {
            //arrange
            var tree = new BinaryTreeNode();

            //act
            var depth = Solver.FindBinaryTreeDepth(tree);

            //assert
            Assert.AreEqual(1, depth);
        }

        [TestMethod]
        public void FindBinaryTreeDepthTest3()
        {
            //arrange
            var tree = new BinaryTreeNode()
                           {
                               LeftChild = new BinaryTreeNode() { RightChild = new BinaryTreeNode() },
                               RightChild = new BinaryTreeNode()
                           };

            //act
            var depth = Solver.FindBinaryTreeDepth(tree);

            //assert
            Assert.AreEqual(3, depth);
        }
    }
}
