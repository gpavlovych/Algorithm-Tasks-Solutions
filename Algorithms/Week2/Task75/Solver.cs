using System;

namespace Task75
{
    /// <summary>
    /// 75. Convert a binary search tree to a sorted double-linked list. 
    /// We can only change the target of pointers, but cannot create any new nodes.
    /// </summary>
    public static class Solver
    {
        public static BinaryTreeNode Convert(BinaryTreeNode root)
        {
            if (!IsBST(root))
            {
                throw new ArgumentException("Not a BST");
            }

            BinaryTreeNode lastNodeInList = null;
            ConvertNode(root, ref lastNodeInList);

            // lastNodeInList points to the tail of double-linked list,
            // but we need to return its head
            BinaryTreeNode headOfList = lastNodeInList;
            while (headOfList != null && headOfList.LeftChild != null)
                headOfList = headOfList.LeftChild;

            return headOfList;
        }

        private static bool IsBST(BinaryTreeNode root)
        {
            return IsBST(root, int.MinValue, int.MaxValue);
        }

        private static bool IsBST(BinaryTreeNode root, int min, int max)
        {
            // an empty tree is BST
            if (root == null)
                return true;

            // false if this node violates the min/max constraint
            if (root.Value < min || root.Value > max)
                return false;

            // otherwise check the subtrees recursively, tightening the min or max constraint
            return IsBST(root.LeftChild, min, root.Value - 1) && // Allow only distinct values
                   IsBST(root.RightChild, root.Value + 1, max); // Allow only distinct values
        }

        private static void ConvertNode(BinaryTreeNode node, ref BinaryTreeNode lastNodeInList)
        {
            if (node == null)
                return;

            BinaryTreeNode current = node;

            if (current.LeftChild != null)
                ConvertNode(current.LeftChild, ref lastNodeInList);

            current.LeftChild = lastNodeInList;
            if (lastNodeInList != null)
                lastNodeInList.RightChild = current;

            lastNodeInList = current;

            if (current.RightChild != null)
                ConvertNode(current.RightChild, ref lastNodeInList);
        }
    }
}
