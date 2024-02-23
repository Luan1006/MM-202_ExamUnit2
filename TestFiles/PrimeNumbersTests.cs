using static TaskRepository;

namespace Tests
{
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