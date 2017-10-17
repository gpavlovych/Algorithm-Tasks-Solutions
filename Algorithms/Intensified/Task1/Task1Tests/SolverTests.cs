using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;

namespace Task1Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void RecFuncTest0()
        {
            this.RecFuncTest(0, 0);
        }

        [TestMethod]
        public void RecFuncTest1()
        {
            this.RecFuncTest(2, 1);
        }

        [TestMethod]
        public void RecFuncTest2()
        {
            this.RecFuncTest(1, 2);
        }

        [TestMethod]
        public void RecFuncTest3()
        {
            this.RecFuncTest(5, 3);
        }

        [TestMethod]
        public void RecFuncTestNeg1()
        {
            this.RecFuncTest(-1, -1);
        }

        [TestMethod]
        public void RecFuncTestNeg2()
        {
            this.RecFuncTest(-1, -2);
        }

        [TestMethod]
        public void RecFuncTestNeg3()
        {
            this.RecFuncTest(-4, -3);
        }

        [TestMethod]
        public void PlainFuncTest0()
        {
            this.PlainFuncTest(0, 0);
        }

        [TestMethod]
        public void PlainFuncTest1()
        {
            this.PlainFuncTest(2, 1);
        }

        [TestMethod]
        public void PlainFuncTest2()
        {
            this.PlainFuncTest(1, 2);
        }

        [TestMethod]
        public void PlainFuncTest3()
        {
            this.PlainFuncTest(5, 3);
        }

        [TestMethod]
        public void PlainFuncTestNeg1()
        {
            this.PlainFuncTest(-1, -1);
        }

        [TestMethod]
        public void PlainFuncTestNeg2()
        {
            this.PlainFuncTest(-1, -2);
        }

        [TestMethod]
        public void PlainFuncTestNeg3()
        {
            this.PlainFuncTest(-4, -3);
        }

        private void RecFuncTest(int expectedResult, int arg)
        {
            //act
            var result = Solver.RecFunc(arg);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        private void PlainFuncTest(int expectedResult, int arg)
        {
            //act
            var result = Solver.PlainFunc(arg);

            //assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}