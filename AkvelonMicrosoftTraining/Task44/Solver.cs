namespace Task44
{
    using System;

    /// <summary>
    /// Reverse a linked list
    /// </summary>
    /// <remarks>Custom single-linked list (without using standard .NET one).</remarks>
    public static class Solver
    {
        public static void ReverseNode<T>(ref Node<T> head)
        {
            if (head == null)
            {
                throw new ArgumentNullException("head");
            }
            var current = head;
            Node<T> prev = null;
            while (current != null)
            {
                var next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            head = prev;
        }
    }
}
