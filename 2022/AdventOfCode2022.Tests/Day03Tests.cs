using AdventOfCode2022.Day03;

namespace AdventOfCode2022.Tests
{
    public class Day03Tests
    {
        [Fact]
        public void PrioritySumTestExample()
        {
            var input = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";

            var prioritiesSum = PriorityAccumulator.CalculatePrioritySum(input);

            Assert.Equal(157, prioritiesSum);
        }

        [Theory]
        [InlineData("aa", 1)]
        [InlineData("zz", 26)]
        [InlineData("AA", 27)]
        [InlineData("ZZ", 52)]
        public void PrioritySumTestSingleItem(string input, int expectedPrioritySum)
        {
            var prioritiesSum = PriorityAccumulator.CalculatePrioritySum(input);

            Assert.Equal(expectedPrioritySum, prioritiesSum);
        }

        [Fact]
        public void PrioritySumTestInput()
        {
            var input = File.ReadAllText("Input/Day03.txt");

            var prioritiesSum = PriorityAccumulator.CalculatePrioritySum(input);

            Assert.Equal(7581, prioritiesSum);
        }

        [Fact]
        public void BadgePrioritySumTestExample()
        {
            var input = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";

            var prioritiesSum = PriorityAccumulator.CalculateBadgeSum(input);

            Assert.Equal(70, prioritiesSum);
        }

        [Fact]
        public void BadgePrioritySumTestInput()
        {
            var input = File.ReadAllText("Input/Day03.txt");

            var prioritiesSum = PriorityAccumulator.CalculateBadgeSum(input);

            Assert.Equal(2525, prioritiesSum);
        }
    }
}
