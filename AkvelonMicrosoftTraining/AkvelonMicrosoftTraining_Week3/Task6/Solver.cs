namespace Task6
{
    /// <summary>
    /// 6. Please implement a function which returns mirror of a binary tree.
    /// </summary>
    /// <remarks>Ask questions: What is the data type which Node contains? is there any limitations? Can pointers in input data structure be changed?</remarks>
    public static class Solver
    {
        public static void Mirror(Node root)
        {
            if (root == null)
            {
                return;
            }

            Mirror(root.Left);

            Mirror(root.Right);

            var temp = root.Left;
            root.Left = root.Right;
            root.Right = temp;
        }
    }
}
