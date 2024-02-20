using static TaskRepository;

Console.Clear();
Console.WriteLine(Constants.TextStrings.StartingAssignment);

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