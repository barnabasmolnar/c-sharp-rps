using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rps
{
    using static Choice;
    using static Outcome;

    enum Choice { ROCK, PAPER, SCISSORS }
    enum Outcome { USERWIN, CPUWIN, DRAW }

    class Program
    {
        static Outcome DetermineOutcome(Choice userChoice, Choice cpuChoice)
        {
            if (userChoice == cpuChoice)
            {
                return DRAW;
            }

            if (userChoice == ROCK && cpuChoice == SCISSORS || userChoice == PAPER && cpuChoice == ROCK || userChoice == SCISSORS && cpuChoice == PAPER)
            {
                return USERWIN;
            }

            return CPUWIN;
        }

        static string DisplayOutcome(Outcome outcome)
        {
            switch (outcome)
            {
                case USERWIN:
                    return "You win this round.";
                case CPUWIN:
                    return "CPU wins this round.";
                default:
                    return "Draw.";
            }
        }

        static bool KeepPlaying()
        {
            Console.Write("New game? y/n ");
            ConsoleKeyInfo cki = Console.ReadKey(); // wait for player to press a key
            Console.WriteLine("\n------");
            return cki.KeyChar == 'y'; // continue only if y was pressed
        }

        static void Main()
        {
            Console.WriteLine("Let's play a game of Rock Paper Scissors.");

            do
            {
                Choice userChoice = HumanPlayer.GetChoice();

                Choice cpuChoice = CPUPlayer.PickRandom();
                Console.WriteLine("CPU:" + cpuChoice);

                Outcome outcome = DetermineOutcome(userChoice, cpuChoice);
                Console.WriteLine(DisplayOutcome(outcome));

                Score.UpdateScore(outcome);

            } while (KeepPlaying());

            Console.WriteLine(Score.ReturnScore());
        }
    }
}
