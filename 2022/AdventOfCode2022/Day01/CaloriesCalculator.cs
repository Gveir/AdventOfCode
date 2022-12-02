namespace AdventOfCode2022.Day01
{
    public class CaloriesCalculator
    {
        public static long CalculateMaxCalories(string input) =>
            CalculateElvesCalories(input).Max();

        public static long CalculateTop3CumulatedCalories(string input) =>
            CalculateElvesCalories(input).OrderByDescending(x => x).Take(3).Sum();

        private static IEnumerable<long> CalculateElvesCalories(string input) =>
            input.Split(Environment.NewLine + Environment.NewLine).Select(CalculateElfsCalories);

        private static long CalculateElfsCalories(string elfInventoryLines) =>
            elfInventoryLines.Split(Environment.NewLine).Select(long.Parse).Sum();
    }
}