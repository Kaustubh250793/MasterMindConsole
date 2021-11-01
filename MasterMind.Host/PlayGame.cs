namespace MasterMind.Host
{
    /// <summary>
    /// 
    /// </summary>
    public class PlayGame
    {
        /// <summary>
        /// 
        /// </summary>
        public PlayGame()
        {

        }

        private string Code { get; }

        public PlayGame(string codeMakerGuess)
        {
            Code = codeMakerGuess;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guess"></param>
        public string GuessInput(string guess)
        {
            return string.Empty;
        }
    }
}
