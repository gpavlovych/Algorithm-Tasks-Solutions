namespace Task43
{
    using System;

    /// <summary>
    /// Given an array of characters which form a sentence of words,
    /// give an efficient algorithm to reverse the order of the words(not characters) in it.
    /// </summary>
    public static class Solver
    {
        private static void Swap(char[] a, int index1, int index2)
        {
            var temp = a[index1];
            a[index1] = a[index2];
            a[index2] = temp;
        }

        private static void ReverseSubarray(char[] a, int startIndex, int length)
        {
            for (var index = 0; index < length / 2; index++)
            {
                Swap(a, startIndex + index, startIndex + length - index - 1);
            }
        }

        public static void ReverseWords(char[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            ReverseSubarray(input, 0, input.Length);
            int wordStart = 0;
            for (var currentIndex = 0; currentIndex < input.Length; currentIndex++)
            {
                if (input[currentIndex] == ' ')
                {
                    ReverseSubarray(input, wordStart, currentIndex - wordStart);
                    wordStart = currentIndex + 1;
                }
            }
            ReverseSubarray(input, wordStart, input.Length - wordStart);
        }
    }
}
