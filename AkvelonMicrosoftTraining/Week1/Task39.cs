using System;
using System.Collections.Generic;

namespace Week1
{
    public static class Task39
    {
        public struct Duplicate
        {
            public int Value;

            public int Index;
        }

        public static IEnumerable<Duplicate> Solve(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            var result = new List<Duplicate>();
            for (var i = 0; i < input.Length; i++)
            {
                if (input[Math.Abs(input[i])] > 0)
                {
                    input[Math.Abs(input[i])] = -input[Math.Abs(input[i])];
                }
                else
                {
                    result.Add(new Duplicate() { Index = i, Value = Math.Abs(input[i]) });
                }
            }
            return result;
        }
    }
}
