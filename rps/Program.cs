using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rps
{
    enum Choice { ROCK, PAPER, SCISSORS }

    enum Outcome { USERWIN, CPUWIN, DRAW }

    class CPUPlayer
    {
        private static readonly Array choices = Enum.GetValues(typeof(Choice));
        private static readonly Random rnd = new Random();

        public static Choice PickRandom()
        {
            int n = rnd.Next(choices.Length);
            return (Choice)choices.GetValue(n);
        }
    }

    class HumanPlayer
    {
        public static Choice GetChoice()
        {
            Choice userChoice;
            string userChoiceStr;

            do
            {
                Console.WriteLine("Choose a valid play.");
                userChoiceStr = Console.ReadLine();
            } while (!Enum.TryParse<Choice>(userChoiceStr, true, out userChoice));

            return userChoice;
        }
    }

    class Score
    {
        private static int userScore = 0;
        private static int cpuScore = 0;

        public static void UpdateScore(Outcome outcome)
        {
            if (outcome == Outcome.USERWIN)
            {
                userScore++;
            }
            else if (outcome == Outcome.CPUWIN)
            {
                cpuScore++;
            }
        }

        public static string ReturnScore() => $"User score: {userScore}\nCPU score: {cpuScore}";
    }

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

                Outcome winner = DetermineOutcome(userChoice, cpuChoice);
                Console.WriteLine(DisplayOutcome(winner));

                Score.UpdateScore(winner);

            } while (KeepPlaying());

            Console.WriteLine(Score.ReturnScore());           
        }
    }
}
