using System;

namespace rps
{
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
}
