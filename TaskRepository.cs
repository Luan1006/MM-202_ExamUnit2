using static Constants;

public class TaskRepository
{
    public class PrimeNumbers
    {
        public static string Run(Task task)
        {
            int[] sequence = ParseParameters(task.parameters);
            string answer = GetPrimeNumbers(sequence);
            Print.PrintTaskDetails(Text.TaskTwo, task, answer);

            return answer;
        }

        public static int[] ParseParameters(string parameters)
        {
            int[] sequence;
            try
            {
                sequence = parameters.Split(Text.CharComma).Select(int.Parse).ToArray();
            }
            catch (FormatException)
            {
                sequence = [];
            }

            return sequence;
        }

        public static string GetPrimeNumbers(int[] sequence)
        {
            string primeNumbers = "";

            foreach (int number in sequence.OrderBy(n => n))
            {
                if (IsPrime(number))
                {
                    primeNumbers += number + Text.StringComma;
                }
            }

            // Remove the trailing comma
            primeNumbers = primeNumbers.TrimEnd(Text.CharComma);

            return primeNumbers;
        }

        private static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }

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