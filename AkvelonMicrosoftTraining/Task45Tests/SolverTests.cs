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

        [TestMethod]
        public void AddSortedListTestToEmpty()
        {
            //arrange
            var item = 5;
            Node<int> head = null;

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

        private static Node<int> BuildTestLinkedList(int item, int start, int end)
        {
            var initialNode = new Node<int>() { Value = start };
            var currentNode = initialNode;
            for (var i = start + 1; i <= end; i++)
            {
                if (i != item)
                {
                    currentNode.Next = new Node<int>() { Value = i };
                    currentNode = currentNode.Next;
                }
            }
            return initialNode;
        }

        private static void VerifyLinkedList(Node<int> result, int start, int end)
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