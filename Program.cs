using static TaskRepository;

Console.Clear();
Console.WriteLine(Constants.Text.StartingAssignment);

// Regsitration
Task registrationTask = GetTaskFromResponse();

// First task
string getSecondTaskResponseContent = ProcessTask(Fahrenheit.Main, registrationTask.taskID);

// Second task
string getThirdTaskResponseContent = ProcessTask(PrimeNumbers.Main, new Task(getSecondTaskResponseContent).taskID);

// Third task
string getFourthTaskResponseContent = ProcessTask(Roman.Main, new Task(getThirdTaskResponseContent).taskID);

// Fourth task
string getFifthTaskResponseContent = ProcessTask(Series.Main, new Task(getFourthTaskResponseContent).taskID);