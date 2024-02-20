using HTTPUtils;
using static TaskRepository;

Console.Clear();
Console.WriteLine("Starting Assignment 2");

// Creating a variable for the HttpUtils so that we dont have to type HttpUtils.instance every time we want to use it
HttpUtils httpUtils = HttpUtils.instance;

//#### REGISTRATION
Task registrationTask = GetTaskFromResponse();

//#### FIRST TASK 
string getSecondTaskResponseContent = ProcessTask(Fahrenheit.Main, registrationTask.taskID);

//#### SECOND TASK
string getThirdTaskResponseContent = ProcessTask(PrimeNumbers.Main, new Task(getSecondTaskResponseContent).taskID);

//#### THIRD TASK
string getFourthTaskResponseContent = ProcessTask(Roman.Main, new Task(getThirdTaskResponseContent).taskID);

//#### FOURTH TASK
string getFifthTaskResponseContent = ProcessTask(Series.Main, new Task(getFourthTaskResponseContent).taskID);