namespace Task44
{
    using System;

    /// <summary>
    /// Reverse a linked list
    /// </summary>
    public static class Solver
    {
        public static Node<T> ReverseNode<T>(Node<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }
            var current = node;
            var prev = default(Node<T>);
            while (current != null)
            {
                var next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            return prev;
        }
    }
}
