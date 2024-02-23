using static TaskRepository;

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
            int[] series = { 1, 2, 3 };
            string expected = "4";
            // Act
            var actual = Series.CalculateNextInSeries(series).ToString();

            TaskTests.AreEqual(expected, actual, "Series Test: Next in series of 1,2,3", "CalculateNextInSeries_WhenInputIs123_Returns4 did not return the expected value");
        }

        private void CalculateNextInSeries_WhenInputIs246_Returns8()
        {
            // Arrange
            int[] series = { 2, 4, 6 };
            string expected = "8";
            // Act
            var actual = Series.CalculateNextInSeries(series).ToString();

            TaskTests.AreEqual(expected, actual, "Series Test: Next in series of 2,4,6", "CalculateNextInSeries_WhenInputIs246_Returns8 did not return the expected value");
        }

        private void CalculateNextInSeries_WhenInputIsEmpty_Returns0()
        {
            // Arrange
            int[] series = { };
            string expected = "0";
            // Act
            var actual = Series.CalculateNextInSeries(series).ToString();

            TaskTests.AreEqual(expected, actual, "Series Test: Next in series of empty string", "CalculateNextInSeries_WhenInputIsEmpty_Returns0 did not return the expected value");
        }
        public void ParseParameters_WhenInputIsValid_ReturnsCorrectArray()
        {
            // Arrange
            string parameters = "1,2,3";
            int[] expected = { 1, 2, 3 };
            // Act
            var actual = Series.ParseParameters(parameters);

            // Assert
            TaskTests.AreEqual(expected, actual, "Series Test: Parse Parameters", "ParseParameters_WhenInputIsValid_ReturnsCorrectArray did not return the expected value");
        }

        public void ParseParameters_WhenInputIsInvalid_ReturnsEmptyArray()
        {
            // Arrange
            string parameters = "1,2,3,abc";
            int[] expected = { };
            // Act
            var actual = Series.ParseParameters(parameters);

            // Assert
            TaskTests.AreEqual(expected, actual, "Series Test: Parse Invalid Parameters", "ParseParameters_WhenInputIsInvalid_ReturnsEmptyArray did not return the expected value");
        }
    }
}