using HTTPUtils;
using System.Text.Json;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;
using static TaskRepository;
using static Constants;

Console.Clear();
Console.WriteLine("Starting Assignment 2");

// Creating a variable for the HttpUtils so that we dont have to type HttpUtils.instance every time we want to use it
HttpUtils httpUtils = HttpUtils.instance;

//#### REGISTRATION
Response registrationResponse = CreateStartResponse();
string registrationResponseContent = registrationResponse.content;
Task registrationTask = new Task(registrationResponseContent);

//#### FIRST TASK 
Response firstTaskResponse = CreateTaskResponse(registrationTask.taskID);
string firstTaskContent = firstTaskResponse.content;
Task firstTask = new Task(firstTaskContent);

string task1Answer = Fahrenheit.Main(firstTask);

string getStartTask2ResponsContent = CreateSubmitResponse(registrationTask.taskID, task1Answer);

//#### SECOND TASK
Task initializeTask2 = new Task(getStartTask2ResponsContent);

Response task2Response = CreateTaskResponse(initializeTask2.taskID);
string task2ResponseContent = task2Response.content;
Task task2 = new Task(task2ResponseContent);
Console.WriteLine($"Task 2:\n{Colors.Magenta}{task2.title}\n{task2.description}{ANSICodes.Reset}");
Console.WriteLine($"Sequence: {Colors.Red}{task2.parameters}{ANSICodes.Reset}");

int[] sequence = task2.parameters.Split(',').Select(int.Parse).ToArray();
string task2Answer = "";

static bool IsPrime(int number)
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

foreach (int number in sequence.OrderBy(n => n))
{
    if (IsPrime(number))
    {
        task2Answer += number + ",";
    }
}

// Remove the trailing comma
task2Answer = task2Answer.TrimEnd(',');

Console.WriteLine($"Prime number(s): {Colors.Green}{task2Answer}{ANSICodes.Reset}\n");
Response task2SubmitResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + task2.taskID, task2Answer);
EvaluateTaskResponse(task2SubmitResponse);

Task startTask3 = new Task(task2SubmitResponse.content);

//#### THIRD TASK
Response task3Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + startTask3.taskID); // Get the task from the server
string task3ResponseContent = task3Response.content;
Task task3 = new Task(task3ResponseContent);
Console.WriteLine($"Task 3:\n{Colors.Magenta}{task3.title}\n{task3.description}{ANSICodes.Reset}");
Console.WriteLine($"Sequence: {Colors.Red}{task3.parameters}{ANSICodes.Reset}");

Dictionary<char, int> RomanNumber = new Dictionary<char, int>()
{
    {'I', 1},
    {'V', 5},
    {'X', 10},
    {'L', 50},
    {'C', 100},
};

int RomanToInteger(string roman)
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

Console.WriteLine($"Integer: {Colors.Green}{RomanToInteger(task3.parameters)}{ANSICodes.Reset}\n");
string task3Answer = RomanToInteger(task3.parameters).ToString();
Response task3SubmitResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + task3.taskID, task3Answer);
EvaluateTaskResponse(task3SubmitResponse);

//#### FOURTH TASK
Task startTask4 = new Task(task3SubmitResponse.content);
Response task4Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + startTask4.taskID); // Get the task from the server
string task4ResponseContent = task4Response.content;
Task task4 = new Task(task4ResponseContent);
Console.WriteLine($"Task 4:\n{Colors.Magenta}{task4.title}\n{task4.description}{ANSICodes.Reset}");
Console.WriteLine($"Series: {Colors.Red}{task4.parameters}{ANSICodes.Reset}");

int[] series = task4.parameters.Split(',').Select(int.Parse).ToArray();
int task4Answer = series[series.Length - 1] - series[series.Length - 2] + series[series.Length - 1];

Console.WriteLine($"Next number: {Colors.Green}{task4Answer}{ANSICodes.Reset}\n");

Response task4SubmitResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + task4.taskID, task4Answer.ToString());
Console.WriteLine(task4SubmitResponse.content);