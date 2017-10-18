using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Task59.Tests
{
    [TestClass]
    public class SolverTests
    {
        #region compute signed sum

        [TestMethod]
        public void ComputeSignedSumTestNonEmpty()
        {
            //arrange
            var input = new int[]
                            {
                                3,
                                2
                            };

            //act
            var result = Solver.ComputeSum(input);

            //assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void ComputeSignedSumTestEmpty()
        {
            //arrange
            var input = new int[]
                            {
                            };

            //act
            var result = Solver.ComputeSum(input);

            //assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ComputeSignedSumTestMaxValueSingle()
        {
            //arrange
            var input = new int[]
                            {
                                int.MaxValue
                            };

            //act
            var result = Solver.ComputeSum(input);

            //assert
            Assert.AreEqual(int.MaxValue, result);
        }

        [TestMethod]
        public void ComputeSignedSumTestMaxMinValue()
        {
            //arrange
            var input = new int[]
                            {
                                int.MaxValue,
                                int.MinValue
                            };

            //act
            var result = Solver.ComputeSum(input);

            //assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void ComputeSignedSumTestMinMaxValue()
        {
            //arrange
            var input = new int[]
                            {
                                int.MinValue,
                                int.MaxValue
                            };

            //act
            var result = Solver.ComputeSum(input);

            //assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void ComputeSignedSumTestMaxValueDouble()
        {
            Solver.ComputeSum(
                new int[]
                    {
                        int.MaxValue,
                        int.MaxValue
                    });
        }

        [TestMethod]
        public void ComputeSignedSumTestMinValueSingle()
        {
            //arrange
            var input = new int[]
                            {
                                int.MinValue
                            };

            //act
            var result = Solver.ComputeSum(input);

            //assert
            Assert.AreEqual(int.MinValue, result);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void ComputeSignedSumTestMinValueDouble()
        {
            Solver.ComputeSum(
                new int[]
                    {
                        int.MinValue,
                        int.MinValue
                    });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ComputeSignedSumTestNull()
        {
            Solver.ComputeSum((int[]) null);
        }

        #endregion Compute signed sum

        #region compute unsigned sum

        [TestMethod]
        public void ComputeSumTestNonEmpty()
        {
            //arrange
            var input = new uint[]
                            {
                                3u,
                                2u
                            };

            //act
            var result = Solver.ComputeSum(input);

            //assert
            Assert.AreEqual(5u, result);
        }

        [TestMethod]
        public void ComputeSumTestEmpty()
        {
            //arrange
            var input = new uint[]
                            {
                            };

            //act
            var result = Solver.ComputeSum(input);

            //assert
            Assert.AreEqual(0u, result);
        }

        [TestMethod]
        public void ComputeSumTestMaxValueSingle()
        {
            //arrange
            var input = new uint[]
                            {
                                uint.MaxValue
                            };

            //act
            var result = Solver.ComputeSum(input);

            //assert
            Assert.AreEqual(uint.MaxValue, result);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void ComputeSumTestMaxValueDouble()
        {
            Solver.ComputeSum(
                new uint[]
                    {
                        uint.MaxValue,
                        uint.MaxValue
                    });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ComputeSumTestNull()
        {
            Solver.ComputeSum((uint[]) null);
        }

        #endregion Compute unsigned sum
    }
}