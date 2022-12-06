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
            var firstMarker = MarkerFinder.FindFirstStartOfPacket(input);

            Assert.Equal(expectedFirstMarker, firstMarker);
        }

        [Fact]
        public void FindFirstStartOfPacketMarkerTestInput()
        {
            var input = File.ReadAllText("Input/Day06.txt");

            var firstMarker = MarkerFinder.FindFirstStartOfPacket(input);

            Assert.Equal(1542, firstMarker);
        }

        [Theory]
        [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
        [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
        [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
        [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
        [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
        public void FindFirstStartOfMessageMarkerTestExample(string input, int expectedFirstMarker)
        {
            var firstMarker = MarkerFinder.FindFirstStartOfMessage(input);

            Assert.Equal(expectedFirstMarker, firstMarker);
        }

        [Fact]
        public void FindFirstStartOfMessageMarkerTestInput()
        {
            var input = File.ReadAllText("Input/Day06.txt");

            var firstMarker = MarkerFinder.FindFirstStartOfMessage(input);

            Assert.Equal(3153, firstMarker);
        }
    }
}
