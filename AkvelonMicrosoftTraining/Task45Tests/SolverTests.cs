namespace Task45Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Task45;

    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void AddSortedListTest()
        {
            //arrange
            var item = 5;
            var head = BuildTestLinkedList(item, 1, item + 3);

            //act
            Solver.AddSortedList(ref head, item);

            //assert
            VerifyLinkedList(head, 1, item + 3);
        }

        /// <summary>
        /// Test how the sorted list containing duplicates is added with the new value less than duplicates
        /// (it will be added after other duplicates). 
        /// </summary>
        [TestMethod]
        public void AddSortedListDuplicatesTestBelowDuplicate()
        {
            //arrange
            Node head = new Node() { Value = 1, Next = new Node() { Value = 1, Next = new Node() { Value = 6 } } };

            //act
            Solver.AddSortedList(ref head, 0);

            //assert
            Assert.AreEqual(0, head.Value);
            Assert.AreEqual(1, head.Next.Value);
            Assert.AreEqual(1, head.Next.Next.Value);
            Assert.AreEqual(6, head.Next.Next.Next.Value);
            Assert.IsNull(head.Next.Next.Next.Next);
        }

        /// <summary>
        /// Test how the sorted list containing duplicates is added with the new value exceeding duplicates
        /// (it will be added after other duplicates). 
        /// </summary>
        [TestMethod]
        public void AddSortedListDuplicatesTest()
        {
            //arrange
            Node head = new Node() { Value = 1, Next = new Node() { Value = 1, Next = new Node() { Value = 6 } } };

            //act
            Solver.AddSortedList(ref head, 5);

            //assert
            Assert.AreEqual(1, head.Value);
            Assert.AreEqual(1, head.Next.Value);
            Assert.AreEqual(5, head.Next.Next.Value);
            Assert.AreEqual(6, head.Next.Next.Next.Value);
            Assert.IsNull(head.Next.Next.Next.Next);
        }

        /// <summary>
        /// Test how the sorted list containing duplicates is added with the new duplicate
        /// (it will be added before other duplicates). 
        /// </summary>
        [TestMethod]
        public void AddSortedListDuplicatesDublicateTest()
        {
            //arrange
            Node head = new Node() { Value = 1, Next = new Node() { Value = 1, Next = new Node() { Value = 6 } } };

            //act
            Solver.AddSortedList(ref head, 1);

            //assert
            Assert.AreEqual(1, head.Value);
            Assert.AreEqual(1, head.Next.Value);
            Assert.AreEqual(1, head.Next.Next.Value);
            Assert.AreEqual(6, head.Next.Next.Next.Value);
            Assert.IsNull(head.Next.Next.Next.Next);
        }

        [TestMethod]
        public void AddSortedListTestToEmpty()
        {
            //arrange
            var item = 5;
            Node head = null;

            //act
            Solver.AddSortedList(ref head, item);

            //assert
            Assert.AreEqual(item, head.Value);
            Assert.IsNull(head.Next);
        }

        [TestMethod]
        public void AddSortedListTestEnd()
        {
            //arrange
            var item = 9;
            var head = BuildTestLinkedList(item, 1, item - 1);

            //act
            Solver.AddSortedList(ref head, item);

            //assert
            VerifyLinkedList(head, 1, item);
        }

        [TestMethod]
        public void AddSortedListTestBeginning()
        {
            //arrange
            var item = 0;
            var head = BuildTestLinkedList(item, 1, 8);

            //act
            Solver.AddSortedList(ref head, item);

            //assert
            VerifyLinkedList(head, 0, 8);
        }

        private static Node BuildTestLinkedList(int item, int start, int end)
        {
            var initialNode = new Node() { Value = start };
            var currentNode = initialNode;
            for (var i = start + 1; i <= end; i++)
            {
                if (i != item)
                {
                    currentNode.Next = new Node() { Value = i };
                    currentNode = currentNode.Next;
                }
            }
            return initialNode;
        }

        private static void VerifyLinkedList(Node result, int start, int end)
        {
            for (var i = start; i <= end; i++)
            {
                Assert.AreEqual(i, result.Value);
                result = result.Next;
            }
            Assert.IsNull(result);
        }
    }
}