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
        public void ReplaceColumnsAndRowsIfZeroFoundOneZero23()
        {
            //arrange
            var input = new int[,]
                            {
                                {
                                    1,
                                    2
                                },
                                {
                                    4,
                                    0
                                },
                                {
                                    7,
                                    8
                                }
                            };
            var expectedOutput = new int[,]
                                     {
                                         {
                                             1,
                                             0
                                         },
                                         {
                                             0,
                                             0
                                         },
                                         {
                                             7,
                                             0
                                         }
                                     };

            //act
            Solver.ReplaceColumnsAndRowsIfZeroFound(input);

            //assert
            CollectionAssert.AreEqual(expectedOutput.OfType<int>().ToList(), input.OfType<int>().ToList());
        }

        [TestMethod]
        public void ReplaceColumnsAndRowsIfZeroFoundOneZero32()
        {
            //arrange
            var input = new int[,]
                            {
                                {
                                    1,
                                    2,
                                    3
                                },
                                {
                                    4,
                                    0,
                                    6
                                }
                            };
            var expectedOutput = new int[,]
                                     {
                                         {
                                             1,
                                             0,
                                             3
                                         },
                                         {
                                             0,
                                             0,
                                             0
                                         }
                                     };

            //act
            Solver.ReplaceColumnsAndRowsIfZeroFound(input);

            //assert
            CollectionAssert.AreEqual(expectedOutput.OfType<int>().ToList(), input.OfType<int>().ToList());
        }

        [TestMethod]
        public void ReplaceColumnsAndRowsIfZeroFoundOneZero()
        {
            //arrange
            var input = new int[,]
                            {
                                {
                                    1,
                                    2,
                                    3
                                },
                                {
                                    4,
                                    0,
                                    6
                                },
                                {
                                    7,
                                    8,
                                    9
                                }
                            };
            var expectedOutput = new int[,]
                                     {
                                         {
                                             1,
                                             0,
                                             3
                                         },
                                         {
                                             0,
                                             0,
                                             0
                                         },
                                         {
                                             7,
                                             0,
                                             9
                                         }
                                     };

            //act
            Solver.ReplaceColumnsAndRowsIfZeroFound(input);

            //assert
            CollectionAssert.AreEqual(expectedOutput.OfType<int>().ToList(), input.OfType<int>().ToList());
        }

        [TestMethod]
        public void ReplaceColumnsAndRowsIfZeroFoundNoZero()
        {
            //arrange
            var input = new int[,]
                            {
                                {
                                    1,
                                    2,
                                    3
                                },
                                {
                                    4,
                                    5,
                                    6
                                },
                                {
                                    7,
                                    8,
                                    9
                                }
                            };
            var expectedOutput = new int[,]
                                     {
                                         {
                                             1,
                                             2,
                                             3
                                         },
                                         {
                                             4,
                                             5,
                                             6
                                         },
                                         {
                                             7,
                                             8,
                                             9
                                         }
                                     };

            //act
            Solver.ReplaceColumnsAndRowsIfZeroFound(input);

            //assert
            CollectionAssert.AreEqual(expectedOutput.OfType<int>().ToList(), input.OfType<int>().ToList());
        }

        [TestMethod]
        public void ReplaceColumnsAndRowsIfZeroFoundTwoEmptyRows()
        {
            //act
            Solver.ReplaceColumnsAndRowsIfZeroFound(new int[,] { {}, {} } );
        }

        [TestMethod]
        public void ReplaceColumnsAndRowsIfZeroFoundSingleEmptyRow()
        {
            //act
            Solver.ReplaceColumnsAndRowsIfZeroFound(new int[,] { {} });
        }

        [TestMethod]
        public void ReplaceColumnsAndRowsIfZeroFoundEmpty()
        {
             //act
            Solver.ReplaceColumnsAndRowsIfZeroFound(new int[,] { });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DoSomethingNullInput()
        {
            //act
            Solver.ReplaceColumnsAndRowsIfZeroFound(null);
        }
    }
}