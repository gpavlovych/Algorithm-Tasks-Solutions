namespace Task53
{
    using System;
    using System.IO;

    public static class Solver
    {
        public static void PrintInSpiralOrder<T>(TextWriter writer, T[,] input)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            int columnIndex = 0, rowIndex = 0;
            int columnCount = input.GetLength(0), rowCount = input.GetLength(1);
            while (columnIndex < columnCount && rowIndex < rowCount)
            {
                for (var i = rowIndex; i < rowCount; ++i)
                {
                    writer.Write("{0} ", input[columnIndex, i]);
                }
                columnIndex++;

                /* Print the last column from the remaining columns */
                for (var i = columnIndex; i < columnCount; ++i)
                {
                    writer.Write("{0} ", input[i, rowCount - 1]);
                }
                rowCount--;

                /* Print the last row from the remaining rows */
                if (columnIndex < columnCount)
                {
                    for (var i = rowCount - 1; i >= rowIndex; --i)
                    {
                        writer.Write("{0} ", input[columnCount - 1, i]);
                    }
                    columnCount--;
                }

                /* Print the first column from the remaining columns */
                if (rowIndex < rowCount)
                {
                    for (var i = columnCount - 1; i >= columnIndex; --i)
                    {
                        writer.Write("{0} ", input[i, rowIndex]);
                    }
                    rowIndex++;
                }
            }
        }
    }
}