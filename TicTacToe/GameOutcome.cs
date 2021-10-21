namespace TicTacToe
{
    public class GameOutcome
    {
        public Status Status;
        private Insignia? _winner;

        public static GameOutcome WithWinner(Insignia winner)
        {
            return new GameOutcome
            {
                Status = Status.Won,
                _winner = winner
            };
        }

        public static GameOutcome Draw()
        {
            return new GameOutcome()
            {
                Status = Status.Draw,
            };
        }
        
        public static GameOutcome Ongoing()
        {
            return new GameOutcome()
            {
                Status = Status.Ongoing,
            };
        }
        
        public override string ToString()
        {
            if (_winner != null)
            {
                return $"{_winner.ToString()}-Player has won";  
            }

            if (Status == Status.Draw)
            {
                return "There is a tie";  
            }

            if (Status == Status.Ongoing)
            {
                return "Game is in progress";  
            }
            
            return "It's a forfeit";
        }
    }
}