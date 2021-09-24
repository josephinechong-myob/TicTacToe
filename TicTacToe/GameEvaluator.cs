using System;
using System.Linq;

namespace TicTacToe
{
    public class GameEvaluator
    {
        public string GameOutcome(Board board) //could output enum
        {
            var cells = board.Cells;
            var occurance = 0;
            var outcome = "";
            var win = false;
            //while loop - while(condition)
            //for loop - for(initial_state;condition;change_state)
            for (int y = 0; y < cells.Length && !win; y++) //down
            {
                for (int x = 0; x < cells[y].Length; x++) //across //look at time complexity
                {
                    if (cells[y][x].Contains("X")) 
                    {
                        occurance += 1;
                    }
                }
                if (occurance == 3)
                {
                    outcome = "X-Player wins";
                    win = true;
                }
                occurance = 0;
            }
            
            Console.WriteLine(outcome);

            //"in progress" (if there is no win and there are empty cells)
            
            //win combos:
            //all on the same line (same array),
            //same vertical (same position in differnt lines),
            //diagonal (different lines, different positions)

            return outcome;
        }
    }
}