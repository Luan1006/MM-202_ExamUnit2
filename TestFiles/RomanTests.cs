using static TaskRepository;

namespace Tests
{
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
            string actual = Roman.RomanToInteger(roman).ToString();

            TaskTests.AreEqual(expected, actual, "Roman Test: Conversion of I", "RomanToInteger_WhenInputIsI_Returns1 did not return the expected value");
        }

        private void RomanToInteger_WhenInputIsV_Returns5()
        {
            // Arrange
            string roman = "V";
            string expected = "5";
            // Act
            string actual = Roman.RomanToInteger(roman).ToString();

            TaskTests.AreEqual(expected, actual, "Roman Test: Conversion of V", "RomanToInteger_WhenInputIsV_Returns5 did not return the expected value");
        }

        private void RomanToInteger_WhenInputIsX_Returns10()
        {
            // Arrange
            string roman = "X";
            string expected = "10";
            // Act
            string actual = Roman.RomanToInteger(roman).ToString();

            TaskTests.AreEqual(expected, actual, "Roman Test: Conversion of X", "RomanToInteger_WhenInputIsX_Returns10 did not return the expected value");
        }

        private void RomanToInteger_WhenInputIsL_Returns50()
        {
            // Arrange
            string roman = "L";
            string expected = "50";
            // Act
            string actual = Roman.RomanToInteger(roman).ToString();

            TaskTests.AreEqual(expected, actual, "Roman Test: Conversion of L", "RomanToInteger_WhenInputIsL_Returns50 did not return the expected value");
        }

        private void RomanToInteger_WhenInputIsC_Returns100()
        {
            // Arrange
            string roman = "C";
            string expected = "100";
            // Act
            string actual = Roman.RomanToInteger(roman).ToString();

            TaskTests.AreEqual(expected, actual, "Roman Test: Conversion of C", "RomanToInteger_WhenInputIsC_Returns100 did not return the expected value");
        }

        private void RomanToInteger_WhenInputIsIV_Returns4()
        {
            // Arrange
            string roman = "IV";
            string expected = "4";
            // Act
            string actual = Roman.RomanToInteger(roman).ToString();

            TaskTests.AreEqual(expected, actual, "Roman Test: Conversion of IV", "RomanToInteger_WhenInputIsIV_Returns4 did not return the expected value");
        }

        private void RomanToInteger_WhenInputIsIX_Returns9()
        {
            // Arrange
            string roman = "IX";
            string expected = "9";
            // Act
            string actual = Roman.RomanToInteger(roman).ToString();

            TaskTests.AreEqual(expected, actual, "Roman Test: Conversion of IX", "RomanToInteger_WhenInputIsIX_Returns9 did not return the expected value");
        }

        private void RomanToInteger_WhenInputIsEmpty_Returns0()
        {
            // Arrange
            string roman = "";
            string expected = "0";
            // Act
            string actual = Roman.RomanToInteger(roman).ToString();

            TaskTests.AreEqual(expected, actual, "Roman Test: Conversion of Empty String", "RomanToInteger_WhenInputIsEmpty_Returns0 did not return the expected value");
        }

        private void RomanToInteger_WhenInputIsInvalid_Returns0()
        {
            // Arrange
            string roman = "Z";
            string expected = "0";
            // Act
            string actual = Roman.RomanToInteger(roman).ToString();

            TaskTests.AreEqual(expected, actual, "Roman Test: Invalid Roman Numeral", "RomanToInteger_WhenInputIsInvalid_ReturnsMinusOne did not return the expected value");
        }
    }
}