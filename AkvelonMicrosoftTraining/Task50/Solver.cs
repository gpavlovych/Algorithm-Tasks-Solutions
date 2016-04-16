namespace Task50
{
    using System;

    /// <summary>
    /// Write a function to find the depth of a binary tree.
    /// </summary>
    public static class Solver
    {
        public static int FindBinaryTreeDepth(BinaryTreeNode topNode)
        {
            if (topNode == null)
            {
                return 0;
            }
            var leftDepth = FindBinaryTreeDepth(topNode.LeftChild);
            var rightDepth = FindBinaryTreeDepth(topNode.RightChild);
            return Math.Max(leftDepth + 1, rightDepth + 1);
        }
    }
}
