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
            
            for (int i = 0; i < cells.Length; i++)
            {
                if (cells[i].Contains("X"))
                {
                    occurance += 1;
                }
                for (int j = 0; j < cells.Length; j++)
                {
                    if (cells[j].Contains("X"))
                    {
                        occurance += 1;
                    }
                }
            }

            if (occurance == 3)
            {
                outcome = "X-Player wins";
                win = true;
            }
            
            //if(!win && )

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