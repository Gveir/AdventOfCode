using AdventOfCode2022.Day06;

namespace AdventOfCode2022.Tests
{
    public class Day06Tests
    {
        [Theory]
        [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
        [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
        [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
        [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
        [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
        public void FindFirstStartOfPacketMarkerTestExample(string input, int expectedFirstMarker)
        {
            var firstMarker = StartOfPacketMarkerFinder.FindFirst(input);

            Assert.Equal(expectedFirstMarker, firstMarker);
        }

        [Fact]
        public void FindFirstStartOfPacketMarkerTestInput()
        {
            var input = File.ReadAllText("Input/Day06.txt");

            var firstMarker = StartOfPacketMarkerFinder.FindFirst(input);

            Assert.Equal(1542, firstMarker);
        }
    }
}
