using System.Text;

namespace MasterMind.Host
{
    /// <summary>
    /// 
    /// </summary>
    public class GuessValidator
    {
        private readonly string _code;
        private int _attempts = 0;

        /// <summary>
        /// 
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
        public GuessResponse Validate(string guess)
        {
            var builder = new StringBuilder(guess.Length);
            var str = ' ';

            for (int index = 0; index < _code.Length; index++)
            {
                var guessAtIndex = guess[index];

                if (_code.Contains(guessAtIndex.ToString()))
                {
                    str += _code[index] == guessAtIndex ? '+' : '-';
                }

                builder.Append(str);
            }

            return new GuessResponse()
            {
                IndicativeString = builder.ToString(),
                NumberOfAttempts = ++_attempts
            };
        }
    }
}