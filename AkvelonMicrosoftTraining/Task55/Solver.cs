namespace Task55
{
    using System;
    using System.Text;

    /// <summary>
    /// Given a sequence of characters. How will you convert the lower case characters to upper case characters.
    /// </summary>
    public static class Solver
    {
        private static int ClearBit(int input, byte byteNumber)
        {
            return input & ~(1 << byteNumber);
        }
        public static string ToUpper(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException();
            }
            var resultBuilder = new StringBuilder();
            var inputArray = input.ToCharArray();
            foreach (var inputItem in inputArray)
            {
                var outputItem = inputItem;
                if ((int)outputItem < 128)
                {
                    outputItem = (char)ClearBit(outputItem, 5);
                }
                resultBuilder.Append(outputItem);
            }
            return resultBuilder.ToString();
        }
    }
}
