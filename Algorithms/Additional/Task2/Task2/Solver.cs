using System;

namespace Task2
{
    /// <summary>
    /// 2. Given a linked list find the N-th element from the end of the list.
    /// </summary>
    /// <remarks>TODO put here answers of additional questions which help successfully solve the task.</remarks>
    public static class Solver
    {
        public static Node FindNthElementFromTheEnd(ref Node head, int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException("n", "must be between 0 and linked list size");
            }
            var currentNthNode = head;
            for (var i = 0; i < n; i++)
            {
                if (currentNthNode == null)
                {
                    throw new ArgumentOutOfRangeException("n", "must be between 0 and linked list size");
                }
                currentNthNode = currentNthNode.Next;
            }
            var currentNode = head;
            while (currentNthNode != null)
            {
                currentNthNode = currentNthNode.Next;
                currentNode = currentNode.Next;
            }
            return currentNode;
        }
    }
}
