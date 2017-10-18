namespace Task47
{
    using System;

    /// <summary>
    /// Linked list manipulation: AddLast, AddAtIndex, Delete elements.
    /// </summary>
    /// <remarks>Use custom single-linked list (without .NET collections).</remarks>
    public static class Solver
    {
        public static void AddLast(ref Node headNode, int value)
        {
            if (headNode == null)
            {
                headNode = new Node();
            }
            var currentNode = headNode;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }
            currentNode.Next = new Node() { Value = value };
        }

        public static void AddAtIndex(ref Node headNode, int value, int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            var newNode = new Node() { Value = value };
            var current = headNode;
            Node previous = null;
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
                headNode = newNode;
            }
        }

        private static void DeleteNode(ref Node head, Node previousNode, Node deletedNode)
        {
            if (previousNode != null)
            {
                previousNode.Next = deletedNode.Next;
            }
            else
            {
                head = deletedNode.Next;
            }
        }

        public static void DeleteAtIndex(ref Node headNode, int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            var currentNode = headNode;
            var currentNodeIndex = 0;
            Node previousNode = null;
            while (currentNode != null)
            {
                if (currentNodeIndex == index)
                {
                    DeleteNode(ref headNode, previousNode, currentNode);
                    return;
                }
                previousNode = currentNode;
                currentNode = currentNode.Next;
                currentNodeIndex++;
            }
            if (currentNodeIndex <= index)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public static void DeleteByValue(ref Node headNode, int value)
        {
            var currentNode = headNode;
            Node previousNode = null;
            while (currentNode != null)
            {
                if (currentNode.Value == value)
                {
                    DeleteNode(ref headNode, previousNode, currentNode);
                }
                else
                {
                    previousNode = currentNode;
                }
                currentNode = currentNode.Next;
            }
        }
    }
}
