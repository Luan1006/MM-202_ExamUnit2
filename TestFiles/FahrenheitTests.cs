using static TaskRepository;

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
            string expected = "32";
            // Act
            var actual = task.parameters;

            TaskTests.AreEqual(expected, actual, "Fahrenheit Test: Correct Parameter", "UsesCorrectParameter_ReturnsExpectedParameter did not return the expected value");
        }

        private void GetCultureInfo_ReturnsInvariantCulture()
        {
            // Arrange
            System.Globalization.CultureInfo expected = System.Globalization.CultureInfo.InvariantCulture;

            // Act
            var actual = Fahrenheit.GetCultureInfo();

            // Assert
            TaskTests.AreEqual(expected.ToString(), actual.ToString(), "Fahrenheit Test: Invariant Culture", "GetCultureInfo_ReturnsInvariantCulture does not use InvariantCulture");
        }

        private void FahrenheitToCelsius_WhenInputIs32_Returns0()
        {
            // Arrange
            string fahrenheit = "32";
            string expected = "0.00";
            // Act
            var actual = Fahrenheit.FahrenheitToCelsius(fahrenheit);

            TaskTests.AreEqual(expected, actual, "Fahrenheit Test: Conversion of 32F", "FahrenheitToCelsius_WhenInputIs32_Returns0 did not return the expected value");
        }

        private void FahrenheitToCelsius_WhenInputIsNegative_ReturnsExpectedResult()
        {
            // Arrange
            string fahrenheit = "-40";
            string expected = "-40.00";
            // Act
            var actual = Fahrenheit.FahrenheitToCelsius(fahrenheit);

            TaskTests.AreEqual(expected, actual, "Fahrenheit Test: Conversion of Negative Value", "FahrenheitToCelsius_WhenInputIsNegative_ReturnsExpectedResult did not return the expected value");
        }

        private void FahrenheitToCelsius_WhenInputIsZero_ReturnsExpectedResult()
        {
            // Arrange
            string fahrenheit = "0";
            string expected = "-17.78";
            // Act
            var actual = Fahrenheit.FahrenheitToCelsius(fahrenheit);

            TaskTests.AreEqual(expected, actual, "Fahrenheit Test: Conversion of 0F", "FahrenheitToCelsius_WhenInputIsZero_ReturnsExpectedResult did not return the expected value");
        }

        private void FahrenheitToCelsius_WhenInputIsNonNumeric_ReturnsErrorMessage()
        {
            // Arrange
            string fahrenheit = "abc";
            string expected = "Input must be a valid number.";

            // Act
            var actual = Fahrenheit.FahrenheitToCelsius(fahrenheit);

            TaskTests.AreEqual(expected, actual, "Fahrenheit Test: Non-Numeric Input", "FahrenheitToCelsius_WhenInputIsNonNumeric_ReturnsErrorMessage did not return the expected error message");
        }

        private void FahrenheitToCelsius_WhenInputIsEmpty_ReturnsErrorMessage()
        {
            // Arrange
            string fahrenheit = "";
            string expected = "Input must be a valid number.";

            // Act
            var actual = Fahrenheit.FahrenheitToCelsius(fahrenheit);

            TaskTests.AreEqual(expected, actual, "Fahrenheit Test: Empty Input", "FahrenheitToCelsius_WhenInputIsEmpty_ReturnsErrorMessage did not return the expected error message");
        }
    }
}