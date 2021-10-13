using System;

namespace TicTacToe
{
    public class Coordinate
    {
        public int X;
        public int Y;

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool TryParse(string input, out Coordinate coordinate)
        {
            try
            {
                var coordinateStrings = input.Split(',');
                var x = Int32.Parse(coordinateStrings[0]) - 1;
                var y = Int32.Parse(coordinateStrings[1]) - 1;
                coordinate = new Coordinate(x, y);
                return true;
            }
            catch
            {
                coordinate = null;
                return false;
            }
        }

    }
}