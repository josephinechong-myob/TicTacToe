using System;
using System.Linq;

namespace TicTacToe
{
    public class GameEvaluator
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

        private bool ThereIsADiagonalWin(string[][] cells, string insignia)
        {
            var x = 0;
            var y = 0;
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
                    
            /*
            if (y == 0 && x == 0 && ThereIsADiagonalWin(cells, x, y, insignia))
            {
                outcome = $"{insignia}-Player has {Status.Won}";
                return outcome;
            }*/
                    
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
        
        public string GameOutcome(Board board, string insignia) //for loop (Big O (n= time units) everything*)
        {
            var cells = board.Cells;
            var occurrence = 0;
            var outcome = _inProgress;
            var win = false;
            
            if (ThereIsADiagonalWin(cells, insignia))
            {
                outcome = $"{insignia}-Player has {Status.Won}";
                return outcome;
            }
            
            for (int y = 0; y < cells.Length; y++) // time y = 3 (traditionally it would be y^2, but this is Big O notation is y*x)
            {
                for (int x = 0; x < cells[y].Length; x++) // time x = 3 
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
            /*else if(!stillPlaying && !IsItADraw(cells)){outcome = $"There is a {Status.Forfeit}";}*/
            Console.WriteLine(outcome);
            return outcome;
        }

        /*private bool IsThereAFastWin(string[][] cells,string insignia)
        {
            return (cells[0][0] == insignia && cells[0][1] = insignia && cells[0][2]) && (cells[0][0] == insignia && cells[1][1] == insignia && cells[2][2] == insignia)
            
        }*/
    }
}