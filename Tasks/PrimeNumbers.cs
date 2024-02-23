using static Constants;

namespace TaskRepository
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
}