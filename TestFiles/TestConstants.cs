namespace Tests
{
    public class Constants
    {
        public const string TestsPassed = "Tests passed: ";
        public const string TestsFailed = "Tests failed: ";
        public const string TotalTime = "Total time: {0} ms\n";

        #region Fahrenheit

        #region FahrenheitTests Parameters

        public const string FahrenheitParameter32F = "32";
        public const string FahrenheitParameterNegative40F = "-40";
        public const string FahrenheitParameterZeroF = "0";
        public const string FahrenheitParameterNonNumeric = "abc";
        public const string FahrenheitParameterEmpty = "";

        #endregion

        #region FahrenheitTests Expected Values
        public const string FahrenheitExpected32 = "32";
        public const string FahrenheitExpected0F = "0.00";
        public const string FahrenheitExpectedNegative40F = "-40.00";
        public const string FahrenheitExpectedNegative17point78F = "-17.78";
        public const string FahrenheitExpectedErrorMessage = "Input must be a valid number.";
        #endregion

        #region FahrenheitTests Titles
        public const string FahrenheitTestCorrectParameter = "Fahrenheit Test: Correct Parameter";
        public const string FahrenheitTestInvariantCulture = "Fahrenheit Test: Invariant Culture";
        public const string FahrenheitTestConversionOf32F = "Fahrenheit Test: Conversion of 32F";
        public const string FahrenheitTestConversionOfNegative40F = "Fahrenheit Test: Conversion of -40F";
        public const string FahrenheitTestConversionOf0F = "Fahrenheit Test: Conversion of 0F";
        public const string FahrenheitTestConversionOfNonNumericF = "Fahrenheit Test: Conversion of non-numeric F";
        public const string FahrenheitTestConversionOfEmptyF = "Fahrenheit Test: Conversion of empty F";
        #endregion

        #region FahrenheitTests FailMessages
        public const string FahrenheitTestCorrectParameterDidNotReturnExpectedValue = "UsesCorrectParameter_ReturnsExpectedParameter did not return the expected value";
        public const string FahrenheitTestInvariantCultureDoesNotUseInvariantCulture = "GetCultureInfo_ReturnsInvariantCulture does not use InvariantCulture";
        public const string FahrenheitTestConversionOf32FDidNotReturnExpectedValue = "FahrenheitToCelsius_WhenInputIs32_Returns0 did not return the expected value";
        public const string FahrenheitTestConversionOfNegative40FDidNotReturnExpectedValue = "FahrenheitToCelsius_WhenInputIsNegative_ReturnsExpectedResult did not return the expected value";
        public const string FahrenheitTestConversionOf0FDidNotReturnExpectedValue = "FahrenheitToCelsius_WhenInputIsZero_ReturnsExpectedResult did not return the expected value";
        public const string FahrenheitTestConversionOfNonNumericFDidNotReturnExpectedValue = "FahrenheitToCelsius_WhenInputIsNonNumeric_ReturnsErrorMessage did not return the expected value";
        public const string FahrenheitTestConversionOfEmptyFDidNotReturnExpectedValue = "FahrenheitToCelsius_WhenInputIsEmpty_ReturnsErrorMessage did not return the expected value";
        #endregion

        #endregion
    }
}