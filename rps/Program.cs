using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rps
{
    enum Choice { ROCK, PAPER, SCISSORS }

    enum Outcome { USERWIN, CPUWIN, DRAW }

    class Program
    {
        static Outcome DetermineOutcome(Choice userChoice, Choice cpuChoice)
        {
            if (userChoice == cpuChoice)
            {
                return Outcome.DRAW;
            }

            if (userChoice == Choice.ROCK && cpuChoice == Choice.SCISSORS || userChoice == Choice.PAPER && cpuChoice == Choice.ROCK || userChoice == Choice.SCISSORS && cpuChoice == Choice.PAPER)
            {
                return Outcome.USERWIN;
            }

            return Outcome.CPUWIN;
        }

        static string DisplayOutcome(Outcome outcome)
        {
            switch (outcome)
            {
                case Outcome.USERWIN:
                    return "You win this round.";
                case Outcome.CPUWIN:
                    return "CPU wins this round.";
                default:
                    return "Draw.";
            }
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

                Outcome winner = DetermineOutcome(userChoice, cpuChoice);
                Console.WriteLine(DisplayOutcome(winner));

                if (winner == Outcome.USERWIN)
                {
                    userScore++;
                }
                else if (winner == Outcome.CPUWIN)
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
