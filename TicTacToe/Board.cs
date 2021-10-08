using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace TicTacToe
{
    public class Board
    {
        public string[][] Cells { get; set; }
        private readonly IConsole _console;
        public Board(IConsole console)
        {
            Cells = new string[][]
            {
                new string[]{".",".","."},
                new string[]{".",".","."},
                new string[]{".",".","."},
            };
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

        public string SetChoice(string coordinate, Enum insignia)
        {
            var index = coordinate.Split(",");
            var first = Int32.Parse(index[0]);
            var second = Int32.Parse(index[1]);
          
            if (Cells[first][second] == ".") //while loop
            { 
                Cells[first][second] = insignia.ToString();
            }
            else
            {
                throw new OverridingException(string.Format("This position {0} is already occupied", coordinate));
            }
            return BoardToString();
        }
        
  
        public string[][] ResetBoard()
        {
            Cells = new string[][]
            {
                new string[]{".",".","."},
                new string[]{".",".","."},
                new string[]{".",".","."},
            };
            return Cells;
        }
        
        public void BoardStatus()
        {
            var x = (Cells.Any(c => c.Contains("O") || c.Contains("X"))) ? "Move accepted, h" : "H";
            var text = $"{x}ere's the current board:";
            _console.WriteLine(text);
            _console.WriteLine(BoardToString());
        }

        //always 2 players always be O or X based on player
        // expriment - playable product in program - to run
    }
}