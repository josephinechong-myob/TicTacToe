using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class Board
    {
        public string[][] Cells { get; set; }
        public Board()
        {
            Cells = new string[][]
            {
                new string[]{".",".","."},
                new string[]{".",".","."},
                new string[]{".",".","."},
            };
        }
        public Board(String[][] cells)
        {
            Cells = cells;
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

        public string SetChoice(string coordinate, Enum insignia) //do not overwrite existing players position
        {
            
            var index = coordinate.Split(",");
            var first = Int32.Parse(index[0]);
            var second = Int32.Parse(index[1]);
            Cells[first][second] = insignia.ToString();
            return BoardToString();
        }
        //reset board

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
            Console.WriteLine(text);
            Console.WriteLine(BoardToString());
        }

        //always 2 players always be O or X based on player
        // expriment - playable product in program - to run
    }
}