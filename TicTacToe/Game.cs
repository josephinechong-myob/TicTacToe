using System;

namespace TicTacToe
{
    public class Game
    {
        //dependency injection of the console and board
        private Insignia Insignia { get; set; } 
        private readonly IConsole _console;
        private readonly Board _board;

        public Game(IConsole console, Board board)
        {
            _console = console;
            Insignia = Insignia.X;
            _board = board;
        }
        
        public void Run()
        {
            Greeting();
            Play();
        }
        
        private void Greeting()
        {
            _console.WriteLine("Welcome to Tic Tac Toe!");
        }
        
        private void Play()
        {
            var winner = false;
            var draw = false;
            var gameEvaluator = new GameEvaluator();
            
            while (!winner && !draw)
            {
                _board.BoardStatus();
                var playersMove = PlayersMove();
                var outcome = gameEvaluator.FindGameOutcome(_board, Insignia.ToString(), playersMove);
                _console.WriteLine(outcome.ToString());
                
                switch (outcome.Status)
                {
                    case Status.Forfeit:
                        return;
                    case Status.Won:
                        winner = true;
                        break;
                    case Status.Draw:
                        draw = true;
                        break;
                }

                MakeTurns(Insignia.ToString());
            }
        }
        
        //private Status MakePlayersMove() //refactor? make game validator, L49 take bool logic out
        private bool PlayersMove()
        {
            var playerInput = string.Empty;
            Coordinate.TryParse(playerInput, out var coordinate);
            while (!PlayerInputValidator.IsValidCoordinate(playerInput) || (coordinate != null && _board.PositionIsTaken(coordinate)))
            {
                playerInput = GetPlayerInput(Insignia);
                Coordinate.TryParse(playerInput, out coordinate);
                if (!PlayerInputValidator.IsValidCoordinate(playerInput))
                {
                    _console.WriteLine("Please enter a coord with the format x,y. With x and y being a single digit");//showing when we quit
                }
                else if (_board.PositionIsTaken(coordinate))
                {
                    _console.WriteLine($"This position {playerInput} is already occupied");
                }
                if (HasPlayerQuit(playerInput))
                {
                    var player = SelectPlayer(Insignia);
                    _console.WriteLine($"{player} has forfeit");
                    //return Status.Forfeit;
                    return true;
                }
            }
            SetPlayersCoordinates(coordinate); //setting position on board & checking if player has quit & wrong input & exisitng position
            //return Status.Ongoing;
            return false;
        }
        
        private string GetPlayerInput(Insignia insignia)
        {
            var player = SelectPlayer(insignia);
            _console.WriteLine($"{player} enter a coord x,y to place your {insignia} or enter 'q' to give up:");
            return _console.ReadLine();
        }
        
        private bool HasPlayerQuit(string playerInput)
        {
            return playerInput == "q"; //game rule rather than validation
        }
        
        private string SelectPlayer(Insignia insignia)
        {
            return (insignia.Equals(Insignia.X)) ? "Player 1": "Player 2";
        }
        
        private void SetPlayersCoordinates(Coordinate coordinates)
        {
            _board.SetPlayersCoordinates(coordinates, Insignia);
        }
        
        private void MakeTurns(string insignia)
        {
            Insignia = (insignia == "X") ? Insignia.O : Insignia.X;
        }
    }
}