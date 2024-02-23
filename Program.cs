using TaskRepository;
using Tests;
using static TaskProcessor;

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
        string fahrenheitTaskResponse = ProcessTask(Fahrenheit.Run, registrationTask.taskID);

        // Second task
        string primeNumbersTaskResponse = ProcessTask(PrimeNumbers.Run, new Task(fahrenheitTaskResponse).taskID);

        // Third task
        string romanTaskResponse = ProcessTask(Roman.Run, new Task(primeNumbersTaskResponse).taskID);

        // Fourth task
        string seriesTaskResponse = ProcessTask(Series.Run, new Task(romanTaskResponse).taskID);
    }
}