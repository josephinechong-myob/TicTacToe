using System;
using System.Linq;

namespace TicTacToe
{
    public class Game
    {
        public string Player { get; } //set to X or O to alternate between player 1 and player 2
        private void Greeting()
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
        }

        private string Coordinates() //unser input
        {
            var player = "Player 1";
            var insignia = "X";
            Console.WriteLine($"{player} enter a coord x,y to place your {insignia} or enter 'q' to give up:"); //player 1 = X
            var coordinate = Console.ReadLine();
            return coordinate;
        }
        
        //method play
        
        public void Run()
        {
            var board = new Board();
            
            Greeting();
            
            board.BoardStatus();
            board.SetChoice("coordinate", "X");
            
            board.BoardStatus();
            board.SetChoice("coordinate", "O");

        }
        //player X starts 
        //
    }
}