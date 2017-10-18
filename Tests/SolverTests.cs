using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using SudokuSolver;

namespace Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void Solve_Test()
        {
            int[] starting = "003020600900305001001806400008102900700000008006708200002609500800203009005010300".Select(x=>Convert.ToInt32(x.ToString())).ToArray();
            int[] expected = "483921657967345821251876493548132976729564138136798245372689514814253769695417382".Select(x=>Convert.ToInt32(x.ToString())).ToArray();

            var result = Solver.Solve(starting);

            int[] flat = new int[81];
            int index = 0;
            for (int y = 0; y < 9; y++)
                for (int x = 0; x < 9; x++)
                    flat[index++] = result[x, y];

            Assert.IsTrue(flat.SequenceEqual(expected));
        }
    }
}
