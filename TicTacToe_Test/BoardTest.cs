using System;
using TicTacToe;
using Xunit;

namespace TicTacToe_Test
{
    public class BoardTest
    {
        [Fact]
        public void New_Board_Should_Print_Initial_Board()
        {
            //arrange
            var board = new Board();
            var expectedBoard = $". . . \n. . . \n. . . \n";
            //act
            var actualBoard = board.BoardToString();
            
            //assert
            Assert.Equal(expectedBoard, actualBoard);
        }

        [Fact]
        public void Board_Should_Assign_Picked_Position_Zero_Zero_On_Top_Left_Corner()
        {
            //arrange
            var board = new Board();
            var expectedBoard = $"O . . \n. . . \n. . . \n";
            var input = "0,0";
            var symbol = "O";

            //act
            var actualBoard = board.SetChoice(input, symbol);

            //assert
            Assert.Equal(expectedBoard, actualBoard);

        }
        
    }
}