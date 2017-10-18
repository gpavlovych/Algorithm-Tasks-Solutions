using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task67.Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void FindMiddleTestFive()
        {
            FindMiddleTest(5);
        }

        [TestMethod]
        public void FindMiddleTestFour()
        {
            FindMiddleTest(4);
        }

        [TestMethod]
        public void FindMiddleTestThree()
        {
            FindMiddleTest(3);
        }

        [TestMethod]
        public void FindMiddleTestTwo()
        {
            FindMiddleTest(2);
        }

        [TestMethod]
        public void FindMiddleTestSingle()
        {
            FindMiddleTest(1);
        }

        [TestMethod]
        public void FindMiddleTestEmpty()
        {
            FindMiddleTest(0);
        }

        #region Helper methods

        private static void FindMiddleTest(int number)
        {
            //arrange
            Node head = null;
            if (number > 0)
            {
                head = new Node(1);
                var current = head;
                for (var i = 2; i <= number; i++)
                {
                    current.Next = new Node(i);
                    current = current.Next;
                }
            }

            //act
            var result = Solver.FindMiddle(head);

            //assert
            if (number == 0)
            {
                Assert.IsNull(result);
            }
            else
            {
                Assert.AreEqual(( number / 2 ) + ( number % 2 ), result.Value);
            }
        }

        #endregion Helper methods
    }
}