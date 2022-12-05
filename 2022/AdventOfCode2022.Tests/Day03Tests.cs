using AdventOfCode2022.Day03;

namespace AdventOfCode2022.Tests
{
    public class Day03Tests
    {
        [Theory]
        [InlineData("Examples/Day03.txt", 157)]
        [InlineData("Input/Day03.txt", 7581)]
        public void PrioritySumTest(string inputPath, int expectedPrioritiesSum)
        {
            var input = File.ReadAllText(inputPath);

            var prioritiesSum = PriorityAccumulator.CalculatePrioritySum(input);

            Assert.Equal(expectedPrioritiesSum, prioritiesSum);
        }

        [Theory]
        [InlineData("aa", 1)]
        [InlineData("zz", 26)]
        [InlineData("AA", 27)]
        [InlineData("ZZ", 52)]
        public void PrioritySumSingleItemTest(string input, int expectedPrioritiesSum)
        {
            var prioritiesSum = PriorityAccumulator.CalculatePrioritySum(input);

            Assert.Equal(expectedPrioritiesSum, prioritiesSum);
        }

        [Theory]
        [InlineData("Examples/Day03.txt", 70)]
        [InlineData("Input/Day03.txt", 2525)]
        public void BadgePrioritySumTest(string inputPath, int expectedPrioritiesSum)
        {
            var input = File.ReadAllText(inputPath);

            var prioritiesSum = PriorityAccumulator.CalculateBadgeSum(input);

            Assert.Equal(expectedPrioritiesSum, prioritiesSum);
        }
    }
}
