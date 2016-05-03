using System;
using Task72;

namespace Task72ConsoleApplication
{
    class Program
    {
        private static int permNumber = 0;

        private static void PrintIterationArray<T>(T[,] array)
        {
            PrintIterationNumber();
            PrintArray(array);
        }

        private static void PrintArray<T>(T[,] array)
        {
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write("{0} ", array[ i, j ]);
                }
                Console.WriteLine();
            }
        }

        private static void PrintIterationNumber()
        {
            permNumber++;
            Console.WriteLine("Permutation number: {0}", permNumber);
        }

        private static void Permutate(string permutationName, string[,] input, Action<string[,], Action<string[,]>> permutateAction)
        {
            permNumber = 0;
            Console.WriteLine(permutationName);
            PrintArray(input);
            Console.WriteLine();
            permutateAction(input, it => PrintIterationArray(it));
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void PermutateIteratively(string[,] input)
        {
            Permutate("PermutateIteratively", input, Solver.PermutateIteratively);
        }

        private static void PermutateRecursively(string[,] input)
        {
            Permutate("PermutateRecursively", input, Solver.PermutateRecursively);
        }

        static void Main(string[] args)
        {
            PermutateIteratively(new [,] { {"1"} });
            PermutateIteratively(new [,] { { "1" }, {"2"} });
            PermutateIteratively(new [,] { { "1", "2" }, {"3", "4"} });

            PermutateRecursively(new [,] { { "1" } });
            PermutateRecursively(new [,] { { "1" }, { "2" } });
            PermutateRecursively(new [,] { { "1", "2" }, { "3", "4" } });

            Console.ReadLine();
        }
    }
}
