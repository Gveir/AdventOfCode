using AdventOfCode2022.Day05;

namespace AdventOfCode2022.Tests
{
    public class Day05Tests
    {
        [Theory]
        [InlineData("Examples/Day05.txt", "CMZ")]
        [InlineData("Input/Day05.txt", "QNNTGTPFN")]
        public void CrateMover9000RearrangementTest(string inputPath, string expectedTopCrates)
        {
            var input = File.ReadAllText(inputPath);

            var topCrates = new CrateMover9000RearrangementProcessor().Process(input);

            Assert.Equal(expectedTopCrates, topCrates);
        }

        [Theory]
        [InlineData("Examples/Day05.txt", "MCD")]
        [InlineData("Input/Day05.txt", "GGNPJBTTR")]
        public void CrateMover9001RearrangementTest(string inputPath, string expectedTopCrates)
        {
            var input = File.ReadAllText(inputPath);

            var topCrates = new CrateMover9001RearrangementProcessor().Process(input);

            Assert.Equal(expectedTopCrates, topCrates);
        }
    }
}
