using TaskRepository;
using static Tests.SeriesTestConstants;

namespace Tests
{
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
            int[] series = Series123;
            string expected = Expected4;
            // Act
            string actual = Series.CalculateNextInSeries(series).ToString();

            TaskTests.AreEqual(expected, actual, TestTitle123, FailMessage123);
        }

        private void CalculateNextInSeries_WhenInputIs246_Returns8()
        {
            // Arrange
            int[] series = Series246;
            string expected = Expected8;
            // Act
            string actual = Series.CalculateNextInSeries(series).ToString();

            TaskTests.AreEqual(expected, actual, TestTitle246, FailMessage246);
        }

        private void CalculateNextInSeries_WhenInputIsEmpty_Returns0()
        {
            // Arrange
            int[] series = SeriesEmpty;
            string expected = Expected0;
            // Act
            string actual = Series.CalculateNextInSeries(series).ToString();

            TaskTests.AreEqual(expected, actual, TestTitleEmpty, FailMessageEmpty);
        }

        public void ParseParameters_WhenInputIsValid_ReturnsCorrectArray()
        {
            // Arrange
            string parameters = Parameters123;
            int[] expected = Expected123;
            // Act
            int[] actual = Series.ParseParameters(parameters);

            // Assert
            TaskTests.AreEqual(expected, actual, TestTitleParseParameters, FailMessageParseParameters);
        }

        public void ParseParameters_WhenInputIsInvalid_ReturnsEmptyArray()
        {
            // Arrange
            string parameters = Parameters123abc;
            int[] expected = ExpectedEmptyArray;
            // Act
            int[] actual = Series.ParseParameters(parameters);

            // Assert
            TaskTests.AreEqual(expected, actual, TestTitleParseInvalidParameters, FailMessageParseInvalidParameters);
        }
    }
}