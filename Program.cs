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
Task registrationTask = GetTaskFromResponse();

//#### FIRST TASK 
Task firstTask = GetTaskFromResponse(registrationTask.taskID);

string firstTaskAnswer = Fahrenheit.Main(firstTask);

string getSecondTaskResponseContent = CreateSubmitResponse(registrationTask.taskID, firstTaskAnswer);

//#### SECOND TASK
Task initSecondTask = new Task(getSecondTaskResponseContent);

Task secondTask = GetTaskFromResponse(initSecondTask.taskID);

string secondTaskAnswer = PrimeNumbers.Main(secondTask);

string getThirdTaskResponseContent = CreateSubmitResponse(initSecondTask.taskID, secondTaskAnswer);

Task startTask3 = new Task(getThirdTaskResponseContent);

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