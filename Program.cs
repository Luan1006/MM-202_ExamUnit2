using HTTPUtils;
using static TaskRepository;

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


//#### THIRD TASK
Task initThirdTask = new Task(getThirdTaskResponseContent);
Task thirdTask = GetTaskFromResponse(initThirdTask.taskID);
string thirdTaskAnswer = Roman.Main(thirdTask);
string getFourthTaskResponseContent = CreateSubmitResponse(initThirdTask.taskID, thirdTaskAnswer);

//#### FOURTH TASK
Task initFourthTask = new Task(getFourthTaskResponseContent);
Task fourthTask = GetTaskFromResponse(initFourthTask.taskID);
string fourthTaskAnswer = Series.Main(fourthTask);
string task4SubmitResponse = CreateSubmitResponse(initFourthTask.taskID, fourthTaskAnswer);