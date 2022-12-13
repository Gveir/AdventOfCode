using AdventOfCode2022.Day13;

namespace AdventOfCode2022.Tests
{
    public class Day13Tests
    {
        [Theory]
        [InlineData("Examples/Day13.txt", 13)]
        [InlineData("Input/Day13.txt", 391)]
        public void FindPacketsInRightOrderTest(string inputPath, int expectedSumOfPairsIndicesInRightOrder)
        {
            var input = File.ReadAllText(inputPath);

            var sumOfPairsIndicesInRightOrder = PacketsComparer.CalculateSumOfPairsIndicesInRightOrder(input);

            Assert.Equal(expectedSumOfPairsIndicesInRightOrder, sumOfPairsIndicesInRightOrder);
        }
    }
}
