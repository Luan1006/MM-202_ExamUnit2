using System.Diagnostics;
using static TaskRepository;

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
            fahrenheitTests.FahrenheitToCelsius_WhenInputIs32_Returns0();
            Console.WriteLine($"Tests passed: {passed}");
            Console.WriteLine($"Tests failed: {failed}");
            Console.WriteLine($"Total time: {time}ms");
        }

        public static bool AreEqual(string expected, string actual, string testName, string message)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (expected != actual)
            {
                Console.WriteLine($"{testName} - {message}");
                stopWatch.Stop();
                Console.WriteLine($"{testName} failed in {stopWatch.ElapsedMilliseconds}ms");
                failed++;
                time += stopWatch.ElapsedMilliseconds;
                return false;
            }

            stopWatch.Stop();
            Console.WriteLine($"{testName} passed in {stopWatch.ElapsedMilliseconds}ms");
            passed++;
            return true;
        }

    }
    public class FahrenheitTests
    {
        public void FahrenheitUsesCorrectParameter()
        {
            // Arrange
            string jsonContent = "{\"title\":\"Fahrenheit to Celsius\",\"description\":\"Converts a temperature in Fahrenheit to Celsius\",\"taskID\":\"1\",\"usierID\":\"1\",\"parameters\":\"32\",\"Message\":\"\",\"got\":\"\",\"expected\":\"0.00\"}";
            Task task = new Task(jsonContent);
            string expected = "32";
            // Act
            var actual = task.parameters;

            TaskTests.AreEqual(expected, actual, "Fahrenheit","FahrenheitUsesCorrectParameter did not return the expected value");
        }
        public void FahrenheitToCelsius_WhenInputIs32_Returns0()
        {
            // Arrange
            string fahrenheit = "32";
            string expected = "0.00";
            // Act
            var actual = Fahrenheit.FahrenheitToCelsius(fahrenheit);

            TaskTests.AreEqual(expected, actual, "Fahrenheit","FahrenheitToCelsius did not return the expected value");
        }
    }
}