namespace Task76
{
    /// <summary>
    /// 76. Please implement a function which returns mirror of a binary tree.
    /// </summary>
    public static class Solver
    {
        public static void Mirror(BinaryTreeNode root)
        {
            if (root != null)
            {
                Mirror(root.LeftChild);
                Mirror(root.RightChild);
                var temp = root.LeftChild;
                root.LeftChild = root.RightChild;
                root.RightChild = temp;
            }
        }
    }
}
