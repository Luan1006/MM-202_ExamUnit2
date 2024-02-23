using System.Globalization;
using TaskRepository;
using static Tests.FahrenheitTestConstants;

namespace Tests
{
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

        private void UsesCorrectParameter_ReturnsExpectedParameter()
        {
            // Arrange
            string jsonContent = "{\"title\":\"Fahrenheit to Celsius\",\"description\":\"Converts a temperature in Fahrenheit to Celsius\",\"taskID\":\"1\",\"usierID\":\"1\",\"parameters\":\"32\",\"Message\":\"\",\"got\":\"\",\"expected\":\"0.00\"}";
            Task task = new Task(jsonContent);
            string expected = FahrenheitExpected32;
            // Act
            string actual = task.parameters;

            TaskTests.AreEqual(expected, actual, FahrenheitTestCorrectParameter, FahrenheitTestCorrectParameterDidNotReturnExpectedValue);
        }

        private void GetCultureInfo_ReturnsInvariantCulture()
        {
            // Arrange
            CultureInfo expected = CultureInfo.InvariantCulture;

            // Act
            CultureInfo actual = Fahrenheit.GetCultureInfo();

            // Assert
            TaskTests.AreEqual(expected.ToString(), actual.ToString(), FahrenheitTestInvariantCulture, FahrenheitTestInvariantCultureDoesNotUseInvariantCulture);
        }

        private void FahrenheitToCelsius_WhenInputIs32_Returns0()
        {
            // Arrange
            string fahrenheit = FahrenheitParameter32F;
            string expected = FahrenheitExpected0F;
            // Act
            string actual = Fahrenheit.FahrenheitToCelsius(fahrenheit);

            TaskTests.AreEqual(expected, actual, FahrenheitTestConversionOf32F, FahrenheitTestConversionOf32FDidNotReturnExpectedValue);
        }

        private void FahrenheitToCelsius_WhenInputIsNegative_ReturnsExpectedResult()
        {
            // Arrange
            string fahrenheit = FahrenheitParameterNegative40F;
            string expected = FahrenheitExpectedNegative40F;
            // Act
            var actual = Fahrenheit.FahrenheitToCelsius(fahrenheit);

            TaskTests.AreEqual(expected, actual, FahrenheitTestConversionOfNegative40F, FahrenheitTestConversionOfNegative40FDidNotReturnExpectedValue);
        }

        private void FahrenheitToCelsius_WhenInputIsZero_ReturnsExpectedResult()
        {
            // Arrange
            string fahrenheit = FahrenheitParameterZeroF;
            string expected = FahrenheitExpectedNegative17point78F;
            // Act
            string actual = Fahrenheit.FahrenheitToCelsius(fahrenheit);

            TaskTests.AreEqual(expected, actual, FahrenheitTestConversionOf0F, FahrenheitTestConversionOf0FDidNotReturnExpectedValue);
        }

        private void FahrenheitToCelsius_WhenInputIsNonNumeric_ReturnsErrorMessage()
        {
            // Arrange
            string fahrenheit = FahrenheitParameterNonNumeric;
            string expected = FahrenheitExpectedErrorMessage;

            // Act
            var actual = Fahrenheit.FahrenheitToCelsius(fahrenheit);

            TaskTests.AreEqual(expected, actual, FahrenheitTestConversionOfNonNumericF, FahrenheitTestConversionOfNonNumericFDidNotReturnExpectedValue);
        }

        private void FahrenheitToCelsius_WhenInputIsEmpty_ReturnsErrorMessage()
        {
            // Arrange
            string fahrenheit = FahrenheitParameterEmpty;
            string expected = FahrenheitExpectedErrorMessage;

            // Act
            string actual = Fahrenheit.FahrenheitToCelsius(fahrenheit);

            TaskTests.AreEqual(expected, actual, FahrenheitTestConversionOfEmptyF, FahrenheitTestConversionOfEmptyFDidNotReturnExpectedValue);
        }
    }
}