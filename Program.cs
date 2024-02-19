using HTTPUtils;
using System.Text.Json;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;

Console.Clear();
Console.WriteLine("Starting Assignment 2");

// SETUP 
const string myPersonalID = personalID.myPersonalID; // GET YOUR PERSONAL ID FROM THE ASSIGNMENT PAGE https://mm-203-module-2-server.onrender.com/
const string baseURL = "https://mm-203-module-2-server.onrender.com/";
const string startEndpoint = "start/"; // baseURl + startEndpoint + myPersonalID
const string taskEndpoint = "task/";   // baseURl + taskEndpoint + myPersonalID + "/" + taskID

// Creating a variable for the HttpUtils so that we dont have to type HttpUtils.instance every time we want to use it
HttpUtils httpUtils = HttpUtils.instance;

//#### REGISTRATION
Response startRespons = await httpUtils.Get(baseURL + startEndpoint + myPersonalID);
Console.WriteLine($"Start:\n{Colors.Magenta}{startRespons}{ANSICodes.Reset}\n\n");
string startResponsContent = startRespons.content;
Task startTask1 = new Task(startResponsContent);

//#### FIRST TASK 
Response task1Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + startTask1.taskID); // Get the task from the server
string task1ResponseContent = task1Response.content;
Task task1 = new Task(task1ResponseContent);
Console.WriteLine($"Task 1:\n{Colors.Magenta}{task1.title}\n{task1.description}{ANSICodes.Reset}");
Console.WriteLine($"Temperature in fahrenheit: {Colors.Red}{task1.parameters}{ANSICodes.Reset}");

float fahrenheit = float.Parse(task1.parameters);
float celsius = (fahrenheit - 32) * 5 / 9;
celsius = (float)Math.Round(celsius, 2);
string task1Answer = celsius.ToString();

Console.WriteLine($"Temperature in celsius: {Colors.Green}{celsius}{ANSICodes.Reset}\n\n");
Response task1SubmitResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + task1.taskID, task1Answer);
Task startTask2 = new Task(task1SubmitResponse.content);

//#### SECOND TASK
Response task2Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + startTask2.taskID); // Get the task from the server
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

Console.WriteLine($"Prime number(s): {Colors.Green}{task2Answer}{ANSICodes.Reset}\n\n");
Response task2SubmitResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + task2.taskID, task2Answer);
Task startTask3 = new Task(task2SubmitResponse.content);

//#### THIRD TASK
Response task3Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + startTask3.taskID); // Get the task from the server
string task3ResponseContent = task3Response.content;
Task task3 = new Task(task3ResponseContent);
Console.WriteLine($"Task 3:\n{Colors.Magenta}{task3.title}\n{task3.description}{ANSICodes.Reset}");