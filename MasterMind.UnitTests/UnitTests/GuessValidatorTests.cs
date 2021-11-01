using MasterMind.Host.Logic;
using NUnit.Framework;

namespace MasterMind.UnitTests.UnitTests
{
    public class GuessValidatorTests
    {
        //  Display "-" for each digit that is correct but in wrong position
        //  Display "+" for each digit that is correct and in correct position
        //  Display " " for each incorrect digit
        [Test]
        [TestCase("1234", "0000", "    ")]
        [TestCase("1234", "1000", "+   ")]
        [TestCase("1234", "0100", " -  ")]
        [TestCase("1234", "0010", "  - ")]
        [TestCase("1234", "0001", "   -")]
        [TestCase("1234", "1200", "++  ")]
        [TestCase("1234", "2100", "--  ")]
        [TestCase("1234", "0120", " -- ")]
        [TestCase("1234", "0012", "  --")]
        [TestCase("1234", "1230", "+++ ")]
        [TestCase("1234", "3210", "-+- ")]
        [TestCase("1234", "0123", " ---")]
        [TestCase("1234", "3012", "- --")]
        [TestCase("1234", "1234", "++++")]
        public void AnalyzeGuess_ComposesResponseToGuess(string code, string guess, string expected)
        {
            // Arrange
            var validator = new GuessValidator(code);

            // Act
            var actual = validator.Validate(guess);

            // Assert
            Assert.That(actual.Equals(expected));
        }
    }
}
