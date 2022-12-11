using AdventOfCode2022.Day11;

namespace AdventOfCode2022.Tests
{
    public class Day11Tests
    {
        [Theory]
        [InlineData("Examples/Day11.txt", 10605)]
        [InlineData("Input/Day11.txt", 57348)]
        public void FindMonkeyBusiness(string inputPath, int expectedMonkeyBusiness)
        {
            var input = File.ReadAllText(inputPath);

            var monkeyBusiness = KeepAwaySimulator.FindMonkeyBusiness(input);

            Assert.Equal(expectedMonkeyBusiness, monkeyBusiness);
        }
    }
}
