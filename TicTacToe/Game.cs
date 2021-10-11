using System;
using System.Linq;
using System.Text.RegularExpressions;

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

        private string Coordinates(Enum insignia, string playerInput)
        {
            bool positionIsValid = false;
            var coordinate = playerInput;
            while (!positionIsValid)
            {
                var pattern = new Regex(@"^[012],[012]$");
                positionIsValid = pattern.IsMatch(coordinate);
                if (!positionIsValid)
                {
                    _console.WriteLine("Please enter a coord with the format x,y. With x and y being a single digit");
                    coordinate = GetPlayerInput(insignia); 
                }
            }
            return coordinate;
        }

        private bool HasPlayerQuit(string playerInput)
        {
            return playerInput == "q";
        }

        private string GetPlayerInput(Enum insignia)
        {
            var player = (insignia.Equals(Insignia.X)) ? "Player 1": "Player 2";
            _console.WriteLine($"{player} enter a coord x,y to place your {insignia} or enter 'q' to give up:");
            return _console.ReadLine();
        }

        private void SetPlayersChoice(Board board, String playerInput)
        {
            bool choiceIsValid = false;
            
            while (!choiceIsValid)
            {
                var input = Coordinates(Insignia, playerInput);
                try
                {
                    board.SetChoice(input, Insignia);
                    choiceIsValid = true;
                }
                catch (OverridingException ex)
                {
                    _console.WriteLine("Try another position. " + ex.Message);
                }
            }
        }

        private void Play(Board board)
        {
            var winner = false;
            var draw = false;
            var gameEvaluator = new GameEvaluator();
            
            while (!winner && !draw)
            {
                board.BoardStatus();
                var playerInput = GetPlayerInput(Insignia);
                if (HasPlayerQuit(playerInput))
                {
                    //player has quit!
                    _console.WriteLine($"Player {Insignia} has forfeit");
                    return;
                }
                SetPlayersChoice(board, playerInput);
                
                var outcome = gameEvaluator.FindGameOutcome(board, Insignia.ToString());
                _console.WriteLine(outcome.ToString());
                if (outcome.Status == Status.Won)
                {
                    winner = true;
                }
                if (outcome.Status == Status.Draw)
                {
                    draw = true;
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