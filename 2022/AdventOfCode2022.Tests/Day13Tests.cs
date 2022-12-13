using AdventOfCode2022.Day13;

namespace AdventOfCode2022.Tests
{
    public class Day13Tests
    {
        [Theory]
        [InlineData("Examples/Day13.txt", 13)]
        [InlineData("Input/Day13.txt", 5185)]
        public void FindPacketsInRightOrderTest(string inputPath, int expectedSumOfPairsIndicesInRightOrder)
        {
            var input = File.ReadAllText(inputPath);

            var sumOfPairsIndicesInRightOrder = new PacketsComparer().CalculateSumOfPairsIndicesInRightOrder(input);

            Assert.Equal(expectedSumOfPairsIndicesInRightOrder, sumOfPairsIndicesInRightOrder);
        }

        [Theory]
        [InlineData("Examples/Day13.txt", 140)]
        [InlineData("Input/Day13.txt", 23751)]
        public void CalculateDecoderKeyTest(string inputPath, int expectedDecoderKey)
        {
            var input = File.ReadAllText(inputPath);

            var decoderKey = new PacketsComparer().CalculateDecoderKey(input, new[] { "[[2]]", "[[6]]" });

            Assert.Equal(expectedDecoderKey, decoderKey);
        }
    }
}
