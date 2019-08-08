using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rps
{
    class Program
    {
        static string DetermineWinner(string userChoice, string cpuChoice)
        {
            if (userChoice == cpuChoice)
            {
                return "Draw.";
            }

            if (userChoice == "ROCK" && cpuChoice == "SCISSOR" || userChoice == "PAPER" && cpuChoice == "ROCK" || userChoice == "SCISSOR" && cpuChoice == "PAPER")
            {
                return "You win this round.";
            }

            return "CPU wins this round.";

        }

        static void Main()
        {
            bool keepPlaying = true;

            int userScore = 0;
            int cpuScore = 0;

            string[] choices = { "ROCK", "PAPER", "SCISSOR" };

            Console.WriteLine("Let's play a game of Rock Paper Scissors.");

            Random rnd = new Random();

            while (keepPlaying)
            {
                int n = rnd.Next(choices.Length);


                string userChoice;

                do
                {
                    Console.WriteLine("Choose a valid play.");
                    userChoice = Console.ReadLine().ToUpper();
                } while (Array.IndexOf(choices, userChoice) == -1);

                string cpuChoice = choices[n];
                Console.WriteLine("CPU:" + cpuChoice);

                string winner = DetermineWinner(userChoice, cpuChoice);
                Console.WriteLine(winner);

                if (winner == "You win this round.")
                {
                    userScore++;
                }
                else if (winner == "CPU wins this round.")
                {
                    cpuScore++;
                }

                Console.Write("New game? y/n ");
                ConsoleKeyInfo cki = Console.ReadKey(); // wait for player to press a key
                Console.WriteLine("\n------");
                keepPlaying = cki.KeyChar == 'y'; // continue only if y was pressed

                if (!keepPlaying)
                {
                    Console.WriteLine($"User score: {userScore}");
                    Console.WriteLine($"CPU score: {cpuScore}");
                }
            }
        }
    }
}
