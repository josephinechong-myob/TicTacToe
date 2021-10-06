using System;

namespace TicTacToe
{
    class Program
    {
        static void Main()
        {
            var console = new GameConsole();
            var game = new Game(console);
            game.Run();
        }
    }
}