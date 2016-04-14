namespace Task39
{
    using System;
    using System.IO;

    /// <summary>
    /// Given an array of size N in which every number is between 1 and N, determine if there are any duplicates in it and what kind.
    /// You are allowed to destroy or modify the array if you like.
    /// </summary>
    /// <remarks>Print out duplicates to the console(TextWriter).</remarks>
    public static class Solver
    {
        public static void Solve(TextWriter writer, int[] input)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            for (var i = 0; i < input.Length; i++)
            {
                if (input[Math.Abs(input[i])] > 0)
                {
                    input[Math.Abs(input[i])] = -input[Math.Abs(input[i])];
                }
                else
                {
                    writer.WriteLine("Item {0} is occured again at position {1}", Math.Abs(input[i]), i);
                }
            }
        }
    }
}