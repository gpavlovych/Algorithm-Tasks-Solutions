namespace Task45
{
    using System;

    /// <summary>
    /// Add to the sorted list
    /// </summary>
    public static class Solver
    {
        public static Node<T> AddSortedList<T>(Node<T> list, T item) where T : IComparable<T>
        {
            var current = list;
            var prevNode = default(Node<T>);
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
                return newNode;
            }
            return list;
        }
    }
}
