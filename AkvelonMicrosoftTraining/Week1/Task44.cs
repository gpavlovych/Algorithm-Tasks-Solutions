using System;
using System.Collections.Generic;

namespace Week1
{
    /// <summary>
    /// Reverse a linked list
    /// </summary>
    public static class Task44
    {
        public class Node<T>
        {
            public T Value { get; set; }

            public Node<T> Next { get; set; }
        }

        public static LinkedList<T> ReverseLinkedList<T>(LinkedList<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }
            var currentNode = list.First;
            var result = new LinkedList<T>();
            while (currentNode != null)
            {
                var newNode = new LinkedListNode<T>(currentNode.Value);

                result.AddFirst(newNode);
                currentNode = currentNode.Next;
            }
            return result;
        }

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
