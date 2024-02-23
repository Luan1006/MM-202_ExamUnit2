using static Constants;

namespace TaskRepository
{
    public class Roman
    {
        private static Dictionary<char, int> RomanNumber = new Dictionary<char, int>()
        {
            {Text.CharRomanOne, 1},
            {Text.CharRomanFive, 5},
            {Text.CharRomanTen, 10},
            {Text.CharRomanFifty, 50},
            {Text.CharRomanHundred, 100},
        };

        public static string Run(Task task)
        {
            string answer = RomanToInteger(task.parameters).ToString();

            Print.PrintTaskDetails(Text.TaskThree, task, answer);

            return answer;
        }

        public static int RomanToInteger(string roman)
        {
            int number = 0;
            for (int i = 0; i < roman.Length; i++)
            {
                if (!RomanNumber.ContainsKey(roman[i]))
                {
                    return 0;
                }

                if (i + 1 < roman.Length && RomanNumber[roman[i]] < RomanNumber[roman[i + 1]])
                {
                    number -= RomanNumber[roman[i]];
                }
                else
                {
                    number += RomanNumber[roman[i]];
                }
            }
            return number;
        }
    }
}