using System.IO;
using Xunit;

namespace AdventOfCode10.Tests
{
    public class MonitoringStationTests
    {
        [Theory]
        [InlineData("Example1.txt", 33)]
        [InlineData("Example2.txt", 35)]
        [InlineData("Example3.txt", 41)]
        [InlineData("Example4.txt", 210)]
        [InlineData("Input.txt", 299)]
        public void FindBestAsteroid(string exampleFileName, int expectedLargestNumberOfOtherAsteroids)
        {
            var map = MapReader.FindAllAsteroids(File.ReadAllText(exampleFileName));

            BestPlace bestPlace = BestPlaceDetector.Determine(map);

            Assert.Equal(expectedLargestNumberOfOtherAsteroids, bestPlace.DetectionRatio);
        }
    }
}
