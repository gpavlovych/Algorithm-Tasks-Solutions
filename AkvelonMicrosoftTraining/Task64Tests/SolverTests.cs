using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task64;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task64.Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void IsLoopedTestTripleLooped()
        {
            var node = new Node(1);
            node.Next = new Node(2)
                            {
                                Next = new Node(3)
                                           {
                                               Next = node
                                           }
                            };
            Assert.IsTrue(Solver.IsLooped(node));
        }

        [TestMethod]
        public void IsLoopedTestTripleNonLooped()
        {
            Assert.IsFalse(
                Solver.IsLooped(
                    new Node(1)
                        {
                            Next = new Node(2)
                                       {
                                           Next = new Node(3)
                                       }
                        }));
        }

        [TestMethod]
        public void IsLoopedTestDoubleLooped()
        {
            var node = new Node(1);
            node.Next = new Node(2)
                            {
                                Next = node
                            };
            Assert.IsTrue(Solver.IsLooped(node));
        }

        [TestMethod]
        public void IsLoopedTestDoubleNonLooped()
        {
            Assert.IsFalse(
                Solver.IsLooped(
                    new Node(1)
                        {
                            Next = new Node(2)
                        }));
        }

        [TestMethod]
        public void IsLoopedTestSingleLooped()
        {
            var node = new Node(1);
            node.Next = node;
            Assert.IsTrue(Solver.IsLooped(node));
        }

        [TestMethod]
        public void IsLoopedTestSingleNonLooped()
        {
            Assert.IsFalse(Solver.IsLooped(new Node(1)));
        }

        [TestMethod]
        public void IsLoopedTestNull()
        {
            Assert.IsFalse(Solver.IsLooped(null));
        }
    }
}