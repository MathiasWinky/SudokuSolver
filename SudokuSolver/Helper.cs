using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver
{
    public static class Helper
    {
        private static int[,] _lastBoard;

        public static void PrintBoard(int[,] Board)
        {
            Console.Clear();
            for(int y = 0; y < 9;y++)
            {
                if (y == 3 || y == 6)
                    Console.WriteLine("-----------");

                for (int x = 0;x < 9;x++)
                {
                    if (x == 3 || x == 6)
                        Console.Write("|");

                    if (_lastBoard != null  && _lastBoard[x, y] != Board[x, y])
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(Board[x, y] == 0 ? " " : Board[x,y].ToString());
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
                
            }

            _lastBoard = Board.Copy();
        }

    }
}
