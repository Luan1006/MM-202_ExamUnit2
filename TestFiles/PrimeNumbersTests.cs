using TaskRepository;
using static Tests.PrimeNumbersTestsConstants;

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
            string parameters = ValidParameters;
            string expected = ExpectedValidParameters;

            // Act
            string actual = string.Join(Comma, PrimeNumbers.ParseParameters(parameters));

            // Assert
            TaskTests.AreEqual(expected, actual, ParseValidParametersTestTitle, ParseValidParametersFailMessage);
        }

        private void ParseParameters_WithInvalidParameters_ReturnsEmptyList()
        {
            // Arrange
            string parameters = InvalidParameters;
            string expected = ExpectedInvalidParameters;

            // Act
            string actual = string.Join(Comma, PrimeNumbers.ParseParameters(parameters));

            // Assert
            TaskTests.AreEqual(expected, actual, ParseInvalidParametersTestTitle, ParseInvalidParametersFailMessage);
        }

        private void GetPrimeNumbers_WithValidSequence_ReturnsPrimeNumbers()
        {
            // Arrange
            int[] sequence = ValidSequence;
            string expected = ExpectedValidSequencePrimes;

            // Act
            string actual = string.Join(Comma, PrimeNumbers.GetPrimeNumbers(sequence));

            // Assert
            TaskTests.AreEqual(expected, actual, GetPrimesFromValidSequenceTestTitle, GetPrimesFromValidSequenceFailMessage);
        }

        private void GetPrimeNumbers_WithInvalidSequence_ReturnsEmptyList()
        {
            // Arrange
            int[] sequence = InvalidSequence;
            string expected = ExpectedInvalidSequencePrimes;

            // Act
            string actual = string.Join(Comma, PrimeNumbers.GetPrimeNumbers(sequence));

            // Assert
            TaskTests.AreEqual(expected, actual, GetPrimesFromInvalidSequenceTestTitle, GetPrimesFromInvalidSequenceFailMessage);
        }
    }

}