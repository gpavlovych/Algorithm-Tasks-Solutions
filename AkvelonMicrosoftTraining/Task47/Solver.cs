namespace Task47
{
    using System;

    /// <summary>
    /// Linked list manipulation: AddLast, AddAtIndex, Delete elements.
    /// </summary>
    /// <remarks>Use custom single-linked list (without .NET collections).</remarks>
    public static class Solver
    {
        public static void AddLast<T>(ref Node<T> head, T value)
        {
            if (head == null)
            {
                head = new Node<T>();
            }
            var current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new Node<T>() { Value = value };
        }

        public static void AddAtIndex<T>(ref Node<T> head, T value, long index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            var newNode = new Node<T>() { Value = value };
            var current = head;
            var previous = default(Node<T>);
            var currentIndex = 0;
            while (current != null)
            {
                if (currentIndex == index)
                {
                    newNode.Next = current;
                    if (previous != null)
                    {
                        previous.Next = newNode;
                    }
                    break;
                }
                previous = current;
                current = current.Next;
                currentIndex++;
            }
            if (currentIndex == index)
            {
                newNode.Next = current;
                if (previous != null)
                {
                    previous.Next = newNode;
                }
            }
            if (currentIndex < index)
            {
                throw new IndexOutOfRangeException();
            }
            if (currentIndex == 0)
            {
                head = newNode;
            }
        }

        public static void Delete<T>(ref Node<T> head, long index)
        {
            if (head == null)
            {
                throw new ArgumentNullException("linkedListNode");
            }
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            var current = head;
            var previous = default(Node<T>);
            var currentIndex = 0;
            while (current != null)
            {
                if (currentIndex == index)
                {
                    if (previous == null)
                    {
                        head = current.Next;
                        return;
                    }
                    previous.Next = current.Next;
                    break;
                }
                previous = current;
                current = current.Next;
                currentIndex++;
            }
            if (currentIndex < index)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
