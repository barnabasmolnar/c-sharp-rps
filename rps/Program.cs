using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rps
{
    class Program
    {
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

                if (userChoice == "ROCK" && cpuChoice == "PAPER")
                {
                    Console.WriteLine("CPU wins this round.");
                    cpuScore++;
                }
                else if (userChoice == "ROCK" && cpuChoice == "SCISSOR")
                {
                    Console.WriteLine("You win this round.");
                    userScore++;
                }
                else if (userChoice == "PAPER" && cpuChoice == "ROCK")
                {
                    Console.WriteLine("You win this round.");
                    userScore++;
                }
                else if (userChoice == "PAPER" && cpuChoice == "SCISSOR")
                {
                    Console.WriteLine("CPU wins this round.");
                    cpuScore++;
                }
                else if (userChoice == "SCISSOR" && cpuChoice == "ROCK")
                {
                    Console.WriteLine("CPU wins this round.");
                    cpuScore++;
                }
                else if (userChoice == "SCISSOR" && cpuChoice == "PAPER")
                {
                    Console.WriteLine("You win this round.");
                    userScore++;
                }
                else
                {
                    Console.WriteLine("Draw.");
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
