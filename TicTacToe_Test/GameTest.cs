using TicTacToe;
using Xunit;
using Moq;

namespace TicTacToe_Test
{
    public class GameTest
    {
        [Fact]
        public void PlayerX_Should_Win_If_Winning_Pattern_Achieved()
        {
            //assign
            var mockConsole = new Mock<IConsole>();
            var playerXFirstPosition = "1,1";
            var playerXSecondPosition = "1,2";
            var playerXThirdPosition = "1,3";
            var playerOFirstPosition = "2,1";
            var playerOSecondPosition = "3,2";
            var playerOThirdPosition = "3,3";

            mockConsole.SetupSequence(m => m.ReadLine())
                .Returns(playerXFirstPosition)
                .Returns(playerOFirstPosition)
                .Returns(playerXSecondPosition)
                .Returns(playerOSecondPosition)
                .Returns(playerXThirdPosition)
                .Returns(playerOThirdPosition);

            var board = new Board(mockConsole.Object);
            var game = new Game(mockConsole.Object, board);
            //act
            game.Run();
            
            //assert
            mockConsole.Verify(
                m=>m.WriteLine(
                    It.Is<string>(s=>s==$"X-Player has won")
                ), Times.Once
            );
        }
        
        [Fact]
        public void Game_Should_End_If_Player_Enters_Q()
        {
            //assign
            var mockConsole = new Mock<IConsole>();
            var playerX = "q";

            mockConsole.SetupSequence(m => m.ReadLine())
                .Returns(playerX);

            var board = new Board(mockConsole.Object);
            var game = new Game(mockConsole.Object, board);
            //act
            game.Run();
            
            //assert
            mockConsole.Verify(
                m=>m.WriteLine(
                    It.Is<string>(s=>s==$"Player 1 has forfeit")
                ), Times.Once
            );
        }
    }
}