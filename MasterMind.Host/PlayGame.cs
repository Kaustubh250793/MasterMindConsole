using System;
using System.Text;

namespace MasterMind.Host
{
    /// <summary>
    /// 
    /// </summary>
    public class PlayGame
    {
        private string _code;
        private GuessValidator _guessValidator;

        private Random _randomNumberGenerator = new Random();

        /// <summary>
        /// 
        /// </summary>
        public bool IsFinished { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public PlayGame()
        {
            _code = GenerateRandomCode(4);
            _guessValidator = new GuessValidator(_code);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeMakerGuess"></param>
        public PlayGame(string codeMakerGuess)
        {
            _code = codeMakerGuess;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guess"></param>
        public string GuessInput(string guess)
        {
            var response = _guessValidator.Validate(guess);

            if (response.NumberOfAttempts == 10)
            {
                Console.WriteLine($"Sorry, you lose. Better luck next time!!");

                IsFinished = true;
            }
            if (response.IndicativeString == "++++")
            {
                Console.Write("\n");
                Console.WriteLine($"Congratulations! You won the game in {response.NumberOfAttempts} attempts.");

                IsFinished = true;
            }
            else
            {
                Console.WriteLine($"{response.IndicativeString}\n");
            }

            return string.Empty;
        }

        private string GenerateRandomCode(int length)
        {
            var stringBuilder = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                stringBuilder.Append(_randomNumberGenerator.Next(1, 6));
            }

            return stringBuilder.ToString();
        }
    }
}
