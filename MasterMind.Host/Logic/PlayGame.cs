using System;
using System.Text;

namespace MasterMind.Host.Logic
{
    /// <summary>
    /// 
    /// </summary>
    public class PlayGame
    {
        private string _code;
        private Random _randomNumberGenerator = new Random();

        private GuessValidator _guessValidator;

        private const int _maxNoOfguess = 10;
        private const int _codeLength = 4;
        private const int _minRandomNoValue = 1;
        private const int _maxRandomNoValue = 6;

        /// <summary>
        /// 
        /// </summary>
        public bool IsFinished { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public PlayGame()
        {
            _code = GenerateRandomCode(_codeLength);
            _guessValidator = new GuessValidator(_code);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeMakerGuess"></param>
        public PlayGame(string codeMakerGuess)
        {
            _code = codeMakerGuess;
            _guessValidator = new GuessValidator(_code);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guess"></param>
        public string GuessInput(string guess)
        {
            var response = _guessValidator.Validate(guess);

            if (response.NumberOfAttempts == _maxNoOfguess)
            {
                IsFinished = true;
                return $"Sorry, you lose. Better luck next time!!";
            }
            if (response.IndicativeString == "++++")
            {
                IsFinished = true;
                return $"Congratulations! You won the game in {response.NumberOfAttempts} attempts.";
            }

            return $"{response.IndicativeString}\t Remaining guesses: {_maxNoOfguess - response.NumberOfAttempts}\n";
        }

        private string GenerateRandomCode(int length)
        {
            var stringBuilder = new StringBuilder(length);
            for (var i = 0; i < length; i++)
            {
                stringBuilder.Append(_randomNumberGenerator.Next(_minRandomNoValue, _maxRandomNoValue));
            }

            return stringBuilder.ToString();
        }
    }
}
