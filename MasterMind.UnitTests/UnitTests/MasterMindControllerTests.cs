using MasterMind.Host;
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
            var state = new PlayGame("0000");
            for (var count = 0; count < 9; count++)
            {
                state.GuessInput("1111");
            }

            var actual = state.GuessInput("1111");

            Assert.That(actual.Contains("Sorry! you lose."));
        }

        //  At end of game, display message indicating whether they won or lost
        [Test]
        public void AnalyzeGuess_EndsGame_IfAllDigitsAreCorrect()
        {
            var game = new PlayGame("1234");

            var actual = game.GuessInput("1234");

            Assert.That(actual.Contains("Congratulations, you won!"));
        }
    }
}
