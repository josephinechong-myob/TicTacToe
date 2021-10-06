namespace TicTacToe
{
    public class GameOutcome
    {
        public Status Status;
        public Insignia? Winner;
        
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