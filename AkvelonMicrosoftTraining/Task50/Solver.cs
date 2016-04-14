namespace Task50
{
    using System.Collections.Generic;

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
            int maxDepth = 0;
            Stack<BinaryTreeNode> stack = new Stack<BinaryTreeNode>();
            BinaryTreeNode previous = null;
            stack.Push(topNode);
            while (stack.Count > 0)
            {
                BinaryTreeNode current = stack.Peek();
                // we are traversing down the tree
                if (previous == null || previous.LeftChild == current || previous.RightChild == current)
                {
                    if (current.LeftChild != null) stack.Push(current.LeftChild);
                    else if (current.RightChild != null) stack.Push(current.RightChild);
                }
                // we are traversing up the tree from the left
                else if (current.LeftChild == previous)
                {
                    if (current.RightChild != null)
                    {
                        stack.Push(current.RightChild);
                    }
                }
                // we are traversing up the tree from the right
                else
                {
                    stack.Pop();
                }
                previous = current;
                if (stack.Count > maxDepth) maxDepth = stack.Count;
            }
            return maxDepth;
        }
    }
}
