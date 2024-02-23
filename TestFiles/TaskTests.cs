using System.Diagnostics;
using Colors = AnsiTools.ANSICodes.Colors;
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

            Console.WriteLine($"{Constants.TestsPassed} {passed}");
            Console.WriteLine($"{Constants.TestsFailed} {failed}");
            Console.WriteLine($"{Constants.TotalTime}", time);
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
}