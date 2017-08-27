using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task6;

namespace Task6Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void MirrorTestNull()
        {
            // arrange
            Node root = null;

            // act
            Solver.Mirror(root);

            // assert
            Assert.IsNull(root);
        }

        [TestMethod]
        public void MirrorTestSingleNode()
        {
            // arrange
            Node root = new Node(5);

            // act
            Solver.Mirror(root);

            // assert
            Assert.AreEqual(5, root.Value);
            Assert.IsNull(root.Left);
            Assert.IsNull(root.Right);
        }

        [TestMethod]
        public void MirrorTestRightNode()
        {
            // arrange
            Node root = new Node(5) { Right = new Node(6) };

            // act
            Solver.Mirror(root);

            // assert
            Assert.AreEqual(5, root.Value);
            Assert.AreEqual(6, root.Left.Value);
            Assert.IsNull(root.Right);
        }

        [TestMethod]
        public void MirrorTestLeftNode()
        {
            // arrange
            Node root = new Node(5) { Left = new Node(6) };

            // act
            Solver.Mirror(root);

            // assert
            Assert.AreEqual(5, root.Value);
            Assert.AreEqual(6, root.Right.Value);
            Assert.IsNull(root.Left);
        }

        [TestMethod]
        public void MirrorTestRightLeftNode()
        {
            // arrange
            Node root = new Node(5) { Left = new Node(6), Right=new Node(7) };

            // act
            Solver.Mirror(root);

            // assert
            Assert.AreEqual(5, root.Value);
            Assert.AreEqual(6, root.Right.Value);
            Assert.IsNull(root.Right.Right);
            Assert.IsNull(root.Right.Left);
            Assert.AreEqual(7, root.Left.Value);
            Assert.IsNull(root.Left.Right);
            Assert.IsNull(root.Left.Left);
        }

        [TestMethod]
        public void MirrorTest2LevelTreeNode()
        {
            // arrange
            Node root = new Node(4) { Left = new Node(2) { Left = new Node(1), Right = new Node(3) }, Right = new Node(5) };

            // act
            Solver.Mirror(root);

            // assert
            Assert.AreEqual(4, root.Value);
            Assert.AreEqual(5, root.Left.Value);
            Assert.IsNull(root.Left.Right);
            Assert.IsNull(root.Left.Left);
            Assert.AreEqual(2, root.Right.Value);
            Assert.AreEqual(3, root.Right.Left.Value);
            Assert.IsNull(root.Right.Left.Left);
            Assert.IsNull(root.Right.Left.Right);
            Assert.AreEqual(1, root.Right.Right.Value);
            Assert.IsNull(root.Right.Right.Left);
            Assert.IsNull(root.Right.Right.Right);
        }
    }
}
