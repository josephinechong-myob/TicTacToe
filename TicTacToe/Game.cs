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
        
        private string GetPlayerInput(Insignia insignia)
        {
            var player = SelectPlayer(insignia);
            _console.WriteLine($"{player} enter a coord x,y to place your {insignia} or enter 'q' to give up:");
            return _console.ReadLine();
        }
        
        private bool HasGameCompleted(GameOutcome outcome)
        {
            return outcome.Status == Status.Won || outcome.Status == Status.Draw;
        }
        
        private bool HasPlayerQuit(string playerInput)
        {
            return playerInput == "q"; 
        }
        
        private CoordinateValidationResult CoordinateIsValid(string playerInput)
        {
            Coordinate.TryParse(playerInput, out var coordinate);
            
            if (!PlayerInputValidator.IsValidCoordinate(playerInput))
            {
                return CoordinateValidationResult.BadCoordinateFormat;
            }

            if (coordinate != null && _board.PositionIsTaken(coordinate))
            {
                return CoordinateValidationResult.CoordinateIsOccupied;
            }

            return CoordinateValidationResult.Valid;
        }

        private void PrintValidationStatement(CoordinateValidationResult validationResult, string playerInput)
        {
            switch (validationResult)
            {
                case CoordinateValidationResult.BadCoordinateFormat:
                    _console.WriteLine("Please enter a coord with the format x,y. With x and y being a single digit");
                    break;
                case CoordinateValidationResult.CoordinateIsOccupied:
                    _console.WriteLine($"This position {playerInput} is already occupied");
                    break;
            } 
        }

        private void PrintPlayerHasForfeit()
        {
            var player = SelectPlayer(Insignia);
            _console.WriteLine($"{player} has forfeit");
        }
        
        private Status MakePlayersMove()
        {
            var playerInput = string.Empty;
            Coordinate.TryParse(playerInput, out var coordinate);
            var validationResult = CoordinateIsValid(playerInput);
            
            while (validationResult != CoordinateValidationResult.Valid)
            {
                playerInput = GetPlayerInput(Insignia);
                validationResult = CoordinateIsValid(playerInput);
                
                if (HasPlayerQuit(playerInput))
                {
                    PrintPlayerHasForfeit();
                    return Status.Forfeit;
                }
                
                Coordinate.TryParse(playerInput, out coordinate);
                PrintValidationStatement(validationResult, playerInput);
            }
            
            SetPlayersCoordinates(coordinate);
            return Status.Ongoing;
        }
        
        private void MakeTurns(string insignia)
        {
            Insignia = (insignia == "X") ? Insignia.O : Insignia.X;
        }
        
        private void Play()
        {
            var gameCompleted = false;
            var gameEvaluator = new GameEvaluator();
            
            while (!gameCompleted)
            {
                _board.BoardStatus();
                var moveStatus = MakePlayersMove();
                if (moveStatus == Status.Forfeit)
                {
                    return;
                }
                var outcome = gameEvaluator.FindGameOutcome(_board, Insignia.ToString());
                _console.WriteLine(outcome.ToString());
                gameCompleted = HasGameCompleted(outcome);
                MakeTurns(Insignia.ToString());
            }
        }
        
        private string SelectPlayer(Insignia insignia)
        {
            return (insignia.Equals(Insignia.X)) ? "Player 1": "Player 2";
        }
        
        private void SetPlayersCoordinates(Coordinate coordinates)
        {
            _board.SetPlayersCoordinates(coordinates, Insignia);
        }
    }
}