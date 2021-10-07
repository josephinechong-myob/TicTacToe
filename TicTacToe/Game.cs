using System;
using System.Linq;

namespace TicTacToe
{
    public class Game
    {
        private Insignia Insignia { get; set; } 
        private readonly IConsole _console;

        public Game(IConsole console)
        {
            _console = console;
            Insignia = Insignia.X;
        }
        private void Greeting()
        {
            _console.WriteLine("Welcome to Tic Tac Toe!");
        }

        private string Coordinates(Enum insignia)
        {
            var player = (insignia.Equals(Insignia.X)) ? "Player 1": "Player 2";
            _console.WriteLine($"{player} enter a coord x,y to place your {insignia} or enter 'q' to give up:"); //player 1 = X
            var coordinate = _console.ReadLine();
            return coordinate;
        }

        private void Play(Board board)
        {
            var winner = false;
            var gameEvaluator = new GameEvaluator();
            
            while (!winner)
            {
                board.BoardStatus();
                var input = Coordinates(Insignia);
                board.SetChoice(input, Insignia);
                var outcome = gameEvaluator.FindGameOutcome(board, Insignia.ToString());
                _console.WriteLine(outcome.ToString());
                if (outcome.Status == Status.Won)
                {
                    winner = true;
                }
                if (Insignia.ToString() == "X")
                {
                    Insignia = Insignia.O;
                }
                else
                {
                    Insignia = Insignia.X;
                } 
            }
        }

        public void Run()
        {
            var board = new Board(_console);
            
            Greeting();
            Play(board);
        }
    }
}