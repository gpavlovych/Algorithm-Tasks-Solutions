namespace Task45
{
    using System;

    /// <summary>
    /// Insert in a sorted list.
    /// </summary>
    /// <remarks>Use custom single-linked list (without .NET collections).</remarks>
    public static class Solver
    {
        public static void AddSortedList(ref Node head, int item)
        {
            var current = head;
            Node prevNode = null;
            //while current item is strictly below the inserted one, 
            //go ahead to next item
            while (current != null && current.Value < item)
            {
                prevNode = current;
                current = current.Next;
            }
            //insert new item before current item
            var newNode = new Node() { Next = current, Value = item };
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
