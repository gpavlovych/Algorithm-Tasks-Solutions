using System;
using System.CodeDom;
using System.Runtime.ExceptionServices;

namespace Task1
{
    /// <summary>
    /// 1. In 2-D array, find a zero and replace the entire row and column with zeros.
    /// </summary>
    /// <remarks>TODO put here answers of additional questions which help successfully solve the task.</remarks>
    public static class Solver
    {
        public static void ReplaceColumnsAndRowsIfZeroFound(int[,] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            var rowCount = input.GetLength(0);
            var columnCount = input.GetLength(1);
            var row = new bool[rowCount];
            var column = new bool[columnCount];

            for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    if (input[ rowIndex, columnIndex ] == 0)
                    {
                        row[ rowIndex ] = column[ columnIndex ] = true;
                    }
                }
            }

            for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                if (row[ rowIndex ])
                    for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                    {
                        input[ rowIndex, columnIndex ] = 0;
                    }
            }
            for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
            {
                if (column[ columnIndex ])
                    for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        input[ rowIndex, columnIndex ] = 0;
                    }
            }
        }
    }
}