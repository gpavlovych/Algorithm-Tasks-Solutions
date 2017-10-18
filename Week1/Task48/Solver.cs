namespace Task48
{
    using System;

    /// <summary>
    /// First some definitions for this problem: 
    ///  a) An ASCII character is one byte long and the most significant bit in the byte is always '0'.
    ///  b) A Kanji character is two bytes long. 
    /// The only characteristic of a Kanji character is that in its first byte the most significant bit is '1'. 
    /// Now you are given an array of the characters(both ASCII and Kanji) and, an index into the array.
    /// The index points to the start of some character. 
    /// Now you need to write a function to do a backspace (i.e.delete the character before the given index).
    /// </summary>
    /// <remarks>If index is before the upper byte of Kanji character, the whole character is removed</remarks>
    public static class Solver
    {
        public static int Backspace(ref byte[] input, int index)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            if (index <= 0 || index > input.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            var currentIndex = 0;
            var newArrayLength = input.Length;
            var index1 = 0;
            var index2 = 0;
            while (currentIndex < input.Length)
            {
                if ((input[currentIndex] & 0x80) == 0) //ASCII
                {
                    if (currentIndex == index - 1)
                    {
                        index1 = currentIndex;
                        index2 = currentIndex;
                        newArrayLength -= 1;
                    }
                    currentIndex += 1;
                }
                else //Kanji
                {
                    //if index points to the end of Kanji character, or points to its middle - anyway delete this Kanji
                    if ((currentIndex == index - 1) || (currentIndex + 1 == index - 1))
                    {
                        index1 = currentIndex;
                        index2 = currentIndex + 1;
                        newArrayLength -= 2;
                    }
                    currentIndex += 2;
                }
            }
            if (currentIndex != input.Length)
            {
                throw new ArgumentException("Input sequence of characters is invalid");
            }
            var resultingArray = new byte[newArrayLength];
            var resultingArrayIndex = 0;
            var result = 0;
            for (var i = 0; i < input.Length; i++)
            {
                if (i != index1 && i != index2)
                {
                    resultingArray[resultingArrayIndex++] = input[i];
                }
                else
                {
                    result = (result << 8) | input[i];
                }
            }
            input = resultingArray;
            return result;
        }
    }
}
