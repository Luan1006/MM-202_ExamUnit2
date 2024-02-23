using static Constants;

namespace TaskRepository
{
    public class Fahrenheit
    {
        private static readonly System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.InvariantCulture; // InvariantCulture is used to avoid issues with different cultures (e.g. comma vs. dot as decimal separator)
        public static string Run(Task task)
        {
            string celsius = FahrenheitToCelsius(task.parameters);

            Print.PrintTaskDetails(Text.TaskOne, task, celsius);

            return celsius;
        }

        public static string FahrenheitToCelsius(string fahrenheit)
        {

            float fahrenheitFloat;
            try
            {
                fahrenheitFloat = float.Parse(fahrenheit);
            }
            catch (FormatException)
            {
                return "Input must be a valid number.";
            }

            float celsius = (fahrenheitFloat - 32) * 5 / 9;

            return celsius.ToString(Text.TwoDecimal, culture);
        }

        public static System.Globalization.CultureInfo GetCultureInfo()
        {
            return culture;
        }
    }
}