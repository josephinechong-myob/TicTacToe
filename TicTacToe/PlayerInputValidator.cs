using System.Text.RegularExpressions;

namespace TicTacToe
{
    public class PlayerInputValidator
    {
        public static bool IsValidCoordinate(string playerInput)
        {
            var pattern = new Regex(@"^[012],[012]$");
            var positionIsValid = pattern.IsMatch(playerInput);
            return positionIsValid;
        }
        
        //invalid throw an exception
        
    }
}