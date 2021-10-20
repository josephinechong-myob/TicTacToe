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
        //[ClassData(typeof(PossibleBoardOutcomes))]
        [InlineData(new[]{"X", ".", "."}, new[]{"X", ".", "."}, new[]{"X", ".", "."})]
        [InlineData(new[]{".", "X", "."}, new[]{".", "X", "."}, new[]{".", "X", "."})]
        [InlineData(new[]{".", ".", "X"}, new[]{".", ".", "X"}, new[]{".", ".", "X"})]
        [InlineData(new[]{"X", "X", "X"}, new[]{".", ".", "."}, new[]{".", ".", "."})]
        [InlineData(new[]{".", ".", "."}, new[]{"X", "X", "X"}, new[]{".", ".", "."})]
        [InlineData(new[]{".", ".", "."}, new[]{".", ".", "."}, new[]{"X", "X", "X"})]
        [InlineData(new[]{"X", ".", "."}, new[]{".", "X", "."}, new[]{".", ".", "X"})]
        [InlineData(new[]{".", ".", "X"}, new[]{".", "X", "."}, new[]{"X", ".", "."})]
        public void Winner_Should_Be_Printed_If_Winning_Combinations_Reached(params string[][] cells)
        {
            //assign
            var console = new GameConsole();
            var board = new Board(cells, console);
            var insignia = "X";
            var evaluator = new GameEvaluator();
            var expectedOutcome = GameOutcome.WithWinner(Insignia.X);

            //act
            var actualOutcome = evaluator.FindGameOutcome(board,insignia);

            //assert
           Assert.Equal(expectedOutcome.ToString(), actualOutcome.ToString());
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
            var console = new GameConsole();
            var board = new Board(cells, console);
            var insignia = "X";
            var evaluator = new GameEvaluator();
            var expectedOutcome = GameOutcome.Ongoing();

            //act
            var actualOutcome = evaluator.FindGameOutcome(board, insignia);

            //assert
            Assert.Equal(expectedOutcome.ToString(), actualOutcome.ToString());
        }
        
        [Theory]
        [InlineData(
            new[]{"X", "O", "X"}, 
            new[]{"O", "O", "X"}, 
            new[]{"X", "X", "O"})]
        [InlineData(
            new[]{"X", "O", "X"}, 
            new[]{"X", "X", "O"}, 
            new[]{"O", "X", "O"})]
        
        public void Draw_Should_Be_Printed_If_No_Winning_Combinations_And_All_Cells_Filled(params string[][] cells)
        {
            //assign
            var console = new GameConsole();
            var board = new Board(cells, console);
            var insignia = "X";
            var evaluator = new GameEvaluator();
            var expectedOutcome = GameOutcome.Draw();

            //act
            var actualOutcome = evaluator.FindGameOutcome(board, insignia);

            //assert
            Assert.Equal(expectedOutcome.ToString(), actualOutcome.ToString());
        }
        
        private class PossibleBoardOutcomes : IEnumerable<object[]> //classData Enumerator
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {new[] {"X", ".", "."}, new[] {"X", ".", "."}, new[] {"X", ".", "."}};
                yield return new object[] {new[] {"X", "X", "X"}, new[] {".", ".", "."}, new[] {".", ".", "."}};
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}