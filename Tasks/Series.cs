using static Constants;

namespace TaskRepository
{
    public class Series
    {
        public static string Run(Task task)
        {
            int[] series = ParseParameters(task.parameters);
            int answer = CalculateNextInSeries(series);

            Print.PrintTaskDetails(Text.TaskFour, task, answer.ToString());

            return answer.ToString();
        }

        public static int[] ParseParameters(string parameters)
        {
            int[] series;
            try
            {
                series = parameters.Split(Text.CharComma).Select(int.Parse).ToArray();
            }
            catch (FormatException)
            {
                series = [];
            }

            return series;
        }

        public static int CalculateNextInSeries(int[] series)
        {
            if (series.Length < 2)
            {
                return 0;
            }

            int lastInSeries = series[series.Length - 1];
            int secondLastInSeries = series[series.Length - 2];

            return lastInSeries * 2 - secondLastInSeries;
        }
    }
}