namespace Task55
{
    using System;
    using System.Text;

    /// <summary>
    /// Given a sequence of characters. How will you convert the lower case characters to upper case characters.
    /// </summary>
    public static class Solver
    {
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
                if (( 'a' <= outputItem && outputItem <= 'z' ))
                {
                    outputItem = (char) ( outputItem - 32 );
                }
                else if (( 'а' <= outputItem && outputItem <= 'я' ))
                {
                    outputItem = (char) ( outputItem + 'А' - 'а' );
                }
                else if (outputItem == 'ё')
                {
                    outputItem = 'Ё';
                }
                resultBuilder.Append(outputItem);
            }
            return resultBuilder.ToString();
        }
    }
}
