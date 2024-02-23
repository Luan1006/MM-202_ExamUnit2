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

            RomanTests romanTests = new RomanTests();
            romanTests.Run();

            SeriesTests seriesTests = new SeriesTests();
            seriesTests.Run();

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

        public static void AreEqual(int[] expected, int[] actual, string testName, string message)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (!Enumerable.SequenceEqual(expected, actual))
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

    public class RomanTests
    {
        public void Run()
        {
            RomanToInteger_WhenInputIsI_Returns1();
            RomanToInteger_WhenInputIsV_Returns5();
            RomanToInteger_WhenInputIsX_Returns10();
            RomanToInteger_WhenInputIsL_Returns50();
            RomanToInteger_WhenInputIsC_Returns100();
            RomanToInteger_WhenInputIsIV_Returns4();
            RomanToInteger_WhenInputIsIX_Returns9();
            RomanToInteger_WhenInputIsEmpty_Returns0();
            RomanToInteger_WhenInputIsInvalid_Returns0();
        }

        private void RomanToInteger_WhenInputIsI_Returns1()
        {
            // Arrange
            string roman = "I";
            string expected = "1";
            // Act
            var actual = Roman.RomanToInteger(roman).ToString();

            TaskTests.AreEqual(expected, actual, "Roman Test: Conversion of I", "RomanToInteger_WhenInputIsI_Returns1 did not return the expected value");
        }

        private void RomanToInteger_WhenInputIsV_Returns5()
        {
            // Arrange
            string roman = "V";
            string expected = "5";
            // Act
            var actual = Roman.RomanToInteger(roman).ToString();

            TaskTests.AreEqual(expected, actual, "Roman Test: Conversion of V", "RomanToInteger_WhenInputIsV_Returns5 did not return the expected value");
        }

        private void RomanToInteger_WhenInputIsX_Returns10()
        {
            // Arrange
            string roman = "X";
            string expected = "10";
            // Act
            var actual = Roman.RomanToInteger(roman).ToString();

            TaskTests.AreEqual(expected, actual, "Roman Test: Conversion of X", "RomanToInteger_WhenInputIsX_Returns10 did not return the expected value");
        }

        private void RomanToInteger_WhenInputIsL_Returns50()
        {
            // Arrange
            string roman = "L";
            string expected = "50";
            // Act
            var actual = Roman.RomanToInteger(roman).ToString();

            TaskTests.AreEqual(expected, actual, "Roman Test: Conversion of L", "RomanToInteger_WhenInputIsL_Returns50 did not return the expected value");
        }

        private void RomanToInteger_WhenInputIsC_Returns100()
        {
            // Arrange
            string roman = "C";
            string expected = "100";
            // Act
            var actual = Roman.RomanToInteger(roman).ToString();

            TaskTests.AreEqual(expected, actual, "Roman Test: Conversion of C", "RomanToInteger_WhenInputIsC_Returns100 did not return the expected value");
        }

        private void RomanToInteger_WhenInputIsIV_Returns4()
        {
            // Arrange
            string roman = "IV";
            string expected = "4";
            // Act
            var actual = Roman.RomanToInteger(roman).ToString();

            TaskTests.AreEqual(expected, actual, "Roman Test: Conversion of IV", "RomanToInteger_WhenInputIsIV_Returns4 did not return the expected value");
        }

        private void RomanToInteger_WhenInputIsIX_Returns9()
        {
            // Arrange
            string roman = "IX";
            string expected = "9";
            // Act
            var actual = Roman.RomanToInteger(roman).ToString();

            TaskTests.AreEqual(expected, actual, "Roman Test: Conversion of IX", "RomanToInteger_WhenInputIsIX_Returns9 did not return the expected value");
        }

        private void RomanToInteger_WhenInputIsEmpty_Returns0()
        {
            // Arrange
            string roman = "";
            string expected = "0";
            // Act
            var actual = Roman.RomanToInteger(roman).ToString();

            TaskTests.AreEqual(expected, actual, "Roman Test: Conversion of Empty String", "RomanToInteger_WhenInputIsEmpty_Returns0 did not return the expected value");
        }

        private void RomanToInteger_WhenInputIsInvalid_Returns0()
        {
            // Arrange
            string roman = "Z";
            string expected = "0";
            // Act
            var actual = Roman.RomanToInteger(roman).ToString();

            TaskTests.AreEqual(expected, actual, "Roman Test: Invalid Roman Numeral", "RomanToInteger_WhenInputIsInvalid_ReturnsMinusOne did not return the expected value");
        }
    }

    public class SeriesTests
    {
        public void Run()
        {
            CalculateNextInSeries_WhenInputIs123_Returns4();
            CalculateNextInSeries_WhenInputIs246_Returns8();
            CalculateNextInSeries_WhenInputIsEmpty_Returns0();
            ParseParameters_WhenInputIsValid_ReturnsCorrectArray();
            ParseParameters_WhenInputIsInvalid_ReturnsEmptyArray();
        }

        private void CalculateNextInSeries_WhenInputIs123_Returns4()
        {
            // Arrange
            int[] series = { 1, 2, 3 };
            string expected = "4";
            // Act
            var actual = Series.CalculateNextInSeries(series).ToString();

            TaskTests.AreEqual(expected, actual, "Series Test: Next in series of 1,2,3", "CalculateNextInSeries_WhenInputIs123_Returns4 did not return the expected value");
        }

        private void CalculateNextInSeries_WhenInputIs246_Returns8()
        {
            // Arrange
            int[] series = { 2, 4, 6 };
            string expected = "8";
            // Act
            var actual = Series.CalculateNextInSeries(series).ToString();

            TaskTests.AreEqual(expected, actual, "Series Test: Next in series of 2,4,6", "CalculateNextInSeries_WhenInputIs246_Returns8 did not return the expected value");
        }

        private void CalculateNextInSeries_WhenInputIsEmpty_Returns0()
        {
            // Arrange
            int[] series = { };
            string expected = "0";
            // Act
            var actual = Series.CalculateNextInSeries(series).ToString();

            TaskTests.AreEqual(expected, actual, "Series Test: Next in series of empty string", "CalculateNextInSeries_WhenInputIsEmpty_Returns0 did not return the expected value");
        }
        public void ParseParameters_WhenInputIsValid_ReturnsCorrectArray()
        {
            // Arrange
            string parameters = "1,2,3";
            int[] expected = { 1, 2, 3 };
            // Act
            var actual = Series.ParseParameters(parameters);

            // Assert
            TaskTests.AreEqual(expected, actual, "Series Test: Parse Parameters", "ParseParameters_WhenInputIsValid_ReturnsCorrectArray did not return the expected value");
        }

        public void ParseParameters_WhenInputIsInvalid_ReturnsEmptyArray()
        {
            // Arrange
            string parameters = "1,2,3,abc";
            int[] expected = { };
            // Act
            var actual = Series.ParseParameters(parameters);

            // Assert
            TaskTests.AreEqual(expected, actual, "Series Test: Parse Invalid Parameters", "ParseParameters_WhenInputIsInvalid_ReturnsEmptyArray did not return the expected value");
        }
    }
}