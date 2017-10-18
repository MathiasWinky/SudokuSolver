using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SudokuSolver;

namespace Tests
{
    [TestClass]
    public class MatrixExtensionTests
    {
        [TestMethod]
        public void GetRow_Test()
        {
            int[,] matrix = new int[9, 9];

            for (int i = 0; i < 9; i++)
                matrix[i, 2] = 6;

            int[] result = matrix.GetRow(2);
            for (int i = 0; i < result.Length; i++)
                Assert.IsTrue(result[i] == 6);
        }

        [TestMethod]
        public void GetColumn_Test()
        {
            int[,] matrix = new int[9, 9];
            for (int i = 0; i < 9; i++)
                matrix[5, i] = 3;

            int[] result = matrix.GetColumn(5);
            for (int i = 0; i < 9; i++)
                Assert.IsTrue(result[i] == 3);
        }

        [TestMethod]
        public void GetSubMatrix_Test()
        {
            int[,] matrix = new int[9, 9];

            //274
            //831
            //596
            matrix[0, 0] = 2;
            matrix[1, 0] = 7;
            matrix[2, 0] = 4;
            matrix[0, 1] = 8;
            matrix[1, 1] = 3;
            matrix[2, 1] = 1;
            matrix[0, 2] = 5;
            matrix[1, 2] = 9;
            matrix[2, 2] = 6;

            int[,] submatrix = matrix.GetSubMatrix(Submatrix.TopLeft);

            int[] expected = new int[] { 2, 7, 4, 8, 3, 1, 5, 9, 6 };
            int expectedIndex = 0;
            for (int y = 0; y < 3; y++)
                for (int x = 0; x < 3; x++)
                    Assert.IsTrue(submatrix[x, y] == expected[expectedIndex++]);

            submatrix = matrix.GetSubMatrix(1, 1);
            expectedIndex = 0;
            for (int y = 0; y < 3; y++)
                for (int x = 0; x < 3; x++)
                    Assert.IsTrue(submatrix[x, y] == expected[expectedIndex++]);
        }
    }
}
