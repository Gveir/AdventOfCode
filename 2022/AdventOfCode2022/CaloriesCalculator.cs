namespace AdventOfCode2022
{
    public class CaloriesCalculator
    {
        public static long CalculateMaxCalories(string input) =>
            input.Split(Environment.NewLine + Environment.NewLine).Select(elf => CalculateElfsCalories(elf)).Max();

        private static long CalculateElfsCalories(string elfInventoryLines) =>
            elfInventoryLines.Split(Environment.NewLine).Select(i => long.Parse(i)).Aggregate(0L, (sum, i) => sum + i);
    }
}