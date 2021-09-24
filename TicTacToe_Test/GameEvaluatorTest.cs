using TicTacToe;
using Xunit;

namespace TicTacToe_Test
{
    public class GameEvaluatorTest
    {
        [Fact]
        public void Winner_Should_Be_Printed_If_Winning_Combinations_Reached()
        {
            //assign
            var cells = new string[][]
            {
                new []{"X", "X", "X"},
                new []{".", ".", "."},
                new []{".", ".", "."}
            };
            var board = new Board(cells);
            var evaluator = new GameEvaluator();
            var expectedOutcome = "X-Player wins";

            //act
            var actualOutcome = evaluator.GameOutcome(board);

            //assert
            Assert.Equal(expectedOutcome, actualOutcome);

        }
        
        [Fact]
        public void In_Progress_Should_Be_Printed_If_No_Winning_Combinations()
        {
            //assign
            var board = new Board();
            var evaluator = new GameEvaluator();
            var expectedOutcome = "In progress";

            //act
            var actualOutcome = evaluator.GameOutcome(board);

            //assert
            Assert.Equal(expectedOutcome, actualOutcome);

        }
    }
}