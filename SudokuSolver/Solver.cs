using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver
{
    public static class Solver
    {
        private static int[,] StartingBoard;
        private static int[,] CurrentBoard;
        private static int[,][] PossibleValues;

        public static int[,] Solve(int[] StartingBoard)
        {
            int[,] matrix = new int[9, 9];

            int index = 0;
            for (int y = 0; y < 9; y++)
                for (int x = 0; x < 9; x++)
                    matrix[x, y] = StartingBoard[index++];

            return Solve(matrix);
        }

        public static int[,] Solve(int[,] StartingBoard)
        {
            Load(StartingBoard);

            while (Validate() == false)
            {
                UpdatePossibleValues();
                EliminateValues();
            }

            return CurrentBoard;
        }

        private static void Load(int[,] Board)
        {
            StartingBoard = Board;
            CurrentBoard = StartingBoard.Copy();

            int[] _possibleValues = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            PossibleValues = new int[9, 9][];

            for (int y = 0; y < 9; y++)
                for (int x = 0; x < 9; x++)
                {
                    PossibleValues[x, y] = new int[9];
                    Array.Copy(_possibleValues, PossibleValues[x, y],9);
                }
        }
        private static void UpdatePossibleValues()
        {
            for(int y = 0; y < 9;y++)
            {
                for(int x = 0;x < 9;x++)
                {
                    if (CurrentBoard[x, y] != 0)
                        continue;

                    if (x == 5 && y == 4)
                        ;

                    //Check current row,column, and submatrix
                    int[] row = CurrentBoard.GetRow(y);
                    int[] column = CurrentBoard.GetColumn(x);
                    int[,] submatrix = CurrentBoard.GetSubMatrix(x, y);
                    for (int index = 0;index < PossibleValues[x,y].Length;index++)
                    {
                        int value = PossibleValues[x, y][index];
                        if (row.Contains(value) || column.Contains(value) || submatrix.Contains(value))
                        {
                            PossibleValues[x, y] = PossibleValues[x, y].Remove(value);
                            index--;
                        }
                    }

                    ;
                }
            }
        }
        private static void EliminateValues()
        {
            for(int y=0;y < 9;y++)
            {
                for(int x = 0;x < 9;x++)
                {
                    if (PossibleValues[x, y].Length == 1)
                        CurrentBoard[x, y] = PossibleValues[x, y][0];
                }
            }
        }
        private static bool Validate()
        {
            for(int y = 0;y < 9;y++)
            {
                for(int x = 0;x < 9;x++)
                {
                    if (CurrentBoard[x, y] == 0)
                        return false;

                    int value = CurrentBoard[x, y];

                    int[] currentRow = CurrentBoard.GetRow(y);
                    int[] currentColumn = CurrentBoard.GetColumn(x);
                    int[,] submatrix = CurrentBoard.GetSubMatrix(x, y);
                    if (currentRow.CountOf(value) > 1 || currentColumn.CountOf(value) > 1 || submatrix.CountOf(value) > 1)
                        return false;
                }
            }

            return true;
        }
        

    }
}
