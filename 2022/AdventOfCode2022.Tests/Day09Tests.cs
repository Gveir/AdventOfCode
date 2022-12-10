using AdventOfCode2022.Day09;

namespace AdventOfCode2022.Tests
{
    public class Day09Tests
    {
        [Theory]
        [InlineData("Examples/Day09.txt", 2, 13)]
        [InlineData("Input/Day09.txt", 2, 5902)]
        [InlineData("Examples/Day09.txt", 10, 1)]
        [InlineData("Examples/Day09.2.txt", 10, 36)]
        [InlineData("Input/Day09.txt", 10, 2445)]
        public void CountPositionsVisitedByTailTest(string inputPath, int ropeLength, int expectedPositionsVisitedByTailCount)
        {
            var input = File.ReadAllLines(inputPath);

            var positionsVisitedByTailCount = RopeMovementSimulator.CountPositionsVisitedByTail(input, ropeLength);
            Assert.Equal(expectedPositionsVisitedByTailCount, positionsVisitedByTailCount);
        }
    }
}
