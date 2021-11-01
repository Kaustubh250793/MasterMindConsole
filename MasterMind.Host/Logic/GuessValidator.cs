using System;
using System.Text;

namespace MasterMind.Host.Logic
{
    /// <summary>
    /// Class to analyze and validate the input guess.
    /// </summary>
    public class GuessValidator
    {
        private readonly string _code;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="code"></param>
        public GuessValidator(string code)
        {
            _code = code;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guess"></param>
        /// <returns></returns>
        public string Validate(string guess)
        {
            var builder = new StringBuilder(guess.Length);

            try
            {
                for (var index = 0; index < guess.Length; index++)
                {
                    var guessSymbol = ' ';
                    var guessAtIndex = guess[index];

                    if (_code.Contains(guessAtIndex.ToString()))
                    {
                        guessSymbol = _code[index] == guessAtIndex ? '+' : '-';
                    }

                    builder.Append(guessSymbol);
                }
            }
            catch (Exception)
            {
                builder.Clear();
                builder.Append("Invalid input");
            }

            return builder.ToString();
        }
    }
}