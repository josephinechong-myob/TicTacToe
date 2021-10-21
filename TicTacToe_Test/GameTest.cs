using TicTacToe;
using Xunit;
using Moq;

namespace TicTacToe_Test
{
    public class GameTest
    {
        [Fact]
        public void PlayerX_Should_Be_Able_To_Play_Again_After_Game_Finishes()
        {
            //assign
            var mockConsole = new Mock<IConsole>();
            var playerXFirstPosition = "1,1";
            var playerXSecondPosition = "1,2";
            var playerXThirdPosition = "1,3";
            var playerOFirstPosition = "2,1";
            var playerOSecondPosition = "3,2";
            var playerOThirdPosition = "1";
            var playerOFourthPosition = "1,1";
            var playerXFourthPosition = "q";

            mockConsole.SetupSequence(m => m.ReadLine())
                .Returns(playerXFirstPosition)
                .Returns(playerOFirstPosition)
                .Returns(playerXSecondPosition)
                .Returns(playerOSecondPosition)
                .Returns(playerXThirdPosition)
                .Returns(playerOThirdPosition)
                .Returns(playerOFourthPosition)
                .Returns(playerXFourthPosition);
            
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
            mockConsole.Verify(
                m=>m.WriteLine(
                    It.Is<string>(s=>s==$"Do you want to play again?")
                ), Times.Once
            );
            mockConsole.Verify(
                m=>m.WriteLine(
                    It.Is<string>(s=>s==$"Player 2 has forfeit")
                ), Times.Once
            );
        }
        
        [Fact]
        public void PlayerX_Should_Win_If_Winning_Pattern_Achieved()
        {
            //assign
            var mockConsole = new Mock<IConsole>();
            var playerXFirstPosition = "1,1";
            var playerXSecondPosition = "1,2";
            var playerXThirdPosition = "1,3";
            var playerXFourthPosition = "0";
            var playerOFirstPosition = "2,1";
            var playerOSecondPosition = "3,2";
            var playerOThirdPosition = "3,3";

            mockConsole.SetupSequence(m => m.ReadLine())
                .Returns(playerXFirstPosition)
                .Returns(playerOFirstPosition)
                .Returns(playerXSecondPosition)
                .Returns(playerOSecondPosition)
                .Returns(playerXThirdPosition)
                .Returns(playerOThirdPosition)
                .Returns(playerXFourthPosition);

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

        [Fact]
        public void Player_Should_Encounter_Prompt_When_Entering_Existing_Coordinate()
        {
            //assign
            var mockConsole = new Mock<IConsole>();
            var playerXFirstPosition = "1,1";
            var playerOFirstPosition = "1,1";
            
            mockConsole.SetupSequence(m => m.ReadLine())
                .Returns(playerXFirstPosition)
                .Returns(playerOFirstPosition)
                .Returns("q");

            var board = new Board(mockConsole.Object);
            var game = new Game(mockConsole.Object, board);
            
            //act
            game.Run();
            
            //assert
            mockConsole.Verify(
                m => m.WriteLine(
                    It.Is<string>(s => s == $"This position 1,1 is already occupied")
                ), Times.Once
            );
        }
        
        [Fact]
        public void Player_Should_Encounter_Input_Format_Prompt_When_Entering_Invalid_Input()
        {
            //assign
            var mockConsole = new Mock<IConsole>();
            var playerXFirstPosition = "a,a";

            mockConsole.SetupSequence(m => m.ReadLine())
                .Returns(playerXFirstPosition)
                .Returns("q");

            var board = new Board(mockConsole.Object);
            var game = new Game(mockConsole.Object, board);
            
            //act
            game.Run();
            
            //assert
            mockConsole.Verify(
                m => m.WriteLine(
                    It.Is<string>(s => s == $"Please enter a coord with the format x,y. With x and y being a single digit")
                ), Times.Once
            );
        }
    }
}