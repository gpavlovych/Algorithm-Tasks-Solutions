namespace Task45Tests
{
    using BaseTests.Tests;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Task45;

    [TestClass]
    public class SolverTests : UnitTestBase
    {
        [TestMethod]
        public void AddSortedListTest()
        {
            //arrange
            var item = 5;
            var initialNode = BuildTestLinkedList(item, 1, item + 3);

            //act
            var result = Solver.AddSortedList(initialNode, item);

            //assert
            VerifyLinkedList(result, 1, item + 3);
        }

        [TestMethod]
        public void AddSortedListTestToEmpty()
        {
            //arrange
            var item = 5;

            //act
            var result = Solver.AddSortedList(null, item);

            //assert
            Assert.AreEqual(item, result.Value);
            Assert.IsNull(result.Next);
        }

        [TestMethod]
        public void AddSortedListTestEnd()
        {
            //arrange
            var item = 9;
            var initialList = BuildTestLinkedList(item, 1, item - 1);

            //act
            var result = Solver.AddSortedList(initialList, item);

            //assert
            VerifyLinkedList(result, 1, item);
        }

        [TestMethod]
        public void AddSortedListTestBeginning()
        {
            //arrange
            var item = 0;
            var initialList = BuildTestLinkedList(item, 1, 8);

            //act
            var result = Solver.AddSortedList(initialList, item);

            //assert
            VerifyLinkedList(result, 0, 8);
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