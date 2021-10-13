using System;
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

        private string GetCoordinates(Enum insignia, string playerCoordinatesInput)
        {
            bool coordinatesAreValid = PlayerInputValidator.IsValidCoordinate(playerCoordinatesInput);
            
            while (!coordinatesAreValid)
            {
                _console.WriteLine("Please enter a coord with the format x,y. With x and y being a single digit");
                playerCoordinatesInput = GetPlayerInput(insignia); 
                coordinatesAreValid = PlayerInputValidator.IsValidCoordinate(playerCoordinatesInput);
            }
            return playerCoordinatesInput;
        }

        private bool HasPlayerQuit(string playerInput)
        {
            return playerInput == "q"; //game rule rather than validation
        }

        private string GetPlayerInput(Enum insignia)
        {
            var player = (insignia.Equals(Insignia.X)) ? "Player 1": "Player 2";
            _console.WriteLine($"{player} enter a coord x,y to place your {insignia} or enter 'q' to give up:");
            return _console.ReadLine();
        }

        private void SetPlayersCoordinates(Board board, String coordinates)
        {
       
           
            board.SetPlayersCoordinates(coordinates, Insignia);
        }

        private void Play(Board board)
        {
            var winner = false;
            var draw = false;
            var gameEvaluator = new GameEvaluator();
            
            while (!winner && !draw)
            {
                board.BoardStatus();
                var playerInput = string.Empty;//GetPlayerInput(Insignia);
                while (!PlayerInputValidator.IsValidCoordinate(playerInput) || board.PositionIsTaken(playerInput))
                {
                    playerInput = GetPlayerInput(Insignia);
                    if (!PlayerInputValidator.IsValidCoordinate(playerInput))
                    {
                        //write statement you liked here
                        _console.WriteLine("Please enter a coord with the format x,y. With x and y being a single digit");
                    }
                    else if (board.PositionIsTaken(playerInput))
                    {
                        //write is taken statement here
                        _console.WriteLine($"This position {playerInput} is already occupied");
                    }
                    
                    if (HasPlayerQuit(playerInput))
                    {
                        //player has quit!
                        _console.WriteLine($"Player {Insignia} has forfeit");
                        return;
                    }
                    
                }
                
                SetPlayersCoordinates(board, playerInput);
                
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