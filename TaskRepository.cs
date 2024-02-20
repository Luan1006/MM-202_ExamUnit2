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

    public static void PrintTaskCorrect()
    {
        Console.WriteLine($"{Colors.Green}{Text.Correct}{ANSICodes.Reset}");
    }

    public static void PrintGreenMessage(string message)
    {
        Console.WriteLine($"{Colors.Green}{message}{ANSICodes.Reset}");
    }

    public static void PrintRedMessage(string message)
    {
        Console.WriteLine($"{Colors.Red}{message}{ANSICodes.Reset}");
    }

    public static void PrintGotMessage(string got)
    {
        Console.WriteLine($"{Text.Got}{Colors.Red}{got}{ANSICodes.Reset}");
    }

    public static void PrintExpectedMessage(string expected)
    {
        Console.WriteLine($"{Text.Expected}{Colors.Green}{expected}{ANSICodes.Reset}");
    }

    public static void PrintTaskFailed(Task task)
    {
        PrintRedMessage(task.Message);
        PrintGotMessage(task.got);
        PrintExpectedMessage(task.expected);
    }

    public static void PrintDivider()
    {
        Console.WriteLine($"\n{Text.Divider}\n");
    }

    public static string EvaluateTaskResponse(Response taskSubmitResponse)
    {
        Task task = new Task(taskSubmitResponse.content);

        if (task.taskID is not null)
        {
            PrintTaskCorrect();
        }
        else if (task.got is null)
        {
            PrintGreenMessage(task.Message);
        }
        else
        {
            PrintTaskFailed(task);
            throw new Exception(Text.TaskFailed);
        }

        PrintDivider();

        return taskSubmitResponse.content;
    }

    private static void PrintCurrentTask(string currentTask)
    {
        Console.WriteLine($"\n{ANSICodes.Effects.Bold}{Colors.Magenta}{currentTask}{ANSICodes.Reset}");
    }

    private static void PrintTaskTitle(string title)
    {
        Console.WriteLine($"\n{Colors.Cyan}{title}{ANSICodes.Reset}");
    }

    private static void PrintTaskDescription(string description)
    {
        Console.WriteLine($"{Colors.White}{description}{ANSICodes.Reset}\n");
    }

    private static void PrintTaskParameter(string parameter)
    {
        Console.WriteLine($"{Colors.Red}{Text.Parameter} {parameter}{ANSICodes.Reset}");
    }

    private static void PrintTaskAnswer(string answer)
    {
        Console.WriteLine($"{Colors.Green}{Text.Answer} {answer}{ANSICodes.Reset}\n");
    }

    public static void PrintTaskDetails(String currentTask, Task task, String answer)
    {
        PrintCurrentTask(currentTask);
        PrintTaskTitle(task.title);
        PrintTaskDescription(task.description);
        PrintTaskParameter(task.parameters);
        PrintTaskAnswer(answer);
    }

    public class Fahrenheit
    {
        private static readonly System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.InvariantCulture; // InvariantCulture is used to avoid issues with different cultures (e.g. comma vs. dot as decimal separator)
        public static string Run(Task task)
        {
            string celsius = FahrenheitToCelsius(task.parameters);

            PrintTaskDetails(Text.TaskOne, task, celsius);

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
            answer = answer.TrimEnd(Text.CharComma);

            PrintTaskDetails(Text.TaskTwo, task, answer);

            return answer;
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
        static Dictionary<char, int> RomanNumber = new Dictionary<char, int>()
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

            PrintTaskDetails(Text.TaskThree, task, answer);

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
        public static string Run(Task task)
        {
            int[] series = task.parameters.Split(Text.CharComma).Select(int.Parse).ToArray();
            int answer = CalculateNextInSeries(series);

            PrintTaskDetails(Text.TaskFour, task, answer.ToString());

            return answer.ToString();
        }

        static int CalculateNextInSeries(int[] series)
        {
            int lastInSeries = series[series.Length - 1];
            int secondLastInSeries = series[series.Length - 2];

            return lastInSeries * 2 - secondLastInSeries;
        }
    }
}