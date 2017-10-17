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
        private static void DeleteNode(ref Node head, Node node)
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

        private static IEnumerable<Node> GetValues(Node head) 
        {
            while (head != null)
            {
                yield return head;
                head = head.Next;
            }
        }

        public static void DeleteByValue(ref Node head, int value)
        {
            foreach (var node in GetValues(head))
            {
                if (node.Value == value)
                {
                    DeleteNode(ref head, node);
                }
            }
        }

        public static void DeleteAtIndex(ref Node head, int index)
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
