using AdventOfCode2022.Day02;

namespace AdventOfCode2022.Tests
{
    public class Day02Tests
    {
        [Theory]
        [InlineData("Examples/Day02.txt", 15)]
        [InlineData("Input/Day02.txt", 12458)]
        public void CalculateTotalScoreTest(string inputPath, int expectedTotalScore)
        {
            var input = File.ReadAllText(inputPath);

            var totalScore = RPSCalculator.CalculateTotalScore(input);

            Assert.Equal(expectedTotalScore, totalScore);
        }

        [Theory]
        [InlineData("Examples/Day02.txt", 12)]
        [InlineData("Input/Day02.txt", 12683)]
        public void StrategyGuideScoreTes(string inputPath, int expectedTotalScore)
        {
            var input = File.ReadAllText(inputPath);

            var totalScore = RPSCalculator.CalculateStrategyGuideScore(input);

            Assert.Equal(expectedTotalScore, totalScore);
        }
    }
}
