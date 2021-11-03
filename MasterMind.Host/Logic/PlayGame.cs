using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterMind.Host.Logic
{
    /// <summary>
    /// This class generates the message to be displayed on basis of response from validator.
    /// </summary>
    public class PlayGame
    {
        private string _code;
        private static Random _randomNumberGenerator = new Random();

        private GuessValidator _guessValidator;
        private int _attempts;
        private const int _maxNoOfguess = 10;
        private const int _codeLength = 4;
        private const int _minRandomNoValue = 1;
        private const int _maxRandomNoValue = 6;

        /// <summary>
        /// Is game finished
        /// </summary>
        public bool IsFinished { get; internal set; }

        /// <summary>
        /// .ctor
        /// </summary>
        public PlayGame() : this(GenerateRandomCode()) { }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="codeMakerGuess"></param>
        public PlayGame(string codeMakerGuess)
        {
            _code = codeMakerGuess;
            _guessValidator = new GuessValidator(_code);
        }

        /// <summary>
        /// Takes the guess as input and return the output response string
        /// </summary>
        /// <param name="guess"></param>
        public string GuessInput(string guess)
        {
            var response = _guessValidator.Validate(guess);

            if (++_attempts == _maxNoOfguess)
            {
                IsFinished = true;
                return $"Sorry, you lose. Better luck next time!!";
            }
            if (response == "++++")
            {
                IsFinished = true;
                return $"\nCongratulations! You won the game in {_attempts} attempts.";
            }

            var s = new String(response.OrderByDescending(x => x).ToArray());

            return $"{s}\t Remaining guesses: {_maxNoOfguess - _attempts}\n";
        }

        private static string GenerateRandomCode()
        {
            var stringBuilder = new StringBuilder(_codeLength);
            for (var i = 0; i < _codeLength; i++)
            {
                var str = _randomNumberGenerator.Next(_minRandomNoValue, _maxRandomNoValue);

                HashSet<int> a = new HashSet<int>();

                while (a.Contains(str))
                {
                    str = _randomNumberGenerator.Next(_minRandomNoValue, _maxRandomNoValue);
                }
                stringBuilder.Append(_randomNumberGenerator.Next(_minRandomNoValue, _maxRandomNoValue));
            }

            return stringBuilder.ToString();
        }
    }
}
