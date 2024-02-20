using HTTPUtils;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;
using static Constants;

public class TaskRepository
{
    public static string ProcessTask(Func<Task, string> taskProcessor, string taskId = null)
    {
        Task task = GetTaskFromResponse(taskId);
        string taskAnswer = taskProcessor(task);
        return CreateSubmitResponse(task.taskID, taskAnswer);
    }

    private static Response CreateTaskResponse(string taskID)
    {
        if (taskID == null)
        {
            return HttpUtils.instance.Get(baseURL + startEndpoint + myPersonalID).Result;
        }

        return HttpUtils.instance.Get(baseURL + taskEndpoint + myPersonalID + SLASH + taskID).Result;
    }

    public static Task GetTaskFromResponse(String content = null)
    {
        Response response = CreateTaskResponse(content);
        string responseContent = response.content;
        Task task = new Task(responseContent);

        return task;
    }

    public static string CreateSubmitResponse(string taskID, string answer)
    {
        Response response = HttpUtils.instance.Post(baseURL + taskEndpoint + myPersonalID + SLASH + taskID, answer).Result;

        return EvaluateTaskResponse(response);
    }

    public static string EvaluateTaskResponse(Response taskSubmitResponse)
    {
        Task task = new Task(taskSubmitResponse.content);

        if (task.taskID is not null)
        {
            Console.WriteLine($"{Colors.Green}{Text.Correct}{ANSICodes.Reset}");
        }
        else if (task.got is null)
        {
            Console.WriteLine($"{Colors.Green}{task.Message}{ANSICodes.Reset}");
        }
        else
        {
            Console.WriteLine($"{Colors.Red}{task.Message}{ANSICodes.Reset}");
            Console.Write($"{Text.Got}{Colors.Red}{task.got}{ANSICodes.Reset}");
            Console.Write($"{Text.Expected}{Colors.Green}{task.expected}{ANSICodes.Reset}");

            throw new Exception(Text.TaskFailed);
        }

        Console.WriteLine($"\n{Text.Divider}\n\n");

        return taskSubmitResponse.content;
    }

    public class Fahrenheit
    {
        public static string Main(Task task)
        {
            string celsius = FahrenheitToCelsius(task.parameters);

            Console.WriteLine($"{Text.TaskOne}\n{Colors.Magenta}{task.title}\n{task.description}{ANSICodes.Reset}");
            Console.WriteLine($"{Text.TemperatureInFahrenheit} {Colors.Red}{task.parameters}{ANSICodes.Reset}");
            Console.WriteLine($"{Text.TemperatureInCelsius} {Colors.Green}{celsius}{ANSICodes.Reset}\n");

            return celsius;
        }

        public static string FahrenheitToCelsius(string fahrenheit)
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.InvariantCulture; // InvariantCulture is used to avoid issues with different cultures (e.g. comma vs. dot as decimal separator)

            float fahrenheitFloat = float.Parse(fahrenheit);
            float celsius = (fahrenheitFloat - 32) * 5 / 9;

            return celsius.ToString(Text.TwoDecimal, culture);
        }
    }

    public class PrimeNumbers
    {
        public static string Main(Task task)
        {
            Console.WriteLine($"{Text.TaskTwo}\n{Colors.Magenta}{task.title}\n{task.description}{ANSICodes.Reset}");
            Console.WriteLine($"{Text.Sequence} {Colors.Red}{task.parameters}{ANSICodes.Reset}");

            int[] sequence = task.parameters.Split(Text.CharComma).Select(int.Parse).ToArray();
            string answer = "";

            foreach (int number in sequence.OrderBy(n => n))
            {
                if (IsPrime(number))
                {
                    answer += number + Text.StringComma;
                }
            }

            // Remove the trailing comma
            answer = answer.TrimEnd(',');
            Console.WriteLine($"Prime number(s): {Colors.Green}{answer}{ANSICodes.Reset}\n");

            return answer;
        }

        private static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
    }

    public class Roman
    {
        static Dictionary<char, int> RomanNumber = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
        };

        public static string Main(Task task)
        {
            Console.WriteLine($"Task 3:\n{Colors.Magenta}{task.title}\n{task.description}{ANSICodes.Reset}");
            Console.WriteLine($"Sequence: {Colors.Red}{task.parameters}{ANSICodes.Reset}");


            Console.WriteLine($"Integer: {Colors.Green}{RomanToInteger(task.parameters)}{ANSICodes.Reset}\n");
            string answer = RomanToInteger(task.parameters).ToString();
            return answer;
        }

        static int RomanToInteger(string roman)
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
        public static string Main(Task task)
        {
            Console.WriteLine($"Task 4:\n{Colors.Magenta}{task.title}\n{task.description}{ANSICodes.Reset}");
            Console.WriteLine($"Series: {Colors.Red}{task.parameters}{ANSICodes.Reset}");

            int[] series = task.parameters.Split(',').Select(int.Parse).ToArray();
            int answer = FindSeries(series);

            Console.WriteLine($"Next number: {Colors.Green}{answer}{ANSICodes.Reset}\n");

            return answer.ToString();
        }

        static int FindSeries(int[] series)
        {
            return series[series.Length - 1] - series[series.Length - 2] + series[series.Length - 1];
        }
    }
}