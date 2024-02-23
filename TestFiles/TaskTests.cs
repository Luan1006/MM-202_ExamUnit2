using System.Diagnostics;
using Colors = AnsiTools.ANSICodes.Colors;
using static TaskRepository;
using static Constants;

namespace Tests
{
    public class TaskTests
    {
        public static int passed = 0;
        public static int failed = 0;
        public static long time = 0;

        public static void Main()
        {
            FahrenheitTests fahrenheitTests = new FahrenheitTests();
            fahrenheitTests.Run();

            Console.WriteLine($"Tests passed: {passed}");
            Console.WriteLine($"Tests failed: {failed}");
            Console.WriteLine($"Total time: {time} ms\n");
        }

        public static void AreEqual(string expected, string actual, string testName, string message)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (expected != actual)
            {
                Console.WriteLine($"{testName} - {message}");
                stopWatch.Stop();
                Print.PrintTestResult(testName, Text.Failed, stopWatch.ElapsedMilliseconds, Colors.Red);
                failed++;
                time += stopWatch.ElapsedMilliseconds;
                return;
            }

            stopWatch.Stop();
            Print.PrintTestResult(testName, Text.Passed, stopWatch.ElapsedMilliseconds, Colors.Green);
            passed++;
            return;
        }

    }
    public class FahrenheitTests
    {
        public void Run()
        {
            FahrenheitUsesCorrectParameter();
            FahrenheitUsesInvariantCulture();
            FahrenheitToCelsius_WhenInputIs32_Returns0();
        }

        public void FahrenheitUsesCorrectParameter()
        {
            // Arrange
            string jsonContent = "{\"title\":\"Fahrenheit to Celsius\",\"description\":\"Converts a temperature in Fahrenheit to Celsius\",\"taskID\":\"1\",\"usierID\":\"1\",\"parameters\":\"32\",\"Message\":\"\",\"got\":\"\",\"expected\":\"0.00\"}";
            Task task = new Task(jsonContent);
            string expected = "32";
            // Act
            var actual = task.parameters;

            TaskTests.AreEqual(expected, actual, "Fahrenheit Correct Parameter", "FahrenheitUsesCorrectParameter did not return the expected value");
        }
        public void FahrenheitUsesInvariantCulture()
        {
            // Arrange
            System.Globalization.CultureInfo expected = System.Globalization.CultureInfo.InvariantCulture;

            // Act
            var actual = Fahrenheit.GetCultureInfo();

            // Assert
            TaskTests.AreEqual(expected.ToString(), actual.ToString(), "Fahrenheit Culture", "Fahrenheit does not use InvariantCulture");
        }
        public void FahrenheitToCelsius_WhenInputIs32_Returns0()
        {
            // Arrange
            string fahrenheit = "32";
            string expected = "0.00";
            // Act
            var actual = Fahrenheit.FahrenheitToCelsius(fahrenheit);

            TaskTests.AreEqual(expected, actual, "Fahrenheit Input and Return", "FahrenheitToCelsius did not return the expected value");
        }
    }
}