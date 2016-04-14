namespace Task52Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BaseTests.Tests;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Task52;

    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void ParseTestNull()
        {
            //act
            var parsedExpression = Solver.Tokenize(null).ToList();

            //assert
            this.AssertTokenCollectionsEqual(new Token[] { }, parsedExpression);
        }

        [TestMethod]
        public void ParseTestEmpty()
        {
            //act
            var parsedExpression = Solver.Tokenize("").ToList();

            //assert
            this.AssertTokenCollectionsEqual(new Token[] { }, parsedExpression);
        }

        [TestMethod]
        public void ParseTestSingleNumber()
        {
            //arrange
            var expectedTokens = new Token[] { new Token { Type = "NUMBER", Position = 0, Value = "1" }, };

            //act
            var parsedExpression = Solver.Tokenize("1").ToList();

            //assert
            this.AssertTokenCollectionsEqual(expectedTokens, parsedExpression);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseTestInvalidChar()
        {
            //act
            Solver.Tokenize("1+@").ToList();
        }

        [TestMethod]
        public void ParseTest()
        {
            //arrange
            var expectedTokens = new[]
                                     {
                                         new Token { Type = "NUMBER", Position = 0, Value = "1" },
                                         new Token { Type = "PLUS", Position = 1, Value = "+" },
                                         new Token { Type = "NUMBER", Position = 2, Value = "2" },
                                         new Token { Type = "MINUS", Position = 3, Value = "-" },
                                         new Token { Type = "NUMBER", Position = 4, Value = "3" },
                                         new Token { Type = "MULTIPLY", Position = 5, Value = "*" },
                                         new Token { Type = "LEFT", Position = 6, Value = "(" },
                                         new Token { Type = "NUMBER", Position = 7, Value = "4" },
                                         new Token { Type = "DIVIDE", Position = 8, Value = "/" },
                                         new Token { Type = "NUMBER", Position = 9, Value = "5" },
                                         new Token { Type = "PLUS", Position = 10, Value = "+" },
                                         new Token { Type = "IDENTIFIER", Position = 11, Value = "id123" },
                                         new Token { Type = "RIGHT", Position = 16, Value = ")" },
                                     };
            string expression = "1+2-3*(4/5+id123)";

            //act
            var parsedExpression = Solver.Tokenize(expression);

            //assert
            this.AssertTokenCollectionsEqual(expectedTokens, parsedExpression);
        }

        private void AssertTokenCollectionsEqual(Token[] expectedTokens, IEnumerable<Token> parsedExpression)
        {
            TestHelper.AssertCollectionsEqual(
                expectedTokens,
                parsedExpression,
                (expected, actual, index) =>
                    {
                        Assert.AreEqual(
                            expected.Position,
                            actual.Position,
                            "Wrong Token.Position @{0}: expected {1} but was {2}",
                            index,
                            expected.Position,
                            actual.Position);
                        Assert.AreEqual(
                            expected.Value,
                            actual.Value,
                            "Wrong Token.Value @{0}: expected {1} but was {2}",
                            index,
                            expected.Value,
                            actual.Value);
                        Assert.AreEqual(
                            expected.Type,
                            actual.Type,
                            "Wrong Token.Type @{0}: expected {1} but was {2}",
                            index,
                            expected.Type,
                            actual.Type);
                    });
        }
    }
}