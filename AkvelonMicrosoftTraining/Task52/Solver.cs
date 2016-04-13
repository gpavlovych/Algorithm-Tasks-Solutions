namespace Task52
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Token
    {
        public string Type { get; set; }

        public string Value { get; set; }

        public int Position { get; set; }
    }

    public class TokenDefinition
    {
        public Regex RegularExpression { get; set; }

        public string Type { get; set; }
    }

    public static class Solver
    {
        #region Tokens

        private static readonly IEnumerable<TokenDefinition> tokenDefinitions = new List<TokenDefinition>()
                                                                                    {
                                                                                        new TokenDefinition
                                                                                            ()
                                                                                            {
                                                                                                Type
                                                                                                    =
                                                                                                    "LEFT",
                                                                                                RegularExpression
                                                                                                    =
                                                                                                    new Regex
                                                                                                    (
                                                                                                    "\\(")
                                                                                            },
                                                                                        new TokenDefinition
                                                                                            ()
                                                                                            {
                                                                                                Type
                                                                                                    =
                                                                                                    "RIGHT",
                                                                                                RegularExpression
                                                                                                    =
                                                                                                    new Regex
                                                                                                    (
                                                                                                    "\\)")
                                                                                            },
                                                                                        new TokenDefinition
                                                                                            ()
                                                                                            {
                                                                                                Type
                                                                                                    =
                                                                                                    "PLUS",
                                                                                                RegularExpression
                                                                                                    =
                                                                                                    new Regex
                                                                                                    (
                                                                                                    "\\+")
                                                                                            },
                                                                                        new TokenDefinition
                                                                                            ()
                                                                                            {
                                                                                                Type
                                                                                                    =
                                                                                                    "MINUS",
                                                                                                RegularExpression
                                                                                                    =
                                                                                                    new Regex
                                                                                                    (
                                                                                                    "\\-")
                                                                                            },
                                                                                        new TokenDefinition
                                                                                            ()
                                                                                            {
                                                                                                Type
                                                                                                    =
                                                                                                    "MULTIPLY",
                                                                                                RegularExpression
                                                                                                    =
                                                                                                    new Regex
                                                                                                    (
                                                                                                    "\\*")
                                                                                            },
                                                                                        new TokenDefinition
                                                                                            ()
                                                                                            {
                                                                                                Type
                                                                                                    =
                                                                                                    "DIVIDE",
                                                                                                RegularExpression
                                                                                                    =
                                                                                                    new Regex
                                                                                                    (
                                                                                                    "/")
                                                                                            },
                                                                                        new TokenDefinition
                                                                                            ()
                                                                                            {
                                                                                                Type
                                                                                                    =
                                                                                                    "NUMBER",
                                                                                                RegularExpression
                                                                                                    =
                                                                                                    new Regex
                                                                                                    (
                                                                                                    "[0-9]+")
                                                                                            },
                                                                                        new TokenDefinition
                                                                                            ()
                                                                                            {
                                                                                                Type
                                                                                                    =
                                                                                                    "IDENTIFIER",
                                                                                                RegularExpression
                                                                                                    =
                                                                                                    new Regex
                                                                                                    (
                                                                                                    "[a-zA-Z][a-zA-Z0-9]*")
                                                                                            },
                                                                                    };

        #endregion Tokens

        public static IEnumerable<Token> Tokenize(string expression)
        {
            expression = expression ?? "";
            var currentIndex = 0;
            while (currentIndex < expression.Length)
            {
                TokenDefinition matchedDefinition = null;
                int matchLength = 0;

                foreach (var rule in tokenDefinitions)
                {
                    var match = rule.RegularExpression.Match(expression, currentIndex);

                    if (match.Success && (match.Index - currentIndex) == 0)
                    {
                        matchedDefinition = rule;
                        matchLength = match.Length;
                        break;
                    }
                }
                if (matchedDefinition == null)
                {
                    throw new ArgumentException(
                        string.Format("Unrecognized symbol '{0}' at index {1}.", expression[currentIndex], currentIndex));
                }

                var value = expression.Substring(currentIndex, matchLength);
                yield return new Token() { Type = matchedDefinition.Type, Value = value, Position = currentIndex };
                currentIndex += matchLength;
            }
        }
    }
}
