using System;

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

        // private string GetCoordinates(Enum insignia, string playerCoordinatesInput)
        // {
        //     bool coordinatesAreValid = PlayerInputValidator.IsValidCoordinate(playerCoordinatesInput);
        //     
        //     while (!coordinatesAreValid)
        //     {
        //         _console.WriteLine("Please enter a coord with the format x,y. With x and y being a single digit");
        //         playerCoordinatesInput = GetPlayerInput(insignia); 
        //         coordinatesAreValid = PlayerInputValidator.IsValidCoordinate(playerCoordinatesInput);
        //     }
        //     return playerCoordinatesInput;
        // }

        private bool HasPlayerQuit(string playerInput)
        {
            return playerInput == "q"; //game rule rather than validation
        }

        private string GetPlayerInput(Insignia insignia)
        {
            var player = SelectPlayer(insignia);
            _console.WriteLine($"{player} enter a coord x,y to place your {insignia} or enter 'q' to give up:");
            return _console.ReadLine();
        }

        private void SetPlayersCoordinates(Board board, Coordinate coordinates)
        {
            board.SetPlayersCoordinates(coordinates, Insignia);
        }

        private string SelectPlayer(Insignia insignia)
        {
            return (insignia.Equals(Insignia.X)) ? "Player 1": "Player 2";
        }

        private void Play(Board board)
        {
            var winner = false;
            var draw = false;
            var gameEvaluator = new GameEvaluator();
            
            while (!winner && !draw)
            {
                board.BoardStatus();
                var playerInput = string.Empty;
                Coordinate.TryParse(playerInput, out var coordinate);
                while (!PlayerInputValidator.IsValidCoordinate(playerInput) || (coordinate != null && board.PositionIsTaken(coordinate)))
                {
                    playerInput = GetPlayerInput(Insignia);
                    Coordinate.TryParse(playerInput, out coordinate);
                    if (!PlayerInputValidator.IsValidCoordinate(playerInput))
                    {
                        _console.WriteLine("Please enter a coord with the format x,y. With x and y being a single digit");
                    }
                    else if (board.PositionIsTaken(coordinate))
                    {
                        _console.WriteLine($"This position {playerInput} is already occupied");
                    }
                    if (HasPlayerQuit(playerInput))
                    {
                        var player = SelectPlayer(Insignia);
                        _console.WriteLine($"{player} has forfeit");
                        return;
                    }
                }
                
                SetPlayersCoordinates(board, coordinate);
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