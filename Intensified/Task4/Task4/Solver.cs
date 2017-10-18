using System;
using System.CodeDom;
using System.Runtime.ExceptionServices;

namespace Task4
{
    /// <summary>
    /// 4. Given two sorted lists and an integer k, merge lists up to maximum of k elements.
    /// </summary>
    /// <remarks>Assuming </remarks>
    public static class Solver
    {
        public static Node Merge(Node a, Node b, int k)
        {
            VerifySorted(a);
            VerifySorted(b);

            return MergeRecursiveInternal(a, b, k);
        }

        private static Node MergeRecursiveInternal(Node a, Node b, int k)
        {
            if (k < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(k), "k should not be negative");
            }

            if (k == 0)
            {
                return null;
            }

            Node result = null;

            if (a == null && b != null)
            {
                result = new Node(b.Value)
                {
                    Next = Merge(null, b.Next, k - 1)
                };
            }

            if (a != null && b == null)
            {
                result = new Node(a.Value)
                {
                    Next = Merge(a.Next, null, k - 1)
                };
            }

            if (a != null && b != null)
            {
                if (a.Value <= b.Value)
                {
                    result = new Node(a.Value)
                    {
                        Next = Merge(a.Next, b, k - 1)
                    };
                }
                else
                {
                    result = new Node(b.Value)
                    {
                        Next = Merge(a, b.Next, k - 1)
                    };
                }
            }

            return result;
        }

        private static void VerifySorted(Node list)
        {
            while (list?.Next != null)
            {
                if (list.Value > list.Next.Value)
                {
                    throw new ArgumentException(nameof(list), "Array should be sorted in ascending order");
                }

                list = list.Next;
            }
        }
    }
}