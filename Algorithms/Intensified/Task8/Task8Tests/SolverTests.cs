using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task8;

namespace Task8Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void ModifyEmptyTest()
        {
            this.ModifyTest(new int[] { }, new int[] { });
        }

        [TestMethod]
        public void ModifySingleTest()
        {
            this.ModifyTest(new int[] {1 }, new int[] {1 });
        }

        [TestMethod]
        public void ModifyDoubleTest()
        {
            this.ModifyTest(new int[] { 1,2 }, new int[] { 1, 2 });
        }

        [TestMethod]
        public void ModifyThreeTest()
        {
            this.ModifyTest(new int[] { 1, 3, 2 }, new int[] { 1, 2, 3 });
        }

        [TestMethod]
        public void ModifySixTest()
        {
            this.ModifyTest(new int[] { 1, 6, 2, 5, 3, 4 }, new int[] { 1, 2, 3, 4, 5, 6 });
        }

        private void ModifyTest(int[] expectedOutput, int[] input)
        {
            // arrange
            var head = ArrayToList(input);

            // act
            Solver.Modify(ref head);

            // assert
            CollectionAssert.AreEqual(expectedOutput, ListToArray(head));
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