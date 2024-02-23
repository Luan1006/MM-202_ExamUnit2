using TaskRepository;
using static Tests.RomanTestConstants;

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
            string roman = RomanI;
            string expected = ExpectedI;
            // Act
            string actual = Roman.RomanToInteger(roman).ToString();

            TaskTests.AreEqual(expected, actual, TestTitleI, FailMessageI);
        }

        private void RomanToInteger_WhenInputIsV_Returns5()
        {
            // Arrange
            string roman = RomanV;
            string expected = ExpectedV;
            // Act
            string actual = Roman.RomanToInteger(roman).ToString();

            TaskTests.AreEqual(expected, actual, TestTitleV, FailMessageV);
        }

        private void RomanToInteger_WhenInputIsX_Returns10()
        {
            // Arrange
            string roman = RomanX;
            string expected = ExpectedX;
            // Act
            string actual = Roman.RomanToInteger(roman).ToString();

            TaskTests.AreEqual(expected, actual, TestTitleX, FailMessageX);
        }

        private void RomanToInteger_WhenInputIsL_Returns50()
        {
            // Arrange
            string roman = RomanL;
            string expected = ExpectedL;
            // Act
            string actual = Roman.RomanToInteger(roman).ToString();

            TaskTests.AreEqual(expected, actual, TestTitleL, FailMessageL);
        }

        private void RomanToInteger_WhenInputIsC_Returns100()
        {
            // Arrange
            string roman = RomanC;
            string expected = ExpectedC;
            // Act
            string actual = Roman.RomanToInteger(roman).ToString();

            TaskTests.AreEqual(expected, actual, TestTitleC, FailMessageC);
        }

        private void RomanToInteger_WhenInputIsIV_Returns4()
        {
            // Arrange
            string roman = RomanIV;
            string expected = ExpectedIV;
            // Act
            string actual = Roman.RomanToInteger(roman).ToString();

            TaskTests.AreEqual(expected, actual, TestTitleIV, FailMessageIV);
        }

        private void RomanToInteger_WhenInputIsIX_Returns9()
        {
            // Arrange
            string roman = RomanIX;
            string expected = ExpectedIX;
            // Act
            string actual = Roman.RomanToInteger(roman).ToString();

            TaskTests.AreEqual(expected, actual, TestTitleIX, FailMessageIX);
        }

        private void RomanToInteger_WhenInputIsEmpty_Returns0()
        {
            // Arrange
            string roman = RomanEmpty;
            string expected = ExpectedEmpty;
            // Act
            string actual = Roman.RomanToInteger(roman).ToString();

            TaskTests.AreEqual(expected, actual, TestTitleEmpty, FailMessageEmpty);
        }

        private void RomanToInteger_WhenInputIsInvalid_Returns0()
        {
            // Arrange
            string roman = RomanInvalid;
            string expected = ExpectedInvalid;
            // Act
            string actual = Roman.RomanToInteger(roman).ToString();

            TaskTests.AreEqual(expected, actual, TestTitleInvalid, FailMessageInvalid);
        }
    }
}