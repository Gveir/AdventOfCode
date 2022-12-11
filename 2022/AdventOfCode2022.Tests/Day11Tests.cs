using AdventOfCode2022.Day11;

namespace AdventOfCode2022.Tests
{
    public class Day11Tests
    {
        [Theory]
        [InlineData("Examples/Day11.txt", 10605)]
        [InlineData("Input/Day11.txt", 57348)]
        public void FindMonkeyBusiness(string inputPath, ulong expectedMonkeyBusiness)
        {
            var input = File.ReadAllText(inputPath);
            const int NumberOfRounds = 20;
            
            var monkeyBusiness = new KeepAwaySimulator().FindMonkeyBusiness(input, NumberOfRounds);

            Assert.Equal(expectedMonkeyBusiness, monkeyBusiness);
        }

        [Theory]
        [InlineData("Examples/Day11.txt", 2713310158)]
        [InlineData("Input/Day11.txt", 14106266886)]
        public void FindMonkeyBusinessNoRelief(string inputPath, ulong expectedMonkeyBusiness)
        {
            var input = File.ReadAllText(inputPath);
            const int NumberOfRounds = 10000;
            
            var monkeyBusiness = new KeepAwaySimulator(applyRelief: false).FindMonkeyBusiness(input, NumberOfRounds);

            Assert.Equal(expectedMonkeyBusiness, monkeyBusiness);
        }
    }
}
