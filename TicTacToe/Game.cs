using System;
using System.Linq;

namespace TicTacToe
{
    public class Game
    {
        public Insignia Insignia { get; set; } //set to X or O to alternate between player 1 and player 2
        private void Greeting()
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
        }

        private string Coordinates(Enum insignia) //user input
        {
            var player = (insignia.Equals(Insignia.X)) ? "Player 1": "Player 2";
            Console.WriteLine($"{player} enter a coord x,y to place your {insignia} or enter 'q' to give up:"); //player 1 = X
            var coordinate = Console.ReadLine();
            return coordinate;
        }

        private void Play(Board board)
        {
            var winner = false;
            var gameEvaluator = new GameEvaluator();
            
            while (!winner)
            {
                board.BoardStatus();
                if (Insignia.ToString() == "X")
                {
                    Insignia = Insignia.O;
                }
                else
                {
                    Insignia = Insignia.X;
                }   
                var input = Coordinates(Insignia);
                board.SetChoice(input, Insignia);
                var outcome = gameEvaluator.GameOutcome(board, Insignia.ToString());
                if (outcome.Equals(Status.Won))
                {
                    winner = true;
                }
            }
            
        }
        //method play
        
        public void Run()
        {
            var board = new Board();
            
            Greeting();
            Play(board);
        }
        //player X starts 
        //
    }
}