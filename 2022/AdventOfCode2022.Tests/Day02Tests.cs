using AdventOfCode2022.Day02;

namespace AdventOfCode2022.Tests
{
    public class Day02Tests
    {
        [Fact]
        public void CalculateTotalScoreTestExample()
        {
            var input = @"A Y
B X
C Z";

            var totalScore = RPSCalculator.CalculateTotalScore(input);

            Assert.Equal(15, totalScore);
        }

        [Fact]
        public void CalculateTotalScoreTestInput()
        {
            var input = File.ReadAllText("Input/Day02.txt");

            var totalScore = RPSCalculator.CalculateTotalScore(input);

            Assert.Equal(12458, totalScore);
        }

        [Fact]
        public void StrategyGuideScoreTestExample()
        {
            var input = @"A Y
B X
C Z";

            var totalScore = RPSCalculator.CalculateStrategyGuideScore(input);

            Assert.Equal(12, totalScore);
        }

        [Fact]
        public void StrategyGuideScoreTestInput()
        {
            var input = File.ReadAllText("Input/Day02.txt");

            var totalScore = RPSCalculator.CalculateStrategyGuideScore(input);

            Assert.Equal(12683, totalScore);
        }
    }
}
