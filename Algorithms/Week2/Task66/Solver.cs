using System;
using System.IO;

namespace Task66
{
    /// <summary>
    /// 66.Given a binary tree with nodes, print out the values in pre-order/in-order/post-order without using any extra space.
    /// </summary>
    /// <remarks>Recursive solutions are acceptable for tasks related to tree</remarks>
    public static class Solver
    {
        public static void PreOrderPrint(TextWriter writer, BinaryTreeNode node)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            if (node != null)
            {
                writer.Write("{0} ", node.Value);
                PreOrderPrint(writer, node.LeftChild);
                PreOrderPrint(writer, node.RightChild);
            }
        }

        public static void InOrderPrint(TextWriter writer, BinaryTreeNode node)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            if (node != null)
            {
                InOrderPrint(writer, node.LeftChild);
                writer.Write("{0} ", node.Value);
                InOrderPrint(writer, node.RightChild);
            }
        }

        public static void PostOrderPrint(TextWriter writer, BinaryTreeNode node)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            if (node != null)
            {
                PostOrderPrint(writer, node.LeftChild);
                PostOrderPrint(writer, node.RightChild);
                writer.Write("{0} ", node.Value);
            }
        }
    }
}
