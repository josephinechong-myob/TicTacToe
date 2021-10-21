using System.Linq;

namespace TicTacToe
{
    public class GameEvaluator
    {
        private readonly string _inProgress = $"Game is {Status.Ongoing}";
        
        public GameOutcome FindGameOutcome(Board board, string insignia)
        {
            var cells = board.Cells;
            Insignia insig;

            if (ThereIsAWin(cells, insignia) && Insignia.TryParse(insignia, out insig))
            {
                return GameOutcome.WithWinner(insig);
            }
            
            if (ThereIsADraw(cells))
            {
                return GameOutcome.Draw();
            }
            
            return GameOutcome.Ongoing();  
           
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

        private bool ThereIsAHorizontalWin(string[][] cells, string insignia)
        {
            for (int y = 0; y < cells.Length; y++)
            {
                if (cells[y][0] == cells[y][1] && cells[y][1] == cells[y][2] && cells[y][0] == insignia)
                {
                    return true;
                }
            }
            return false;
        }

        private bool ThereIsAVerticalWin(string[][] cells, string insignia)
        {
            for (int x = 0; x < cells.Length; x++) 
            {
                if (cells[0][x] == cells[1][x] && cells[1][x] == cells[2][x] && cells[0][x] == insignia)
                {
                    return true;
                }
            }
            return false;
        }

        private bool ThereIsAWin(string[][] cells, string insignia)
        {
            return ThereIsADiagonalWin(cells, insignia) || ThereIsAHorizontalWin(cells, insignia) ||
                    ThereIsAVerticalWin(cells, insignia);
        }
        
        private bool ThereIsADraw(string[][] cells)
        {
            return !cells.Any(s => s.Contains("."));
        }
    }
}