namespace Tests
{
    public class Constants
    {
        public const string TestsPassed = "Tests passed: ";
        public const string TestsFailed = "Tests failed: ";
        public const string TotalTime = "Total time: {0} ms\n";
    }

    public class FahrenheitTestConstants
    {

        #region Parameters

        public const string FahrenheitParameter32F = "32";
        public const string FahrenheitParameterNegative40F = "-40";
        public const string FahrenheitParameterZeroF = "0";
        public const string FahrenheitParameterNonNumeric = "abc";
        public const string FahrenheitParameterEmpty = "";

        #endregion

        #region Expected Values
        public const string FahrenheitExpected32 = "32";
        public const string FahrenheitExpected0F = "0.00";
        public const string FahrenheitExpectedNegative40F = "-40.00";
        public const string FahrenheitExpectedNegative17point78F = "-17.78";
        public const string FahrenheitExpectedErrorMessage = "Input must be a valid number.";
        #endregion

        #region Titles
        public const string FahrenheitTestCorrectParameter = "Fahrenheit Test: Correct Parameter";
        public const string FahrenheitTestInvariantCulture = "Fahrenheit Test: Invariant Culture";
        public const string FahrenheitTestConversionOf32F = "Fahrenheit Test: Conversion of 32F";
        public const string FahrenheitTestConversionOfNegative40F = "Fahrenheit Test: Conversion of -40F";
        public const string FahrenheitTestConversionOf0F = "Fahrenheit Test: Conversion of 0F";
        public const string FahrenheitTestConversionOfNonNumericF = "Fahrenheit Test: Conversion of non-numeric F";
        public const string FahrenheitTestConversionOfEmptyF = "Fahrenheit Test: Conversion of empty F";
        #endregion

        #region Fail Messages
        public const string FahrenheitTestCorrectParameterDidNotReturnExpectedValue = "UsesCorrectParameter_ReturnsExpectedParameter did not return the expected value";
        public const string FahrenheitTestInvariantCultureDoesNotUseInvariantCulture = "GetCultureInfo_ReturnsInvariantCulture does not use InvariantCulture";
        public const string FahrenheitTestConversionOf32FDidNotReturnExpectedValue = "FahrenheitToCelsius_WhenInputIs32_Returns0 did not return the expected value";
        public const string FahrenheitTestConversionOfNegative40FDidNotReturnExpectedValue = "FahrenheitToCelsius_WhenInputIsNegative_ReturnsExpectedResult did not return the expected value";
        public const string FahrenheitTestConversionOf0FDidNotReturnExpectedValue = "FahrenheitToCelsius_WhenInputIsZero_ReturnsExpectedResult did not return the expected value";
        public const string FahrenheitTestConversionOfNonNumericFDidNotReturnExpectedValue = "FahrenheitToCelsius_WhenInputIsNonNumeric_ReturnsErrorMessage did not return the expected value";
        public const string FahrenheitTestConversionOfEmptyFDidNotReturnExpectedValue = "FahrenheitToCelsius_WhenInputIsEmpty_ReturnsErrorMessage did not return the expected value";
        #endregion
    }

    public class PrimeNumbersTestsConstants
    {
        public const string Comma = ",";
        #region Parameters
        public const string ValidParameters = "2,3,4,5,6,7,8,9,10";
        public static readonly int[] ValidSequence = { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public const string InvalidParameters = "2,3,4,abc,6,7,8,9,10";
        public static readonly int[] InvalidSequence = { 1, 4, 6, 8, 9, 10 };
        #endregion

        #region Expected Results
        public const string ExpectedValidParameters = "2,3,4,5,6,7,8,9,10";
        public const string ExpectedInvalidParameters = "";
        public const string ExpectedValidSequencePrimes = "2,3,5,7";
        public const string ExpectedInvalidSequencePrimes = "";
        #endregion

        #region Test Titles
        public const string ParseValidParametersTestTitle = "PrimeNumbers Test: Parse Valid Parameters";
        public const string ParseInvalidParametersTestTitle = "PrimeNumbers Test: Parse Invalid Parameters";
        public const string GetPrimesFromValidSequenceTestTitle = "PrimeNumbers Test: Get Primes from Valid Sequence";
        public const string GetPrimesFromInvalidSequenceTestTitle = "PrimeNumbers Test: Get Primes from Invalid Sequence";
        #endregion

        #region Fail Messages
        public const string ParseValidParametersFailMessage = "Did not return the expected number sequence";
        public const string ParseInvalidParametersFailMessage = "Did not return an empty list";
        public const string GetPrimesFromValidSequenceFailMessage = "Did not return the expected prime numbers";
        public const string GetPrimesFromInvalidSequenceFailMessage = "Did not return an empty list";
        #endregion
    }

