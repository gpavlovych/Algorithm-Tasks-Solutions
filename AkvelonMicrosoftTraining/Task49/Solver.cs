namespace Task49
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Delete an element from a doubly linked list.
    /// </summary>
    /// <remarks>
    /// Use custom double-linked list without make use of .NET collections.
    /// Item should be deleted by value and index.
    /// </remarks>
    public static class Solver
    {
        private static void DeleteNode<T>(ref Node<T> head, Node<T> node) where T : IComparable<T>
        {
            if (head == node)
            {
                head = node.Next;
            }
            if (node.Previous != null)
            {
                node.Previous.Next = node.Next;
            }
            if (node.Next != null)
            {
                node.Next.Previous = node.Previous;
            }
        }

        private static IEnumerable<Node<T>> GetValues<T>(Node<T> head) where T : IComparable<T>
        {
            while (head != null)
            {
                yield return head;
                head = head.Next;
            }
        }

        public static void DeleteNodesHavingValue<T>(ref Node<T> head, T value) where T : IComparable<T>
        {
            foreach (var node in GetValues(head))
            {
                if (node.Value.CompareTo(value) == 0)
                {
                    DeleteNode(ref head, node);
                }
            }
        }

        public static void DeleteNodeAt<T>(ref Node<T> head, int index) where T : IComparable<T>
        {
            var currentIndex = 0;
            foreach (var node in GetValues(head))
            {
                if (currentIndex == index)
                {
                    DeleteNode(ref head, node);
                    return;
                }
                currentIndex ++;
            }
            throw new ArgumentOutOfRangeException();
        }
    }
}
