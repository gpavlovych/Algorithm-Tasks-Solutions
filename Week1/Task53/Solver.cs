namespace Task53
{
    using System;
    using System.IO;

    /// <summary>
    /// Write a routine that prints out a 2-D array in spiral order.
    /// </summary>
    public static class Solver
    {
        private enum IndexerState
        {
            IncColumn,
            IncRow,
            DecColumn,
            DecRow
        }
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

            int columnCount = input.GetLength(1), rowCount = input.GetLength(0);
            int columnIndex = 0;
            int rowIndex = 0;
            int currentMinColumn = 0;
            int currentMaxColumn = columnCount - 1;
            int currentMinRow = 0;
            int currentMaxRow = rowCount - 1;
            var currentState = currentMinColumn == currentMaxColumn ? IndexerState.IncRow : IndexerState.IncColumn;
            for (var i = 0; i < columnCount * rowCount; i++)
            {
                writer.Write("{0} ", input[rowIndex, columnIndex]);
                switch (currentState)
                {
                    case IndexerState.IncColumn:
                        if (columnIndex < currentMaxColumn)
                        {
                            columnIndex++;
                        }
                        if (columnIndex == currentMaxColumn)
                        {
                            currentState = IndexerState.IncRow;
                        }
                        break;
                    case IndexerState.IncRow:
                        if (rowIndex < currentMaxRow)
                        {
                            rowIndex++;
                        }
                        if (rowIndex == currentMaxRow)
                        {
                            currentState = IndexerState.DecColumn;
                        }
                        break;
                    case IndexerState.DecColumn:
                        if (columnIndex > currentMinColumn)
                        {
                            columnIndex--;
                        }
                        if (columnIndex == currentMinColumn)
                        {
                            currentState = IndexerState.DecRow;
                            currentMinRow++;
                            currentMaxRow--;
                        }
                        break;
                    case IndexerState.DecRow:
                        if (rowIndex > currentMinRow)
                        {
                            rowIndex--;
                        }
                        if (rowIndex == currentMinRow)
                        {
                            currentState = IndexerState.IncColumn;
                            currentMinColumn++;
                            currentMaxColumn--;
                        }
                        break;
                }
            }
        }
    }
}