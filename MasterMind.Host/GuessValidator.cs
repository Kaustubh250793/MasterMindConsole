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
            var sb = new StringBuilder();

            for (int i = 0; i < _code.Length; i++)
            {
                if (!_code.Contains(guess[i].ToString()))
                {
                    sb.Append(' ');
                }
                else
                {
                    if (_code[i] == guess[i])
                    {
                        sb.Append('+');
                    }
                    else
                    {
                        sb.Append('-');
                    }
                }
            }

            return new GuessResponse()
            {
                IndicativeString = sb.ToString(),
                NumberOfAttempts = ++_attempts
            };
        }
    }
}