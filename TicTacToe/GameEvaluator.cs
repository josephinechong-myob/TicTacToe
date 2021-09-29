using System;
using System.Linq;

namespace TicTacToe
{
    public class GameEvaluator //list of winning positions and checking if they hit - if it's more dry less code
    {
        private readonly string _inProgress = $"Game is {Status.Ongoing}";
        private bool ThereIsAVerticalWin(string[][] cells, int x, int y, string insignia)
        {
            if (cells[y][x] == cells[y + 1][x] && cells[y + 1][x] == cells[y + 2][x] && cells[y][x] == insignia)
            {
                return true;
            }
            return false;
        }

        private bool ThereIsALeftToRightDiagonalWin(string[][] cells, int x, int y, string insignia)
        {
            if (cells[y][x] == cells[y + 1][x + 1] && cells[y + 1][x + 1] == cells[y + 2][x + 2] &&
                 cells[y][x] == insignia)
            {
                return true;
            }
            return false;
        }
        
        private bool ThereIsARightToLeftDiagonalWin(string[][] cells, int x, int y, string insignia)
        {
            if (cells[y][x + 2] == cells[y + 1][x + 1] && cells[y + 1][x + 1] == cells[y + 2][x] &&
                 cells[y][x + 2] == insignia)
            {
                return true;
            }
            return false;
        }

        private bool ThereIsADiagonalWin(string[][] cells, int x, int y, string insignia)
        {
            if (ThereIsALeftToRightDiagonalWin(cells, x, y, insignia) || ThereIsARightToLeftDiagonalWin(cells, x, y, insignia))
            {
                return true;
            }
            return false;
        }

        private string GetCurrentOutcome(string[][] cells, int x, int y, string insignia, int occurrence)
        {
            var outcome = _inProgress;
            if(y == 0 && ThereIsAVerticalWin(cells, x, y, insignia))
            {
                outcome = $"{insignia}-Player has {Status.Won}";
                return outcome;
            }
                    
            if (y == 0 && x == 0 && ThereIsADiagonalWin(cells, x, y, insignia))
            {
                outcome = $"{insignia}-Player has {Status.Won}";
                return outcome;
            }
                    
            if (IsThereHorizontalWin(occurrence))
            {
                outcome = $"{insignia}-Player has {Status.Won}";
                return outcome;
            }
            return outcome;
        }

        private bool IsThereHorizontalWin(int occurrence)
        {
            if (occurrence == 3)
            {
                return true;
            }
            return false;
        }

        private bool IsItADraw(string[][] cells)
        {
            return !cells.Any(s => s.Contains("."));
        }

        /*private bool IsItAForfeit(string[][] cells, bool stillPlaying)
        {
            return false;
        }*/
        
        public string GameOutcome(Board board, string insignia)
        {
            var cells = board.Cells;
            var occurrence = 0;
            var outcome = _inProgress;
            var win = false;
            
            for (int y = 0; y < cells.Length && !win; y++)
            {
                for (int x = 0; x < cells[y].Length; x++)
                {
                    if (cells[y][x].Contains(insignia)) 
                    {
                        occurrence += 1;
                    }
                    outcome = GetCurrentOutcome(cells, x, y, insignia, occurrence);
                    if (outcome != _inProgress)
                    {
                        return outcome;
                    }
                }
                occurrence = 0;
            }

            if (IsItADraw(cells))
            {
                outcome = $"There is a {Status.Draw}";
            }
            /*else if(!stillPlaying && !IsItADraw(cells))
            {
                outcome = $"There is a {Status.Forfeit}";
            }*/
            
            Console.WriteLine(outcome);
            return outcome;
        }
    }
}