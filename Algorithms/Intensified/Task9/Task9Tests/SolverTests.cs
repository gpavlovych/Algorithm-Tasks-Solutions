using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task9;

namespace Task9Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SwapKthTestEmpty()
        {
            SwapKthTest(new int[] { }, new int[] { }, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SwapKthTestSingleTooMany()
        {
            SwapKthTest(new int[] {0}, new int[] {0}, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SwapKthTestDoubleTooMany()
        {
            SwapKthTest(new int[] {0, 1}, new int[] {0, 1}, 3);
        }

        [TestMethod]
        public void SwapKthTestSingle()
        {
            SwapKthTest(new int[] {0}, new int[] {0}, 0);
        }

        [TestMethod]
        public void SwapKthTestDouble()
        {
            SwapKthTest(new int[] {2, 1}, new int[] {1, 2}, 0);
        }

        [TestMethod]
        public void SwapKthTestTripleMiddle()
        {
            SwapKthTest(new int[] {2, 1, 3}, new int[] {2, 1, 3}, 1);
        }

        [TestMethod]
        public void SwapKthTestSix()
        {
            SwapKthTest(new int[] { 1, 7, 4, 5, 2, 8 }, new int[] { 1, 2, 4, 5, 7, 8 }, 1);
        }

        private static void SwapKthTest(int[] expectedOutput, int[]input, int k)
        {
            // arrange
            var head = ArrayToList(input);

            // act
            Solver.SwapKth(ref head, k);

            // assert
            var result = ListToArray(head);
            CollectionAssert.AreEqual(expectedOutput, result);
        }

        private static Node ArrayToList(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            Node result = null;
            Node current = null;
            for (var inputIndex = 0; inputIndex < input.Length; inputIndex++)
            {
                var next = new Node(input[inputIndex]);
                if (current != null)
                {
                    current.Next = next;
                }

                current = next;
                if (result == null)
                {
                    result = current;
                }
            }

            return result;
        }

        private static int[] ListToArray(Node head)
        {
            var resultCount = 0;
            for (var current = head; current != null; current = current.Next)
            {
                resultCount++;
            }

            var result = new int[resultCount];
            var resultIndex = 0;
            for (var current = head; current != null; current = current.Next)
            {
                result[resultIndex] = current.Value;
                resultIndex++;
            }

            return result;
        }
    }
}