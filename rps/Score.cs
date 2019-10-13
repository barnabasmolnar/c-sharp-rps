namespace rps
{
    using static Outcome;

    class Score
    {
        private static int userScore = 0;
        private static int cpuScore = 0;

        public static void UpdateScore(Outcome outcome)
        {
            if (outcome == USERWIN)
            {
                userScore++;
            }
            else if (outcome == CPUWIN)
            {
                cpuScore++;
            }
        }

        public static string ReturnScore() => $"User score: {userScore}\nCPU score: {cpuScore}";
    }
}
