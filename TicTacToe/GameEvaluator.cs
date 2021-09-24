using System;
using System.Linq;

namespace TicTacToe
{
    public class GameEvaluator
    {
        public string GameOutcome(Board board) //could output enum
        {
            var cells = board.Cells;
            var occurrence = 0;
            var outcome = "";
            var win = false;
            //"in progress" (if there is no win and there are empty cells)
            
            for (int y = 0; y < cells.Length && !win; y++) //down
            {
                for (int x = 0; x < cells[y].Length; x++) //across 
                {
                    if (cells[y][x].Contains("X")) 
                    {
                        occurrence += 1;
                    }

                    if (y == 0 && (x == 0 || x == 1 || x == 2))
                    {
                        if (cells[y][x] == cells[y + 1][x] && cells[y + 1][x] == cells[y + 2][x] && cells[y][x] == "X")
                        {
                            outcome = "X-Player wins";
                            win = true; 
                        }
                    }
                }
                if (occurrence == 3)
                {
                    outcome = "X-Player wins";
                    win = true;
                }
                occurrence = 0;
            }

            Console.WriteLine(outcome);
            return outcome;
        }
    }
}