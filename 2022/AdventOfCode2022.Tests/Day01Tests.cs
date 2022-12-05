using AdventOfCode2022.Day01;

namespace AdventOfCode2022.Tests
{
    public class Day01Tests
    {
        [Theory]
        [InlineData("Examples/Day01.txt", 24000, 45000)]
        [InlineData("Input/Day01.txt", 64929, 193697)]
        public void CountCaloriesTest(string inputPath, long expectedMaxCalories, long expectedTop3CumulatedCalories)
        {
            var input = File.ReadAllText(inputPath);

            var maxCalories = CaloriesCalculator.CalculateMaxCalories(input);

            Assert.Equal(expectedMaxCalories, maxCalories);

            var top3CumulatedCalories = CaloriesCalculator.CalculateTop3CumulatedCalories(input);

            Assert.Equal(expectedTop3CumulatedCalories, top3CumulatedCalories);
        }
    }
}