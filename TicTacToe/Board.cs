using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Board
    {
        public string[][] Cells { get; }
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

        public string SetChoice(string input, string symbol)
        {
            var index = input.Split(",");
            var first = Int32.Parse(index[0]);
            var second = Int32.Parse(index[1]);
            Cells[first][second] = symbol;
            return BoardToString();
        }
        //reset board
        //assess the board
        
        //always 2 players always be O or X based on player
        // expriment - playable product in program - to run
    }
}