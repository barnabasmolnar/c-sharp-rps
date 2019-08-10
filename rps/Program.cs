using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rps
{
    enum Choice { ROCK, PAPER, SCISSORS };

    class Program
    {
        static string DetermineWinner(Choice userChoice, Choice cpuChoice)
        {
            if (userChoice == cpuChoice)
            {
                return "Draw.";
            }

            if (userChoice == Choice.ROCK && cpuChoice == Choice.SCISSORS || userChoice == Choice.PAPER && cpuChoice == Choice.ROCK || userChoice == Choice.SCISSORS && cpuChoice == Choice.PAPER)
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

            var choices = Enum.GetValues(typeof(Choice));

            Console.WriteLine("Let's play a game of Rock Paper Scissors.");

            Random rnd = new Random();


            while (keepPlaying)
            {

                int n = rnd.Next(choices.Length);


                Choice userChoice;
                string userChoiceStr;

                do
                {
                    Console.WriteLine("Choose a valid play.");
                    userChoiceStr = Console.ReadLine();
                } while (!Enum.TryParse<Choice>(userChoiceStr, true, out userChoice));

                Choice cpuChoice = (Choice)choices.GetValue(n);
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
