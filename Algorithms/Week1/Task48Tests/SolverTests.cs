namespace Task48Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Task48;

    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void SolverTestMiddleAscii()
        {
            //arrange
            var input = new byte[] { 0x5A, 0x5A, 0x5E, 0x7F };
            var expectedOutput = new byte[] { 0x5A, 0x5A, 0x7F };
            var index = 3;

            //act
            var removedSymbol = Solver.Backspace(ref input, index);

            //assert
            Assert.AreEqual(0x5E, removedSymbol);
            CollectionAssert.AreEqual(expectedOutput, input);
        }

        [TestMethod]
        public void SolverTestMiddleKanjiEnd()
        {
            //arrange
            var input = new byte[] { 0x5A, 0x8A, 0x5E, 0x7F };
            var expectedOutput = new byte[] { 0x5A, 0x7F };
            var index = 3;

            //act
            var removedSymbol = Solver.Backspace(ref input, index);

            //assert
            Assert.AreEqual(0x8A5E, removedSymbol);
            CollectionAssert.AreEqual(expectedOutput, input);
        }

        [TestMethod]
        public void SolverTestMiddleKanjiMiddle()
        {
            //arrange
            var input = new byte[] { 0x5A, 0x8A, 0x5E, 0x7F };
            var expectedOutput = new byte[] { 0x5A, 0x7F };
            var index = 2;

            //act
            var removedSymbol = Solver.Backspace(ref input, index);

            //assert
            Assert.AreEqual(0x8A5E, removedSymbol);
            CollectionAssert.AreEqual(expectedOutput, input);
        }

        [TestMethod]
        public void SolverTestLastAscii()
        {
            //arrange
            var input = new byte[] { 0x5A, 0x8A, 0x5E, 0x7F };
            var expectedOutput = new byte[] { 0x5A, 0x8A, 0x5E };
            var index = 4;

            //act
            var removedSymbol = Solver.Backspace(ref input, index);

            //assert
            Assert.AreEqual(0x7F, removedSymbol);
            CollectionAssert.AreEqual(expectedOutput, input);
        }

        [TestMethod]
        public void SolverTestLastKanjiEnd()
        {
            //arrange
            var input = new byte[] { 0x5A, 0x5E, 0x8A, 0x7F };
            var expectedOutput = new byte[] { 0x5A, 0x5E };
            var index = 4;

            //act
            var removedSymbol = Solver.Backspace(ref input, index);

            //assert
            Assert.AreEqual(0x8A7F, removedSymbol);
            CollectionAssert.AreEqual(expectedOutput, input);
        }

        [TestMethod]
        public void SolverTestLastKanjiMiddle()
        {
            //arrange
            var input = new byte[] { 0x5A, 0x5E, 0x8A, 0x7F };
            var expectedOutput = new byte[] { 0x5A, 0x5E };
            var index = 3;

            //act
            var removedSymbol = Solver.Backspace(ref input, index);

            //assert
            Assert.AreEqual(0x8A7F, removedSymbol);
            CollectionAssert.AreEqual(expectedOutput, input);
        }

        [TestMethod]
        public void SolverTestFirstAscii()
        {
            //arrange
            var input = new byte[] { 0x5A, 0x8A, 0x5E, 0x7F };
            var expectedOutput = new byte[] { 0x8A, 0x5E, 0x7F };
            var index = 1;

            //act
            var removedSymbol = Solver.Backspace(ref input, index);

            //assert
            Assert.AreEqual(0x5A, removedSymbol);
            CollectionAssert.AreEqual(expectedOutput, input);
        }

        [TestMethod]
        public void SolverTestFirstKanjiMiddle()
        {
            //arrange
            var input = new byte[] { 0x8A, 0x5E, 0x8A, 0x7F };
            var expectedOutput = new byte[] { 0x8A, 0x7F };
            var index = 1;

            //act
            var removedSymbol = Solver.Backspace(ref input, index);

            //assert
            Assert.AreEqual(0x8A5E, removedSymbol);
            CollectionAssert.AreEqual(expectedOutput, input);
        }

        [TestMethod]
        public void SolverTestFirstKanjiEnd()
        {
            //arrange
            var input = new byte[] { 0x8A, 0x5E, 0x5A, 0x5E };
            var expectedOutput = new byte[] { 0x5A, 0x5E };
            var index = 2;

            //act
            var removedSymbol = Solver.Backspace(ref input, index);

            //assert
            Assert.AreEqual(0x8A5E, removedSymbol);
            CollectionAssert.AreEqual(expectedOutput, input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SolverTestArgumentNull()
        {
            byte[] input = null;

            Solver.Backspace(ref input, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SolverTestArgumentOutOfRange_Below0()
        {
            //arrange
            var input = new byte[] { 0x8A, 0x5E, 0x5A, 0x5E };

            //act
            Solver.Backspace(ref input, -3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SolverTestArgumentOutOfRange_0()
        {
            //arrange
            var input = new byte[] { 0x8A, 0x5E, 0x5A, 0x5E };

            //act
            Solver.Backspace(ref input, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SolverTestArgumentOutOfRange_AboveLength()
        {
            //arrange
            var input = new byte[] { 0x8A, 0x5E, 0x5A, 0x5E };

            //act
            Solver.Backspace(ref input, input.Length + 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SolverTestInvalidArgument_NotCompletedKanjiEnd()
        {
            //arrange
            var input = new byte[] { 0x5E, 0x8A };

            //act
            Solver.Backspace(ref input, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SolverTestInvalidArgument_WrongInput()
        {
            //arrange
            var input = new byte[] { 0x8E, 0x8A, 0x5E, 0x8A };

            //act
            Solver.Backspace(ref input, 1);
        }
    }
}
