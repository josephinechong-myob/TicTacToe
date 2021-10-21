using System;

namespace TicTacToe
{
    internal static class Program
    {
        private static void Main()
        {
            var console = new GameConsole();
            var board = new Board(console);
            var game = new Game(console, board);
            
            game.Run();
        }
    }
}