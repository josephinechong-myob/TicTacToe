namespace TicTacToe
{
    public class GameOutcome
    {
        public Status Status;
        public Insignia? Winner;

        public static GameOutcome WithWinner(Insignia winner)
        {
            return new GameOutcome
            {
                Status = Status.Won,
                Winner = winner
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
            if (Winner != null)
            {
                return $"{Winner.ToString()}-Player has won";  
            }
            else if (Status == Status.Draw)
            {
                return "There is a tie";  
            }
            else if (Status == Status.Ongoing)
            {
                return "Game is in progress";  
            }
            else
            {
                return "It's a forfeit";  
            }
        }
    }
}