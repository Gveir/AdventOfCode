using AdventOfCode2022.Day12;

namespace AdventOfCode2022.Tests
{
    public class Day12Tests
    {
        [Theory]
        [InlineData("Examples/Day12.txt", 31)]
        [InlineData("Input/Day12.txt", 391)]
        public void FindShortestPathLengthTest(string inputPath, int expectedPathLength)
        {
            var input = File.ReadAllLines(inputPath);

            var shortestPathLength = PathFinder.FindShortestPathLength(input);

            Assert.Equal(expectedPathLength, shortestPathLength);
        }

        [Theory]
        [InlineData("Examples/Day12.txt", 29)]
        [InlineData("Input/Day12.txt", 386)]
        public void FindShortestPathLengthFromAnySquareWithElevationATest(string inputPath, int expectedPathLength)
        {
            var input = File.ReadAllLines(inputPath);

            var shortestPathLength = PathFinder.FindShortestPathLengthFromAnyGridSquareWithElevation(input, 'a');

            Assert.Equal(expectedPathLength, shortestPathLength);
        }
    }
}
