using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task77
{
    /// <summary>
    /// 77.Write a program that prints the numbers from 1 to 100. But for multiples of three prints “Fizz” 
    /// instead of the number and for the multiples of five prints “Buzz”. 
    /// For numbers, which are, multiples of both three and five prints “FizzBuzz”. How would you test it!
    /// </summary>
    public static class Solver
    {
        public static void PrintFizzBuzz(TextWriter writer)
        {
            for (var i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    writer.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    writer.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    writer.WriteLine("Buzz");
                }
                else
                    writer.WriteLine(i);
            }
        }
    }
}
