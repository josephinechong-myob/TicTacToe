using System;

namespace TicTacToe
{
    class Program
    {
        static void Main()
        { var board = new Board();
           Console.WriteLine(board.BoardToString());
           Console.WriteLine("################");
           Console.WriteLine(". . .\n. . .\n. . .");
        }
    }
}