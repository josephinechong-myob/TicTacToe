using System;

namespace TicTacToe
{
    class Program
    {
        static void Main()
        {
            var console = new GameConsole();
            var board = new Board(console);
            var game = new Game(console, board);
            game.Run();
        }
    }
}