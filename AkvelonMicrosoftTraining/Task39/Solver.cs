namespace Task39
{
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;

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
                if (input[i] < 1 || input[i] > input.Length)
                {
                    throw new ArgumentOutOfRangeException(
                        "input",
                        string.Format(
                            "invalid input[{0}] value ({1}): outside [1..{2}] range",
                            i,
                            input[i],
                            input.Length));
                }
            }
            for (var i = 0; i < input.Length; i++)
            {
                if (input[Math.Abs(input[i]) - 1] > 0)
                {
                    input[Math.Abs(input[i]) - 1] = -input[Math.Abs(input[i]) - 1];
                }
                else
                {
                    writer.WriteLine("Item {0} is occured again at position {1}", Math.Abs(input[i]), i);
                }
            }
        }
    }
}