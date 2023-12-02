namespace AdventOfCode2023.Tests
{
    public class Day01Tests
    {
        [Theory]
        [InlineData("Examples/Day01.1.txt", 142)]
        [InlineData("Examples/Day01.2.txt", 281)]
        [InlineData("Input/Day01.txt", 54676)]
        public async Task SumAllCalibrationValuesTest(string inputPath, long expectedSum)
        {
            var input = await File.ReadAllTextAsync(inputPath);

            var sumOfCalibrationValues = Day01.Solution.CalculateSumOfCalibrationValues(input);

            Assert.Equal(expectedSum, sumOfCalibrationValues);
        }
    }
}