using HTTPUtils;
using System.Text.Json;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;

public class TaskRepository
{
    private static Response CreateTaskResponse(string taskID)
    {
        if (taskID == null)
        {
            return HttpUtils.instance.Get(Constants.baseURL + Constants.startEndpoint + Constants.myPersonalID).Result;
        }

        return HttpUtils.instance.Get(Constants.baseURL + Constants.taskEndpoint + Constants.myPersonalID + "/" + taskID).Result;
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
        Response response = HttpUtils.instance.Post(Constants.baseURL + Constants.taskEndpoint + Constants.myPersonalID + "/" + taskID, answer).Result;

        return EvaluateTaskResponse(response);
    }

    public static string EvaluateTaskResponse(Response taskSubmitResponse)
    {
        // Check if answer was correct
        if (taskSubmitResponse.content.Contains("taskID"))
        {
            Console.WriteLine($"{Colors.Green}Correct!{ANSICodes.Reset}");
        }
        else
        {
            Task taskFailed = new Task(taskSubmitResponse.content);
            Console.WriteLine($"{Colors.Red}Incorrect!{ANSICodes.Reset}");
            Console.Write($"Got: {Colors.Red}{taskFailed.got}{ANSICodes.Reset}");
            Console.Write($"Expected: {Colors.Green}{taskFailed.expected}{ANSICodes.Reset}");

            throw new Exception("Task failed");
        }

        Console.WriteLine("\n-----------------------------\n\n");

        return taskSubmitResponse.content;
    }

    public class Fahrenheit
    {
        public static string Main(Task task)
        {
            string celsius = FahrenheitToCelsius(task.parameters);

            Console.WriteLine($"Task 1:\n{Colors.Magenta}{task.title}\n{task.description}{ANSICodes.Reset}");
            Console.WriteLine($"Temperature in fahrenheit: {Colors.Red}{task.parameters}{ANSICodes.Reset}");
            Console.WriteLine($"Temperature in celsius: {Colors.Green}{celsius}{ANSICodes.Reset}\n");

            return celsius;
        }

        public static string FahrenheitToCelsius(string fahrenheit)
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.InvariantCulture; // InvariantCulture is used to avoid issues with different cultures (e.g. comma vs. dot as decimal separator)

            float fahrenheitFloat = float.Parse(fahrenheit);
            float celsius = (fahrenheitFloat - 32) * 5 / 9;
            celsius = (float)Math.Round(celsius, 2);

            return celsius.ToString(culture);
        }
    }

    public class PrimeNumbers
    {
        public static string Main(Task task)
        {
            Console.WriteLine($"Task 2:\n{Colors.Magenta}{task.title}\n{task.description}{ANSICodes.Reset}");
            Console.WriteLine($"Sequence: {Colors.Red}{task.parameters}{ANSICodes.Reset}");

            int[] sequence = task.parameters.Split(',').Select(int.Parse).ToArray();
            string answer = "";

            foreach (int number in sequence.OrderBy(n => n))
            {
                if (IsPrime(number))
                {
                    answer += number + ",";
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
}