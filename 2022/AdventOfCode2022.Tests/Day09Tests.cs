using AdventOfCode2022.Day09;

namespace AdventOfCode2022.Tests
{
    public class Day09Tests
    {
        [Theory]
        [InlineData("Examples/Day09.txt", 13)]
        [InlineData("Input/Day09.txt", 5902)]
        public void CountTailPositionsTest(string inputPath, int expectedTailPositionsCount)
        {
            var input = File.ReadAllLines(inputPath);

            var tailPositionsCount = RopeMovementSimulator.CountTailPositions(input);
            Assert.Equal(expectedTailPositionsCount, tailPositionsCount);
        }
    }
}