    public class RomanTestConstants
    {
        #region Roman Numerals
        public const string RomanI = "I";
        public const string RomanV = "V";
        public const string RomanX = "X";
        public const string RomanL = "L";
        public const string RomanC = "C";
        public const string RomanIV = "IV";
        public const string RomanIX = "IX";
        public const string RomanEmpty = "";
        public const string RomanInvalid = "Z";
        #endregion

        #region Expected Results
        public const string ExpectedI = "1";
        public const string ExpectedV = "5";
        public const string ExpectedX = "10";
        public const string ExpectedL = "50";
        public const string ExpectedC = "100";
        public const string ExpectedIV = "4";
        public const string ExpectedIX = "9";
        public const string ExpectedEmpty = "0";
        public const string ExpectedInvalid = "0";
        #endregion

        #region Test Titles
        public const string TestTitleI = "Roman Test: Conversion of I";
        public const string TestTitleV = "Roman Test: Conversion of V";
        public const string TestTitleX = "Roman Test: Conversion of X";
        public const string TestTitleL = "Roman Test: Conversion of L";
        public const string TestTitleC = "Roman Test: Conversion of C";
        public const string TestTitleIV = "Roman Test: Conversion of IV";
        public const string TestTitleIX = "Roman Test: Conversion of IX";
        public const string TestTitleEmpty = "Roman Test: Conversion of Empty String";
        public const string TestTitleInvalid = "Roman Test: Invalid Roman Numeral";
        #endregion

        #region Fail Messages
        public const string FailMessageI = "RomanToInteger_WhenInputIsI_Returns1 did not return the expected value";
        public const string FailMessageV = "RomanToInteger_WhenInputIsV_Returns5 did not return the expected value";
        public const string FailMessageX = "RomanToInteger_WhenInputIsX_Returns10 did not return the expected value";
        public const string FailMessageL = "RomanToInteger_WhenInputIsL_Returns50 did not return the expected value";
        public const string FailMessageC = "RomanToInteger_WhenInputIsC_Returns100 did not return the expected value";
        public const string FailMessageIV = "RomanToInteger_WhenInputIsIV_Returns4 did not return the expected value";
        public const string FailMessageIX = "RomanToInteger_WhenInputIsIX_Returns9 did not return the expected value";
        public const string FailMessageEmpty = "RomanToInteger_WhenInputIsEmpty_Returns0 did not return the expected value";
        public const string FailMessageInvalid = "RomanToInteger_WhenInputIsInvalid_ReturnsMinusOne did not return the expected value";
        #endregion
    }

    public class SeriesTestConstants
    {
        #region Series
        public static readonly int[] Series123 = { 1, 2, 3 };
        public static readonly int[] Series246 = { 2, 4, 6 };
        public static readonly int[] SeriesEmpty = { };
        #endregion

        #region Expected Values
        public const string Expected4 = "4";
        public const string Expected8 = "8";
        public const string Expected0 = "0";
        public static readonly int[] Expected123 = { 1, 2, 3 };
        public static readonly int[] ExpectedEmptyArray = { };
        #endregion

        #region Parameters
        public const string Parameters123 = "1,2,3";
        public const string Parameters123abc = "1,2,3,abc";
        #endregion

        #region Test Titles
        public const string TestTitle123 = "Series Test: Next in series of 1,2,3";
        public const string TestTitle246 = "Series Test: Next in series of 2,4,6";
        public const string TestTitleEmpty = "Series Test: Next in series of empty string";
        public const string TestTitleParseParameters = "Series Test: Parse Parameters";
        public const string TestTitleParseInvalidParameters = "Series Test: Parse Invalid Parameters";
        #endregion

        #region Fail Messages
        public const string FailMessage123 = "CalculateNextInSeries_WhenInputIs123_Returns4 did not return the expected value";
        public const string FailMessage246 = "CalculateNextInSeries_WhenInputIs246_Returns8 did not return the expected value";
        public const string FailMessageEmpty = "CalculateNextInSeries_WhenInputIsEmpty_Returns0 did not return the expected value";
        public const string FailMessageParseParameters = "ParseParameters_WhenInputIsValid_ReturnsCorrectArray did not return the expected value";
        public const string FailMessageParseInvalidParameters = "ParseParameters_WhenInputIsInvalid_ReturnsEmptyArray did not return the expected value";
        #endregion
    }
}