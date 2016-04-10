using System;

namespace Week1
{
    public static class Task47
    {
        public class Node<T>
        {
            public T Value { get; set; }

            public Node<T> Next { get; set; }
        }

        public static Node<T> AddLast<T>(Node<T> linkedListNode, T value)
        {
            if (linkedListNode == null)
            {
                linkedListNode = new Node<T>();
            }
            var current = linkedListNode;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new Node<T>() { Value = value };
            return linkedListNode;
        }

        public static Node<T> AddAtIndex<T>(Node<T> linkedListNode, T value, long index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            var newNode = new Node<T>() { Value = value };
            var current = linkedListNode;
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
                return newNode;
            }
            return linkedListNode;
        }

        public static Node<T> Delete<T>(Node<T> linkedListNode, long index)
        {
            if (linkedListNode == null)
            {
                throw new ArgumentNullException("linkedListNode");
            }
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            var current = linkedListNode;
            var previous = default(Node<T>);
            var currentIndex = 0;
            while (current != null)
            {
                if (currentIndex == index)
                {
                    if (previous == null)
                    {
                        return current.Next;
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
            return linkedListNode;
        }
    }
}
