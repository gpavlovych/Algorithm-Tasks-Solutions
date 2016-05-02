using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task63.Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void IsIntersectionTestIntersectLast()
        {
            var result = Solver.IsIntersection(
                new Node(5, null),
                new Node(1, new Node(2, new Node(4, new Node(5, null)))));
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsIntersectionTestIntersectFirst()
        {
            var result = Solver.IsIntersection(
                new Node(1, null),
                new Node(1, new Node(2, new Node(4, new Node(5, null)))));
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsIntersectionTestIntersectMiddle()
        {
            var result = Solver.IsIntersection(
                new Node(2, null),
                new Node(1, new Node(2, new Node(4, new Node(5, null)))));
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsIntersectionTestDontIntersect()
        {
            var result = Solver.IsIntersection(
                new Node(3, null),
                new Node(1, new Node(2, new Node(4, new Node(5, null)))));
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsIntersectionTestNullList()
        {
            var result = Solver.IsIntersection(new Node(3, null), null);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsIntersectionTestNullFixed()
        {
            var result = Solver.IsIntersection(null, new Node(3, null));
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsIntersectionTestNullBoth()
        {
            var result = Solver.IsIntersection(null, null);
            Assert.IsFalse(result);
        }
    }
}