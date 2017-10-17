using System;
using System.Collections.Generic;

namespace Task10
{ 
    internal class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; }

        public Node<T> Next { get; set; }

        public static T[] ToArray(Node<T> head)
        {
            var current = head;
            var count = 0;
            while (current != null)
            {
                current = current.Next;
                count++;
            }

            var result = new T[count];
            count = 0;
            current = head;
            while (current != null)
            {
                result[count] = current.Value;
                current = current.Next;
                count++;
            }

            return result;
        }
    }

    /// <summary>
    /// 10.Given an array of N integers and a sum value, please find all unique combinations of two numbers from the array which sum up to the given sum.
    /// For example: { 7, 1, 2, 3, 4, 5 }, sum = 9. Answer: (7, 2), (4, 5). Complexity O(N) or less.
    /// </summary>
    /// <remarks>Can we use HashSet? any limitations to input? what is the correct output format? yield return?</remarks>
    public static class Solver
    {
        public static int[][] GetCombinationsGivingSum(int[] input, int sum)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var items = new HashSet<int>();
            Node<int[]> head = null;
            for (var index = 0; index < input.Length; index++)
            {
                var currentItem = input[index];
                var counterPart = sum - currentItem;
                if (!items.Contains(currentItem))
                {
                    if (items.Contains(counterPart))
                    {
                        head = new Node<int[]>(new[] { currentItem, counterPart }) { Next = head };
                    }
                    else
                    {
                        items.Add(input[index]);
                    }
                }
            }

            return Node<int[]>.ToArray(head);
        } 
    }
}
