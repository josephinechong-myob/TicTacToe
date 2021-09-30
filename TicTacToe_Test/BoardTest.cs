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
        
        [Fact] //Reset - to do
        public void ResetBoard_Should_Be_Empty()
        {
            //arrange
            var board = new Board();
            var expectedBoard = $"X . . \n. . . \n. . . \n";
            var input = "0,0";
            var symbol = "O";

            //act
            var actualBoard = board.SetChoice(input, symbol);

            //assert
            Assert.Equal(expectedBoard, actualBoard);

        }
        
        /*[Fact] //Board status
        public void BoardStatus_Should_Print_Current_Board_New_Board()
        {
            //arrange
            var board = new Board();
            var expectedTextOutput = "Here's the current board:";

            //act
            var actualBoard = board.BoardStatus();

            //assert
            Assert.Equal(expectedTextOutput, actualBoard);

        }
        
        [Fact] //Board status
        public void BoardStatus_Should_Print_Current_Board()
        {
            //arrange
            var board = new Board();
            var expectedBoard = $"O . . \n. . . \n. . . \n";
            var input = "0,0";
            var symbol = "O";
            var expectedTextOutput = "Move accepted, here's the current board:";

            //act
            board.SetChoice(input, symbol);
            var actualBoard = board.BoardStatus();

            //assert
            //Assert.Equal(expectedBoard, actualBoard);
            Assert.Equal(expectedTextOutput, actualBoard);

        }
        
        [Fact] //Board status
        public void BoardStatus_Should_Print_Current_Board_X()
        {
            //arrange
            var board = new Board();
            var expectedBoard = $"X . . \n. . . \n. . . \n";
            var input = "0,0";
            var symbol = "X";
            var expectedTextOutput = "Move accepted, here's the current board:";

            //act
            board.SetChoice(input, symbol);
            var actualBoard = board.BoardStatus();

            //assert
            Assert.Equal(expectedTextOutput, actualBoard);

        }*/

        
    }
}