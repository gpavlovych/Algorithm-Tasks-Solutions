using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task12;

namespace Task12Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void doCompareTestTrue()
        {
            // act
            var result = Solver.doCompare("Tadas s sf ksffdf g ts", 't', 's', 2);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void doCompareTestFalse()
        {
            // act
            var result = Solver.doCompare("Tadas s sf ksffdf g ts", 't', 's', 1);

            // assert
            Assert.IsFalse(result);
        }
    }
}
