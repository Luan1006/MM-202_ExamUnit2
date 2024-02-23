using static Constants;

public class TaskRepository
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

    public class Series
    {
        public static string Run(Task task)
        {
            int[] series = ParseParameters(task.parameters);
            int answer = CalculateNextInSeries(series);

            Print.PrintTaskDetails(Text.TaskFour, task, answer.ToString());

            return answer.ToString();
        }

        public static int[] ParseParameters(string parameters)
        {
            int[] series;
            try
            {
                series = parameters.Split(Text.CharComma).Select(int.Parse).ToArray();
            }
            catch (FormatException)
            {
                series = [];
            }

            return series;
        }

        public static int CalculateNextInSeries(int[] series)
        {
            if (series.Length < 2)
            {
                return 0;
            }

            int lastInSeries = series[series.Length - 1];
            int secondLastInSeries = series[series.Length - 2];

            return lastInSeries * 2 - secondLastInSeries;
        }
    }
}