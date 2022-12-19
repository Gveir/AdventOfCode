using AdventOfCode2022.Day18;

namespace AdventOfCode2022.Tests
{
    public class Day18Tests
    {
        [Theory]
        [InlineData("Examples/Day18.txt", 10)]
        [InlineData("Examples/Day18.2.txt", 64)]
        [InlineData("Input/Day18.txt", 4536)]
        public void CalculateSurfaceAreaTest(string inputPath, int expectedSurfaceArea)
        {
            var input = File.ReadAllLines(inputPath);

            var surfaceArea = LavaDropletAnalyzer.CalculateSurfaceArea(input);

            Assert.Equal(expectedSurfaceArea, surfaceArea);
        }

        [Theory]
        [InlineData("Examples/Day18.2.txt", 58)]
        [InlineData("Examples/Day18.extra.txt", 96)]
        [InlineData("Examples/Day18.extra2.txt", 112)]
        [InlineData("Examples/Day18.extra3.txt", 112)]
        [InlineData("Input/Day18.txt", 4536)]
        public void CalculateExteriorSurfaceAreaTest(string inputPath, int expectedSurfaceArea)
        {
            var input = File.ReadAllLines(inputPath);

            var surfaceArea = LavaDropletAnalyzer.CalculateExteriorSurfaceArea(input);

            Assert.Equal(expectedSurfaceArea, surfaceArea);
        }
    }
}
