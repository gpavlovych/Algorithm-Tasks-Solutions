namespace Task5
{
    /// <summary>
    /// 5. Convert a binary search tree to a sorted double-linked list. We can only change the target of pointers, but cannot create any new nodes.
    /// </summary>
    /// <remarks>Ask questions: what type of node data should be there? is there any limitations to node data?</remarks>
    public static class Solver
    {
        private static void BinaryTree2DoublyLinkedListImpl(Node root)
        {
            if (root == null)
            {
                return;
            }

            if (root.Left != null)
            {
                var left = root.Left;
                BinaryTree2DoublyLinkedListImpl(left);
                while (left.Right != null)
                {
                    left = left.Right;
                }

                left.Right = root;
                root.Left = left;
            }

            if (root.Right != null)
            {
                var right = root.Right;
                BinaryTree2DoublyLinkedListImpl(right);
                while (right.Left != null)
                {
                    right = right.Left;
                }

                right.Left = root;
                root.Right = right;
            }
        }

        public static Node BinaryTree2DoublyLinkedList(Node root)
        {
            if (root == null)
            {
                return root;
            }

            BinaryTree2DoublyLinkedListImpl(root);

            while (root.Left != null)
            {
                root = root.Left;
            }

            return root;
        }
    }
}
