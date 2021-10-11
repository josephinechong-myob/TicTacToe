using System;

namespace TicTacToe
{
    public class OverridingException : Exception
    {
        public OverridingException(string message)
            : base(message)
        {
        }
    }
}