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
            var playerXFirstPosition = "0,0";
            var playerXSecondPosition = "0,1";
            var playerXThirdPosition = "0,2";
            var playerOFirstPosition = "1,0";
            var playerOSecondPosition = "2,1";
            var playerOThirdPosition = "2,2";

            mockConsole.SetupSequence(m => m.ReadLine())
                .Returns(playerXFirstPosition)
                .Returns(playerOFirstPosition)
                .Returns(playerXSecondPosition)
                .Returns(playerOSecondPosition)
                .Returns(playerXThirdPosition)
                .Returns(playerOThirdPosition);

            var game = new Game(mockConsole.Object);
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

            var game = new Game(mockConsole.Object);
            //act
            game.Run();
            
            //assert
            mockConsole.Verify(
                m=>m.WriteLine(
                    It.Is<string>(s=>s==$"Player X has forfeit")
                ), Times.Once
            );
        }
    }
}