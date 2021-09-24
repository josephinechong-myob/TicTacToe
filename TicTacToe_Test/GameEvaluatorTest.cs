using TicTacToe;
using Xunit;

namespace TicTacToe_Test
{
    public class GameEvaluatorTest
    {
        [Fact]
        public void Winner_Should_Be_Printed_If_Winning_Combinations_Reached_case2()
        {
            //assign
            var cells = new string[][]
            {
                new []{"X", ".", "."},
                new []{".", "X", "."},
                new []{"X", ".", "."}
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
        public void Winner_Should_Be_Printed_If_Winning_Combinations_Reached()
        {
            //assign
            var cells = new string[][]
            {
                new []{".", ".", "."},
                new []{".", ".", "."},
                new []{"X", "X", "X"}
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