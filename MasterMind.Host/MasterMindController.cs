using System;
using MasterMind.Host.Logic;

namespace MasterMind.Host
{
    public class MasterMindController
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(1252);

            Console.WriteLine("Welcome to MASTER MIND, my fellow code breaker!");

            Console.WriteLine("\nI have generated a random code:\n");
            Console.WriteLine(" \u2022 Each digit falls between 1 and 6, inclusive.");
            Console.WriteLine(" \u2022 There are only 4 digits.\n");
            Console.WriteLine("You have up to 10 tries to guess my secret code.");
            Console.WriteLine("\nAfter each guess, I will give you a 4-digit response:\n");
            Console.WriteLine(" \u2022 A '+' character means your guess was correct in that position.");
            Console.WriteLine(" \u2022 A '-' character means that digit is in the code, but not in that position.");
            Console.WriteLine(" \u2022 A ' ' means that digit is not in the code at all.");
            Console.WriteLine("\nPlease enter your first guess now:\n");

            var playGame = new PlayGame();

            while (!playGame.IsFinished)
            {
                var guess = Console.ReadLine();

                var output = playGame.GuessInput(guess);

                Console.WriteLine($"{output}");
            }

            Console.ReadKey();
        }
    }
}
