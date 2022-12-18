using AdventOfCode2022.Day18;

namespace AdventOfCode2022.Tests
{
    public class Day18Tests
    {
        [Theory]
        [InlineData("Examples/Day18.txt", 10)]
        [InlineData("Examples/Day18.2.txt", 64)]
        [InlineData("Input/Day18.txt", 4536)]
        public void Test(string inputPath, int expectedSurfaceArea)
        {
            var input = File.ReadAllLines(inputPath);

            var surfaceArea = LavaDropletAnalyzer.CalculateSurfaceArea(input);

            Assert.Equal(expectedSurfaceArea, surfaceArea);
        }
    }
}
