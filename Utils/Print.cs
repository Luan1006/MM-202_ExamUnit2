using Colors = AnsiTools.ANSICodes.Colors;
using AnsiTools;
using static Constants;

public class Print
{
    public static void PrintTaskCorrect()
    {
        Console.WriteLine($"{Colors.Green}{Text.Correct}{ANSICodes.Reset}");
    }

    public static void PrintColoredMessage(string message, string color, bool newLine = true)
    {
        if (newLine)
        {
            Console.WriteLine($"{color}{message}{ANSICodes.Reset}");
        }
        else
        {
            Console.Write($"{color}{message}{ANSICodes.Reset}");
        }
    }

    public static void PrintGotMessage(string got)
    {
        Console.WriteLine($"{Text.Got}{Colors.Red}{got}{ANSICodes.Reset}");
    }

    public static void PrintExpectedMessage(string expected)
    {
        Console.WriteLine($"{Text.Expected}{Colors.Green}{expected}{ANSICodes.Reset}");
    }

    public static void PrintTaskFailed(Task task)
    {
        PrintColoredMessage(task.Message, Colors.Red);
        PrintGotMessage(task.got);
        PrintExpectedMessage(task.expected);
    }

    public static void PrintDivider()
    {
        Console.WriteLine($"\n{Text.Divider}\n");
    }

    private static void PrintCurrentTask(string currentTask)
    {
        Console.WriteLine($"\n{ANSICodes.Effects.Bold}{Colors.Magenta}{currentTask}{ANSICodes.Reset}");
    }

    private static void PrintTaskTitle(string title)
    {
        Console.WriteLine($"\n{Colors.Cyan}{title}{ANSICodes.Reset}");
    }

    private static void PrintTaskDescription(string description)
    {
        Console.WriteLine($"{Colors.White}{description}{ANSICodes.Reset}\n");
    }

    private static void PrintTaskParameter(string parameter)
    {
        Console.WriteLine($"{Colors.Red}{Text.Parameter} {parameter}{ANSICodes.Reset}");
    }

    private static void PrintTaskAnswer(string answer)
    {
        Console.WriteLine($"{Colors.Green}{Text.Answer} {answer}{ANSICodes.Reset}\n");
    }

    private static void PrintTime(long time)
    {
        Console.WriteLine($"{Text.In} {time}{Text.Ms}{ANSICodes.Reset}");
    }

    public static void PrintTestResult(string testName, string testStatus, long elapsedMilliseconds, string color)
    {
        Print.PrintColoredMessage($"{testName} {testStatus}", color, false);
        Print.PrintTime(elapsedMilliseconds);
    }

    public static void PrintTaskDetails(String currentTask, Task task, String answer)
    {
        PrintCurrentTask(currentTask);
        PrintTaskTitle(task.title);
        PrintTaskDescription(task.description);
        PrintTaskParameter(task.parameters);
        PrintTaskAnswer(answer);
    }
}