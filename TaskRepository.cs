using static Constants;

public class TaskRepository
{

    public class Fahrenheit
    {
        private static readonly System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.InvariantCulture; // InvariantCulture is used to avoid issues with different cultures (e.g. comma vs. dot as decimal separator)
        public static string Run(Task task)
        {
            string celsius = FahrenheitToCelsius(task.parameters);

            Print.PrintTaskDetails(Text.TaskOne, task, celsius);

            return celsius;
        }

        public static string FahrenheitToCelsius(string fahrenheit)
        {
            float fahrenheitFloat = float.Parse(fahrenheit);
            float celsius = (fahrenheitFloat - 32) * 5 / 9;

            return celsius.ToString(Text.TwoDecimal, culture);
        }
    }

    public class PrimeNumbers
    {
        public static string Run(Task task)
        {
            int[] sequence = ParseParameters(task.parameters);
            string answer = GetPrimeNumbers(sequence);
            Print.PrintTaskDetails(Text.TaskTwo, task, answer);

            return answer;
        }

        private static int[] ParseParameters(string parameters)
        {
            return parameters.Split(Text.CharComma).Select(int.Parse).ToArray();
        }

        private static string GetPrimeNumbers(int[] sequence)
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

        private static int RomanToInteger(string roman)
        {
            int number = 0;
            for (int i = 0; i < roman.Length; i++)
            {
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

        private static int[] ParseParameters(string parameters)
        {
            return parameters.Split(Text.CharComma).Select(int.Parse).ToArray();
        }

        private static int CalculateNextInSeries(int[] series)
        {
            int lastInSeries = series[series.Length - 1];
            int secondLastInSeries = series[series.Length - 2];

            return lastInSeries * 2 - secondLastInSeries;
        }
    }
}