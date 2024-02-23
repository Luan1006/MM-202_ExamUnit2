using static TaskRepository;
using static TaskProcessor;

Console.Clear();
Console.WriteLine(Constants.Text.StartingAssignment);

// Regsitration
Task registrationTask = GetTaskFromResponse();

// First task
string getSecondTaskResponseContent = ProcessTask(Fahrenheit.Run, registrationTask.taskID);

// Second task
string getThirdTaskResponseContent = ProcessTask(PrimeNumbers.Run, new Task(getSecondTaskResponseContent).taskID);

// Third task
string getFourthTaskResponseContent = ProcessTask(Roman.Run, new Task(getThirdTaskResponseContent).taskID);

// Fourth task
string getFifthTaskResponseContent = ProcessTask(Series.Run, new Task(getFourthTaskResponseContent).taskID);