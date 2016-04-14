namespace Task45
{
    using System;

    /// <summary>
    /// Insert in a sorted list.
    /// </summary>
    /// <remarks>Use custom single-linked list (without .NET collections).</remarks>
    public static class Solver
    {
        public static void AddSortedList<T>(ref Node<T> head, T item) where T : IComparable<T>
        {
            var current = head;
            Node<T> prevNode = null;
            while (current != null && current.Value.CompareTo(item) < 0)
            {
                prevNode = current;
                current = current.Next;
            }
            var newNode = new Node<T>() { Next = current, Value = item };
            if (prevNode != null)
            {
                prevNode.Next = newNode;
            }
            if (prevNode == null)
            {
                head = newNode;
            }
        }
    }
}
