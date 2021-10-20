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
            
           //game.Run();

            while (game.PlayerWantsToPlayAgain())
            {
                board.ResetBoard();
                game = new Game(console, board);
                game.Run();
            }
            
            //ask user to play again after a win or draw (while loop condition bool)
            //player quits and still is asked if they want to play again
        }
    }
}