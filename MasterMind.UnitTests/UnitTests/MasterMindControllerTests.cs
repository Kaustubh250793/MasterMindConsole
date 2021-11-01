using MasterMind.Host.Logic;
using NUnit.Framework;

namespace MasterMind.UnitTests.UnitTests
{
    public class MasterMindControllerTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        //  After 10 incorrect guesses, the player loses
        [Test]
        public void GuessCounter_EndsGameAfterTenIncorrectGuesses()
        {
            // Arrange
            var game = new PlayGame("0000");
            for (var count = 0; count < 9; count++)
            {
                game.GuessInput("1111");
            }

            // Act
            var actual = game.GuessInput("1111");

            // Assert
            Assert.That(actual.StartsWith("Sorry, you lose."));
            Assert.That(game.IsFinished);
        }

        //  At end of game, display message indicating whether they won or lost
        [Test]
        public void ValidateGuess_EndsGame_IfAllDigitsAreCorrect()
        {
            // Arrange
            var game = new PlayGame("1234");

            // Act
            var actual = game.GuessInput("1234");

            // Assert
            Assert.That(actual.StartsWith("Congratulations! You won"));
            Assert.That(game.IsFinished);
        }

        //  If the input text was out of bounds integer, message is displayed
        [Test]
        public void ValidateGuess_ShowsErrorMessage_IfInputIsIncorrectInteger()
        {
            // Arrange
            var game = new PlayGame("1234");

            // Act
            var actual = game.GuessInput("65666565323338");

            // Assert
            Assert.That(actual.StartsWith("Invalid input"));
            Assert.That(!game.IsFinished);
        }
    }
}
