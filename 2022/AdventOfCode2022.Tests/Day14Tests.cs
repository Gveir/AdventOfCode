using AdventOfCode2022.Day14;

namespace AdventOfCode2022.Tests
{
    public class Day14Tests
    {
        [Theory]
        [InlineData("Examples/Day14.txt", 24)]
        [InlineData("Input/Day14.txt", 979)]
        public void SimulateSandFallingIntoEndlessVoidTest(string inputPath, int expectedCountOfUnitsOfSandAtRest)
        {
            var input = File.ReadAllText(inputPath);

            var countOfUnitsOfSandAtRest = RegolithReservoirSimulator.CountUnitsOfSandAtRest(input);

            Assert.Equal(expectedCountOfUnitsOfSandAtRest, countOfUnitsOfSandAtRest);
        }
    }
}
