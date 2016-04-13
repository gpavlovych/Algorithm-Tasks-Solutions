namespace Task48Tests
{
    using System;

    using BaseTests.Tests;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Task48;

    [TestClass]
    public class SolverTests : UnitTestBase
    {
        [TestMethod]
        public void SolverTestMiddleAscii()
        {
            //arrange
            var input = new byte[] { 0x5A, 0x5A, 0x5E, 0x7F };
            var expectedOutput = new byte[] { 0x5A, 0x5A, 0x7F };
            var index = 3;

            //act
            var actualOutput = Solver.Backspace(input, index);

            //assert
            AssertCollectionsEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void SolverTestMiddleKanjiEnd()
        {
            //arrange
            var input = new byte[] { 0x5A, 0x8A, 0x5E, 0x7F };
            var expectedOutput = new byte[] { 0x5A, 0x7F };
            var index = 3;

            //act
            var actualOutput = Solver.Backspace(input, index);

            //assert
            AssertCollectionsEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void SolverTestMiddleKanjiMiddle()
        {
            //arrange
            var input = new byte[] { 0x5A, 0x8A, 0x5E, 0x7F };
            var expectedOutput = new byte[] { 0x5A, 0x7F };
            var index = 2;

            //act
            var actualOutput = Solver.Backspace(input, index);

            //assert
            AssertCollectionsEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void SolverTestLastAscii()
        {
            //arrange
            var input = new byte[] { 0x5A, 0x8A, 0x5E, 0x7F };
            var expectedOutput = new byte[] { 0x5A, 0x8A, 0x5E };
            var index = 4;

            //act
            var actualOutput = Solver.Backspace(input, index);

            //assert
            AssertCollectionsEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void SolverTestLastKanjiEnd()
        {
            //arrange
            var input = new byte[] { 0x5A, 0x5E, 0x8A, 0x7F };
            var expectedOutput = new byte[] { 0x5A, 0x5E };
            var index = 4;

            //act
            var actualOutput = Solver.Backspace(input, index);

            //assert
            AssertCollectionsEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void SolverTestLastKanjiMiddle()
        {
            //arrange
            var input = new byte[] { 0x5A, 0x5E, 0x8A, 0x7F };
            var expectedOutput = new byte[] { 0x5A, 0x5E };
            var index = 3;

            //act
            var actualOutput = Solver.Backspace(input, index);

            //assert
            AssertCollectionsEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void SolverTestFirstAscii()
        {
            //arrange
            var input = new byte[] { 0x5A, 0x8A, 0x5E, 0x7F };
            var expectedOutput = new byte[] { 0x8A, 0x5E, 0x7F };
            var index = 1;

            //act
            var actualOutput = Solver.Backspace(input, index);

            //assert
            AssertCollectionsEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void SolverTestFirstKanjiMiddle()
        {
            //arrange
            var input = new byte[] { 0x8A, 0x5E, 0x8A, 0x7F };
            var expectedOutput = new byte[] { 0x8A, 0x7F };
            var index = 1;

            //act
            var actualOutput = Solver.Backspace(input, index);

            //assert
            AssertCollectionsEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void SolverTestFirstKanjiEnd()
        {
            //arrange
            var input = new byte[] { 0x8A, 0x5E, 0x5A, 0x5E };
            var expectedOutput = new byte[] { 0x5A, 0x5E };
            var index = 2;

            //act
            var actualOutput = Solver.Backspace(input, index);

            //assert
            AssertCollectionsEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SolverTestArgumentNull()
        {
            Solver.Backspace(null, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SolverTestArgumentOutOfRange_Below0()
        {
            //arrange
            var input = new byte[] { 0x8A, 0x5E, 0x5A, 0x5E };

            //act
            Solver.Backspace(input, -3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SolverTestArgumentOutOfRange_0()
        {
            //arrange
            var input = new byte[] { 0x8A, 0x5E, 0x5A, 0x5E };

            //act
            Solver.Backspace(input, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SolverTestArgumentOutOfRange_AboveLength()
        {
            //arrange
            var input = new byte[] { 0x8A, 0x5E, 0x5A, 0x5E };

            //act
            Solver.Backspace(input, input.Length + 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SolverTestInvalidArgument_NotCompletedKanjiEnd()
        {
            //arrange
            var input = new byte[] { 0x5E, 0x8A };

            //act
            Solver.Backspace(input, 2);
        }
    }
}
