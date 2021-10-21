using System.Text.RegularExpressions;

namespace TicTacToe
{
    public class PlayerInputValidator
    {
        public static bool IsValidCoordinate(string playerInput)
        {
            var pattern = new Regex(@"^[123],[123]$");
            var positionIsValid = pattern.IsMatch(playerInput);
            return positionIsValid;
        }
        
        public static bool IsValidResetOption(string playerInput)
        {
            var pattern = new Regex(@"^[01]$");
            var optionIsValid = pattern.IsMatch(playerInput);
            return optionIsValid;
        }
    }
}