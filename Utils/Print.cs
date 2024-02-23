using Colors = AnsiTools.ANSICodes.Colors;
using AnsiTools;
using static Constants;
using System.Text.RegularExpressions;

public class Print
{
    public static void PrintTaskCorrect()
    {
        PrintCentered($"{Colors.Green}{Text.Correct}{ANSICodes.Reset}\n");
    }

    public static void PrintColoredMessage(string message, string color, bool newLine = true)
    {
        if (newLine)
        {
            PrintCentered($"{color}{message}{ANSICodes.Reset}");
        }
        else
        {
            PrintCentered($"{color}{message}{ANSICodes.Reset}", newLine);
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
        PrintCentered($"{Text.Divider}\n");
    }

    public static void PrintCentered(string message, bool newLine = true)
    {
        // Calculate the length of the ANSI escape codes
        int ansiEscapeCodeLength = message.Length - Regex.Replace(message, @"\x1B\[[^@-~]*[@-~]", string.Empty).Length;

        int windowWidth = Console.WindowWidth;
        // Subtract the length of the ANSI escape codes from the message length
        int paddingSize = (windowWidth - message.Length + ansiEscapeCodeLength) / 2;

        string paddedMessage = message.PadLeft(message.Length + paddingSize);

        if (newLine)
        {
            Console.WriteLine(paddedMessage);
        }
        else
        {
            Console.Write(paddedMessage);
        }
    }

    private static void PrintCurrentTask(string currentTask)
    {
        PrintCentered($"{Colors.Magenta}{currentTask}{ANSICodes.Reset}");
    }

    private static void PrintTaskTitle(string title)
    {
        PrintCentered($"{Colors.Cyan}{title}{ANSICodes.Reset}");
    }

    private static void PrintTaskDescription(string description)
    {
        PrintCentered($"{description}\n");
    }

    private static void PrintTaskParameter(string parameter)
    {
        PrintCentered($"{Colors.Red}{Text.Parameter} {parameter}{ANSICodes.Reset}");
    }

    private static void PrintTaskAnswer(string answer)
    {
        PrintCentered($"{Colors.Green}{Text.Answer} {answer}{ANSICodes.Reset}\n");
    }

    private static void PrintTime(long time)
    {
        Console.WriteLine($"{Text.In} {time}{Text.Ms}{ANSICodes.Reset}");
    }

    public static void PrintTestResult(string testName, string testStatus, long elapsedMilliseconds, string color)
    {
        PrintColoredMessage($"{testName} {testStatus} ", color, false);
        PrintTime(elapsedMilliseconds);
    }

    public static void PrintTaskDetails(string currentTask, Task task, string answer)
    {
        PrintCurrentTask(currentTask);
        PrintTaskTitle(task.title);
        PrintTaskDescription(task.description);
        PrintTaskParameter(task.parameters);
        PrintTaskAnswer(answer);
    }
}