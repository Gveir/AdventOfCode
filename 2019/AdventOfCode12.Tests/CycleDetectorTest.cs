using Xunit;

namespace AdventOfCode12.Tests
{
    public class CycleDetectorTest
    {
        [Theory]
        [InlineData("Example1.txt", 2772)]
        [InlineData("Example2.txt", 4686774924)]
        [InlineData("Input.txt", 320380285873116)]
        public void ExampleHistoryRepeatItselfTest(string fileName, long expectedSteps)
        {
            var exampleLoader = new AlternateExampleLoader(fileName);

            var cycleDetector = new CycleDetector(exampleLoader.MoonsPositions);

            var cycleSteps = cycleDetector.FindCycleSteps();

            Assert.Equal(expectedSteps, cycleSteps);
        }
    }
}
