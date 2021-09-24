using System;
using System.Collections;
using System.Collections.Generic;
using TicTacToe;
using Xunit;

namespace TicTacToe_Test
{
    public class GameEvaluatorTest
    {
        [Theory]
        [InlineData(new[]{"X", ".", "."}, new[]{"X", ".", "."}, new[]{"X", ".", "."})]
        [InlineData(new[]{".", "X", "."}, new[]{".", "X", "."}, new[]{".", "X", "."})]
        [InlineData(new[]{".", ".", "X"}, new[]{".", ".", "X"}, new[]{".", ".", "X"})]
        [InlineData(new[]{"X", "X", "X"}, new[]{".", ".", "."}, new[]{".", ".", "."})]
        [InlineData(new[]{".", ".", "."}, new[]{"X", "X", "X"}, new[]{".", ".", "."})]
        [InlineData(new[]{".", ".", "."}, new[]{".", ".", "."}, new[]{"X", "X", "X"})]
        public void Winner_Should_Be_Printed_If_Winning_Combinations_Reached(params string[][] cells)
        {
            //assign
            
            var board = new Board(cells);
            var evaluator = new GameEvaluator();
            var expectedOutcome = "X-Player wins";

            //act
            var actualOutcome = evaluator.GameOutcome(board);

            //assert
            Assert.Equal(expectedOutcome, actualOutcome);
        }
        
        [Theory]
        [InlineData(new[]{"X", ".", "X"}, new[]{".", ".", "."}, new[]{"X", ".", "."})]
        [InlineData(new[]{".", "X", "X"}, new[]{".", "X", "."}, new[]{".", ".", "."})]
        [InlineData(new[]{".", ".", "X"}, new[]{".", ".", "."}, new[]{".", "X", "X"})]
        [InlineData(new[]{"X", "X", "."}, new[]{".", ".", "."}, new[]{".", ".", "."})]
        [InlineData(new[]{".", ".", "."}, new[]{"X", ".", "X"}, new[]{".", ".", "."})]
        [InlineData(new[]{".", ".", "."}, new[]{".", ".", "."}, new[]{"X", ".", "X"})]
        public void In_Progress_Should_Be_Printed_If_No_Winning_Combinations_And_Empty_Cells_Still_Present(params string[][] cells)
        {
            //assign
            var board = new Board(cells);
            var evaluator = new GameEvaluator();
            var expectedOutcome = "";

            //act
            var actualOutcome = evaluator.GameOutcome(board);

            //assert
            Assert.Equal(expectedOutcome, actualOutcome);
        }
        
        [Fact]
        public void Draw_Should_Be_Printed_If_No_Winning_Combinations()
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