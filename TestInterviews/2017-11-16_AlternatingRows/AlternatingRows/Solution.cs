using System;

namespace AlternatingRows
{
    /// <summary>
    /// You should print below number sequence 
    /// If(n= 3)
    /// then 
    /// 1*2*3 
    /// 7*8*9 
    /// 4*5*6 
    /// 
    /// if n=5 
    /// 1*2*3*4*5 
    /// 11*12*13*14*15 
    /// 21*22*23*24*25 
    /// 16*17*18*19*20 
    /// 6*7*8*9*10 
    ///
    /// Can anyone also tell me what kind of pattern it is? Implement code.
    ///
    /// </summary>
    public static class Solution
    {
        private class LinkedListNode<T>
        {
            public LinkedListNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; }

            public LinkedListNode<T> Next { get; set; }
        }


        /// <summary>
        /// Solution using LinkedListNode of arrays
        /// </summary>
        /// <param name="n"></param>
        public static void OutputAlternatingRowsArraysLinkedList(int n)
        {
            RequireNonNegative(n);

            LinkedListNode<int[]> start = null;
            LinkedListNode<int[]> current = null;

            //initialize linked list
            var currentValue = 0;
            for (var rowIndex = 0; rowIndex < n; rowIndex++)
            {
                var next = new LinkedListNode<int[]>(new int[n]);
                for (var columnIndex = 0; columnIndex < n; columnIndex++)
                {
                    currentValue++;
                    next.Value[columnIndex] = currentValue;
                }

                if (current != null)
                {
                    current.Next = next;
                }

                current = next;
                if (start == null)
                {
                    start = current;
                }
            }
            var last = current;

            current = start;
            for (var i = 0; i < n / 2; i++)
            {
                var next = current.Next;
                var oldLastNext = last.Next;
                last.Next = next;
                current.Next = next.Next;
                next.Next = oldLastNext;
                current = current.Next;
            }

            //print out linked list
            current = start;
            while (current != null)
            {
                for (var columnIndex = 0; columnIndex < n; columnIndex++)
                {
                    Console.Write(current.Value[columnIndex]);
                    if (columnIndex < n - 1)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }

                current = current.Next;
            }
        }

        /// <summary>
        /// Solution using LinkedListNode of integers
        /// </summary>
        /// <param name="n"></param>
        public static void OutputAlternatingRowsIntegersLinkedList(int n)
        {
            RequireNonNegative(n);

            //initialize linked list 0 to n*n
            LinkedListNode<int> start = null;
            LinkedListNode<int> current = null;
            for (var index = 1; index <= n*n; index++)
            {
                var next = new LinkedListNode<int>(index);
                if (current != null)
                {
                    current.Next = next;
                }

                current = next;
                if (start == null)
                {
                    start = current;
                }
            }
            var last = current;

            current = start;
            for (var i = 0; i < n / 2; i++)
            {
                for (var index = 0; index < n - 1; index++)
                {
                    current = current?.Next;
                }

                var end1StRow = current;
                for (var index = 0; index < n; index++)
                {
                    current = current?.Next;
                }

                var end2NdRow = current;
                var oldLast = last.Next;
                current = end2NdRow.Next;
                last.Next = end1StRow.Next;
                end1StRow.Next = end2NdRow.Next;
                end2NdRow.Next = oldLast;
            }

            //print linked list
            current = start;
            var currentIndex = 0;
            while (current != null)
            {
                Console.Write(current.Value);
                if (currentIndex < n - 1)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.WriteLine();
                }
                current = current.Next;
                currentIndex = (currentIndex + 1) % n;
            }
        }

        /// <summary>
        /// Naive 'bruteforce' approach
        /// </summary>
        /// <param name="n">Amount of rows</param>
        public static void OutputAlternatingRows(int n)
        {
            RequireNonNegative(n);

            for (var rowIndex = 0; rowIndex < n; rowIndex++)
            {
                var start = GetFirstNumberInRow(n, rowIndex);
                for (var columnIndex = 0; columnIndex < n; columnIndex++)
                {
                    var currentNumber = start + columnIndex;
                    Console.Write(currentNumber);
                    if (columnIndex < n - 1)
                    {
                        Console.Write("*");
                    }
                }

                Console.WriteLine();
            }
        }

        private static int GetFirstNumberInRow(int n, int rowIndex)
        {
            var start = 2 * rowIndex;
            if (rowIndex == n / 2)
            {
                start = n - 1;
            }
            else if (rowIndex > n / 2)
            {
                start = n - 1 - (rowIndex - n / 2) * 2 + n % 2;
            }

            start *= n;
            start += 1;
            return start;
        }

        private static void RequireNonNegative(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n), "n should be non-negative.");
            }
        }
    }
}
