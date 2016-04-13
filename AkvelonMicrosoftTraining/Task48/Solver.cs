namespace Task48
{
    using System;

    public static class Solver
    {
        public static byte[] Backspace(byte[] input, int index)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            if (index <= 0 || index > input.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            //check if we are in the end of Kanji, remove char at index-1, index-2
            if (index >= 2 && (input[index - 2] & (1 << 7)) != 0)
            {
                return ArrayExceptIndexes(input, index - 1, index - 2);
            }
            //check if we are in the middle of Kanji, remove char at index, index-1
            if (index < input.Length && (input[index - 1] & (1 << 7)) != 0)
            {
                return ArrayExceptIndexes(input, index, index - 1);
            }
            //Check if previous item is ASCII, remove char at index-1
            if ((input[index - 1] & (1 << 7)) == 0)
            {
                return ArrayExceptIndexes(input, index - 1);
            }
            throw new ArgumentException("Invalid input");
        }

        private static byte[] ArrayExceptIndexes(byte[] input, params int[] indexes)
        {
            int j = 0;
            var result = new byte[input.Length - indexes.Length];
            for (var i = 0; i < input.Length; i++)
            {
                if (!ArrayContains(indexes, i))
                {
                    result[j] = input[i];
                    j++;
                }
            }
            return result;
        }

        private static bool ArrayContains(int[] array, int item)
        {
            for (var i = 0; i < array.Length; i++)
            {
                if (array[i] == item)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
