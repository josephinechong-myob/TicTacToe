using System;
using System.Linq;

namespace TicTacToe
{
    public class Board
    {
        public string[][] Cells { get; set; }
        private readonly IConsole _console;
        private string[][] _emptyBoard = new string[][]
        {
            new string[]{".",".","."},
            new string[]{".",".","."},
            new string[]{".",".","."},
        };
        public Board(IConsole console)
        {
            Cells = _emptyBoard;
            _console = console;
        }
        public Board(String[][] cells, IConsole console)
        {
            Cells = cells;
            _console = console;
        }
        
        public string BoardToString()
        {
            var boardString = "";
            foreach(String[]item in Cells)
            {
                foreach (var position in item)
                {
                    boardString += position + " ";
                }
                boardString += "\n";
            }
            return boardString;
        }
        
        public string SetPlayersCoordinates(Coordinate coordinate, Enum insignia)
        {
            if (Cells[coordinate.Y][coordinate.X] == ".")
            { 
                Cells[coordinate.Y][coordinate.X] = insignia.ToString();
            }
            else
            {
                throw new OverridingException(string.Format("This position {0} is already occupied", coordinate));
            }
            return BoardToString();
        }

        public bool PositionIsTaken(Coordinate coordinate)
        {
            return Cells[coordinate.Y][coordinate.X] != ".";
        }
  
        public string[][] ResetBoard()
        {
            Cells = _emptyBoard;
            return Cells;
        }

        public bool IsANewGame()
        {
            return Cells.ToString() == _emptyBoard.ToString();
        }
        
        public void BoardStatus()
        {
            var x = (Cells.Any(c => c.Contains("O") || c.Contains("X"))) ? "Move accepted, h" : "H";
            var text = $"{x}ere's the current board:";
            _console.WriteLine(text);
            _console.WriteLine(BoardToString());
        }
    }
}