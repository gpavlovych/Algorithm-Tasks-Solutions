namespace Task39
{
    using System;
    using System.IO;

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
