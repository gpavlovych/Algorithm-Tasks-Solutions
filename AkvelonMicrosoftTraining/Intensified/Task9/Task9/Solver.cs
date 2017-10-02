using System;
using System.Runtime;
using System.Runtime.Serialization.Formatters;

namespace Task9
{
    /// <summary>
    /// 9. Swap the elements in K-th position from the start and end of a link list. Eg.
    /// input: list: 1,2,4,5,7,8; K=2
    /// output: 1,7,4,5,2,8.
    /// </summary>
    public static class Solver
    {
        public static void SwapKth(ref Node head, int k)
        {
            if (head == null)
            {
                throw new ArgumentNullException(nameof(head));
            }

            var kNodeStart = head;
            Node kNodeStartPrevious = null;
            for (var i = 0; i < k; i++)
            {
                if (kNodeStart == null)
                {
                    throw new ArgumentOutOfRangeException(nameof(k), $"k should be less than list elements count ({i})");
                }

                kNodeStartPrevious = kNodeStart;
                kNodeStart = kNodeStart.Next;
            }

            var kNodeEnd = head;
            Node kNodeEndPrevious = null;
            var endIndex = k;
            for (var end = kNodeStart; end.Next != null; end = end.Next)
            {
                kNodeEndPrevious = kNodeEnd;
                kNodeEnd = kNodeEnd.Next;
                endIndex++;
            }

            if (kNodeEndPrevious != null)
            {
                kNodeEndPrevious.Next = kNodeStart;
            }

            if (kNodeStartPrevious != null)
            {
                kNodeStartPrevious.Next = kNodeEnd;
            }

            var temp = kNodeEnd.Next;
            kNodeEnd.Next = kNodeStart.Next;
            kNodeStart.Next = temp;

            if (k == 0)
            {
                head = kNodeEnd;
            }

            if (k == endIndex)
            {
                head = kNodeStart;
            }
        }
    }
}