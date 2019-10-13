using System;

namespace rps
{
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
}
