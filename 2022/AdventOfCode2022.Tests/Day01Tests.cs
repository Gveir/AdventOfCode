namespace AdventOfCode2022.Tests
{
    public class Day01Tests
    {
        [Fact]
        public void CountCaloriesTestExample()
        {
            var input = @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000";

            var maxCalories = CaloriesCalculator.CalculateMaxCalories(input);

            Assert.Equal(24000, maxCalories);
        }

        [Fact]
        public void CountCaloriesTestInput()
        {
            var input = File.ReadAllText("Input/Day01.txt");

            var maxCalories = CaloriesCalculator.CalculateMaxCalories(input);

            Assert.Equal(64929, maxCalories);
        }
    }
}