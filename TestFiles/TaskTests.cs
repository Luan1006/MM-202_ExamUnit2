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

            PrimeNumbersTests primeNumbersTests = new PrimeNumbersTests();
            primeNumbersTests.Run();

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
            UsesCorrectParameter_ReturnsExpectedParameter();
            GetCultureInfo_ReturnsInvariantCulture();
            FahrenheitToCelsius_WhenInputIs32_Returns0();
            FahrenheitToCelsius_WhenInputIsNegative_ReturnsExpectedResult();
            FahrenheitToCelsius_WhenInputIsZero_ReturnsExpectedResult();
            FahrenheitToCelsius_WhenInputIsNonNumeric_ReturnsErrorMessage();
            FahrenheitToCelsius_WhenInputIsEmpty_ReturnsErrorMessage();
        }

        public void UsesCorrectParameter_ReturnsExpectedParameter()
        {
            // Arrange
            string jsonContent = "{\"title\":\"Fahrenheit to Celsius\",\"description\":\"Converts a temperature in Fahrenheit to Celsius\",\"taskID\":\"1\",\"usierID\":\"1\",\"parameters\":\"32\",\"Message\":\"\",\"got\":\"\",\"expected\":\"0.00\"}";
            Task task = new Task(jsonContent);
            string expected = "32";
            // Act
            var actual = task.parameters;

            TaskTests.AreEqual(expected, actual, "Fahrenheit Test: Correct Parameter", "UsesCorrectParameter_ReturnsExpectedParameter did not return the expected value");
        }

        public void GetCultureInfo_ReturnsInvariantCulture()
        {
            // Arrange
            System.Globalization.CultureInfo expected = System.Globalization.CultureInfo.InvariantCulture;

            // Act
            var actual = Fahrenheit.GetCultureInfo();

            // Assert
            TaskTests.AreEqual(expected.ToString(), actual.ToString(), "Fahrenheit Test: Invariant Culture", "GetCultureInfo_ReturnsInvariantCulture does not use InvariantCulture");
        }

        public void FahrenheitToCelsius_WhenInputIs32_Returns0()
        {
            // Arrange
            string fahrenheit = "32";
            string expected = "0.00";
            // Act
            var actual = Fahrenheit.FahrenheitToCelsius(fahrenheit);

            TaskTests.AreEqual(expected, actual, "Fahrenheit Test: Conversion of 32F", "FahrenheitToCelsius_WhenInputIs32_Returns0 did not return the expected value");
        }

        public void FahrenheitToCelsius_WhenInputIsNegative_ReturnsExpectedResult()
        {
            // Arrange
            string fahrenheit = "-40";
            string expected = "-40.00";
            // Act
            var actual = Fahrenheit.FahrenheitToCelsius(fahrenheit);

            TaskTests.AreEqual(expected, actual, "Fahrenheit Test: Conversion of Negative Value", "FahrenheitToCelsius_WhenInputIsNegative_ReturnsExpectedResult did not return the expected value");
        }

        public void FahrenheitToCelsius_WhenInputIsZero_ReturnsExpectedResult()
        {
            // Arrange
            string fahrenheit = "0";
            string expected = "-17.78";
            // Act
            var actual = Fahrenheit.FahrenheitToCelsius(fahrenheit);

            TaskTests.AreEqual(expected, actual, "Fahrenheit Test: Conversion of 0F", "FahrenheitToCelsius_WhenInputIsZero_ReturnsExpectedResult did not return the expected value");
        }

        public void FahrenheitToCelsius_WhenInputIsNonNumeric_ReturnsErrorMessage()
        {
            // Arrange
            string fahrenheit = "abc";
            string expected = "Input must be a valid number.";

            // Act
            var actual = Fahrenheit.FahrenheitToCelsius(fahrenheit);

            TaskTests.AreEqual(expected, actual, "Fahrenheit Test: Non-Numeric Input", "FahrenheitToCelsius_WhenInputIsNonNumeric_ReturnsErrorMessage did not return the expected error message");
        }

        public void FahrenheitToCelsius_WhenInputIsEmpty_ReturnsErrorMessage()
        {
            // Arrange
            string fahrenheit = "";
            string expected = "Input must be a valid number.";

            // Act
            var actual = Fahrenheit.FahrenheitToCelsius(fahrenheit);

            TaskTests.AreEqual(expected, actual, "Fahrenheit Test: Empty Input", "FahrenheitToCelsius_WhenInputIsEmpty_ReturnsErrorMessage did not return the expected error message");
        }
    }

    public class PrimeNumbersTests
    {
        public void Run()
        {
            ParseParameters_WithValidParameters_ReturnsNumberSequence();
            ParseParameters_WithInvalidParameters_ReturnsEmptyList();
            GetPrimeNumbers_WithValidSequence_ReturnsPrimeNumbers();
            GetPrimeNumbers_WithInvalidSequence_ReturnsEmptyList();
        }

        private void ParseParameters_WithValidParameters_ReturnsNumberSequence()
        {
            // Arrange
            string parameters = "2,3,4,5,6,7,8,9,10";
            var expected = "2,3,4,5,6,7,8,9,10";

            // Act
            var actual = string.Join(",", PrimeNumbers.ParseParameters(parameters));

            // Assert
            TaskTests.AreEqual(expected, actual, "PrimeNumbers Test: Parse Valid Parameters", "Did not return the expected number sequence");
        }

        private void ParseParameters_WithInvalidParameters_ReturnsEmptyList()
        {
            // Arrange
            string parameters = "2,3,4,abc,6,7,8,9,10";
            var expected = "";

            // Act
            var actual = string.Join(",", PrimeNumbers.ParseParameters(parameters));

            // Assert
            TaskTests.AreEqual(expected, actual, "PrimeNumbers Test: Parse Invalid Parameters", "Did not return an empty list");
        }

        private void GetPrimeNumbers_WithValidSequence_ReturnsPrimeNumbers()
        {
            // Arrange
            int[] sequence = { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var expected = "2,3,5,7";

            // Act
            var actual = string.Join(",", PrimeNumbers.GetPrimeNumbers(sequence));

            // Assert
            TaskTests.AreEqual(expected, actual, "PrimeNumbers Test: Get Primes from Valid Sequence", "Did not return the expected prime numbers");
        }

        private void GetPrimeNumbers_WithInvalidSequence_ReturnsEmptyList()
        {
            // Arrange
            int[] sequence = { 1, 4, 6, 8, 9, 10 };
            var expected = "";

            // Act
            var actual = string.Join(",", PrimeNumbers.GetPrimeNumbers(sequence));

            // Assert
            TaskTests.AreEqual(expected, actual, "PrimeNumbers Test: Get Primes from Invalid Sequence", "Did not return an empty list");
        }
    }
}