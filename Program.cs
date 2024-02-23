using static TaskRepository;
using static TaskProcessor;
using Tests;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        if (args.Length > 0 && args[0] == "-t")
        {
            TaskTests.Main();
        }

        Console.WriteLine(Constants.Text.StartingAssignment);

        // Registration
        Task registrationTask = GetTaskFromResponse();

        // First task
        string getSecondTaskResponseContent = ProcessTask(Fahrenheit.Run, registrationTask.taskID);

        // Second task
        string getThirdTaskResponseContent = ProcessTask(PrimeNumbers.Run, new Task(getSecondTaskResponseContent).taskID);

        // Third task
        string getFourthTaskResponseContent = ProcessTask(Roman.Run, new Task(getThirdTaskResponseContent).taskID);

        // Fourth task
        string getFifthTaskResponseContent = ProcessTask(Series.Run, new Task(getFourthTaskResponseContent).taskID);
    }
}