using System;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4;

namespace Task4Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MergeTestNegativeK()
        {
            this.MergeTest(new int[] { }, -1, new int[] { }, new int[] { });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MergeTestUnsortedArg1()
        {
            this.MergeTest(new int[] { }, 0, new int[] {2, 1}, new int[] {1, 2});
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MergeTestUnsortedArg2()
        {
            this.MergeTest(new int[] { }, 0, new int[] { 1, 2 }, new int[] { 4, 3 });
        }

        [TestMethod]
        public void MergeTestZero()
        {
            this.MergeTest(new int[] { }, 0, new int[] { }, new int[] { });
        }

        [TestMethod]
        public void MergeTestPositiveOne()
        {
            this.MergeTest(new int[] { 1 }, 1, new int[] { 1,2 }, new int[] {1,24,25 });
        }

        [TestMethod]
        public void MergeTestPositiveThree()
        {
            this.MergeTest(new int[] {1, 1, 2, 24}, 4, new int[] {1, 2}, new int[] {1, 24, 25});
        }

        private void MergeTest(int[] expectedOutput, int k, int[] a, int[] b)
        {
            //assert
            var lst1 = ArrayToList(a);
            var lst2 = ArrayToList(b);

            //act
            var result = ListToArray(Solver.Merge(lst1, lst2, k));

            //assert
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