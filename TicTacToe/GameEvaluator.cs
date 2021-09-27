using System;

namespace TicTacToe
{
    public class GameEvaluator
    {
        private bool ThereIsAVerticalWin(string[][] cells, int x, int y, string insignia)
        {
            if (cells[y][x] == cells[y + 1][x] && cells[y + 1][x] == cells[y + 2][x] && cells[y][x] == insignia)
            {
                return true;
            }
            return false;
        }
        public string GameOutcome(Board board, string insignia) //could output enum
        {
            var cells = board.Cells;
            var occurrence = 0;
            var outcome = $"Game is {Status.Ongoing}";
            var win = false;

            for (int y = 0; y < cells.Length && !win; y++)
            {
                for (int x = 0; x < cells[y].Length; x++)
                {
                    if (cells[y][x].Contains(insignia)) 
                    {
                        occurrence += 1;
                    }
                    
                    if(y == 0 && ThereIsAVerticalWin(cells, x, y, insignia))
                    {
                        outcome = $"{insignia}-Player has {Status.Won}";
                        return outcome;
                    }
                    
                    if (y == 0 && x == 0)
                    {
                        if (
                            (cells[y][x] == cells[y + 1][x + 1] && cells[y + 1][x + 1] == cells[y + 2][x + 2] && cells[y][x] == insignia) //diagonal
                            || 
                            (cells[y][x + 2] == cells[y + 1][x + 1] && cells[y + 1][x + 1] == cells[y + 2][x] && cells[y][x + 2] == insignia)
                        )
                        {
                            outcome = $"{insignia}-Player has {Status.Won}";
                            win = true;
                        }
                    }
                }
                if (occurrence == 3)
                {
                    outcome = $"{insignia}-Player has {Status.Won}";
                    win = true;
                }
                occurrence = 0;
            }
            Console.WriteLine(outcome);
            return outcome;
        }
    }
}