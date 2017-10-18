using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver
{
    public static class MatrixExtensions
    {
        public static int[] GetRow(this int[,] Matrix, int RowIndex)
        {
            int[] result = new int[9];
            for (int i = 0; i < 9; i++)
                result[i] = Matrix[i, RowIndex];
            return result;
        }

        public static int[] GetColumn(this int[,] Matrix, int ColumnIndex)
        {
            int[] result = new int[9];
            for (int i = 0; i < 9; i++)
                result[i] = Matrix[ColumnIndex, i];
            return result;
        }

        public static int[,] GetSubMatrix(this int[,] Matrix, Submatrix Position)
        {
            int[,] result = new int[3, 3];
            int xStart = ((int)Position % 3) * 3;
            int yStart = ((int)Position / 3) * 3;

            for (int y = yStart; y < yStart + 3; y++)
                for (int x = xStart; x < xStart + 3; x++)
                    result[x - xStart, y - yStart] = Matrix[x, y];

            return result;
        }

        public static int[,] GetSubMatrix(this int[,] Matrix, int BoardX, int BoardY)
        {
            Submatrix pos = Submatrix.Center;

            switch (BoardX / 3)
            {
                case 0:
                    switch (BoardY / 3)
                    {
                        case 0:
                            pos = Submatrix.TopLeft;
                            break;
                        case 1:
                            pos = Submatrix.MiddleLeft;
                            break;
                        case 2:
                            pos = Submatrix.BottomLeft;
                            break;
                    }
                    break;
                case 1:
                    switch (BoardY / 3)
                    {
                        case 0:
                            pos = Submatrix.TopMiddle;
                            break;
                        case 1:
                            pos = Submatrix.Center;
                            break;
                        case 2:
                            pos = Submatrix.BottomMiddle;
                            break;
                    }
                    break;
                case 2:
                    switch (BoardY / 3)
                    {
                        case 0:
                            pos = Submatrix.TopRight;
                            break;
                        case 1:
                            pos = Submatrix.MiddleRight;
                            break;
                        case 2:
                            pos = Submatrix.BottomRight;
                            break;
                    }
                    break;
            }

            return GetSubMatrix(Matrix, pos);
        }

        public static int[,] Copy(this int[,] Matrix)
        {
            int[,] result = new int[Matrix.GetUpperBound(0) + 1, Matrix.GetUpperBound(1) + 1];

            int z = Matrix.GetUpperBound(1);

            for (int y = 0; y < Matrix.GetUpperBound(1)+1; y++)
                for (int x = 0; x < Matrix.GetUpperBound(0)+1; x++)
                    result[x, y] = Matrix[x, y];

            return result;
        }

        public static int CountOf(this int[,] Matrix, int Value)
        {
            int count = 0;
            for(int y = 0; y < Matrix.GetUpperBound(1) +1;y++)
            {
                for(int x = 0;x  <Matrix.GetUpperBound(0) + 1;x++)
                {
                    if (Matrix[x, y] == Value)
                        count++;
                }
            }

            return count;
        }

        public static bool Contains(this int[,] Matrix, int Value)
        {
            for (int y = 0; y < Matrix.GetUpperBound(1)+1; y++)
                for (int x = 0; x < Matrix.GetUpperBound(0)+1; x++)
                    if (Matrix[x, y] == Value)
                        return true;
            return false;
        }

    }

    public static class ArrayExtensions
    {
        public static int[] Remove(this int[] Arr, int Value)
        {
            int[] result = new int[Arr.Length - 1];

            int resultIndex = 0;
            for (int i = 0; i < Arr.Length; i++)
            {
                if (Arr[i] == Value)
                    continue;

                result[resultIndex++] = Arr[i];
            }

            return result;
        }

        public static bool Contains(this int[] Arr, int Value)
        {
            for (int i = 0; i < Arr.Length; i++)
                if (Arr[i] == Value)
                    return true;
            return false;
        }

        public static int CountOf(this int[] Arr, int Value)
        {
            int count = 0;
            for (int i = 0; i < Arr.Length; i++)
                if (Arr[i] == Value)
                    count++;

            return count;
        }

    }

    public enum Submatrix
    {
        TopLeft, TopMiddle, TopRight, MiddleLeft, Center, MiddleRight, BottomLeft, BottomMiddle, BottomRight
    }
}
