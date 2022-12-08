using AdventOfCode2022.Day07;

namespace AdventOfCode2022.Tests
{
    public class Day07Tests
    {
        [Theory]
        [InlineData("Examples/Day07.txt", 95437)]
        [InlineData("Input/Day07.txt", 1908462)]
        public void TotalSizeOfDirectoriesTest(string inputPath, int expectedSize)
        {
            var input = File.ReadAllLines(inputPath);
            const int sizeAtMost = 100000;

            var size = DirectoryCrawler.SumOfTotalSizesOfDirs(input, sizeAtMost);

            Assert.Equal(expectedSize, size);
        }

        [Theory]
        [InlineData("Examples/Day07.txt", 24933642)]
        [InlineData("Input/Day07.txt", 3979145)]
        public void FindDirectoryToDelete(string inputPath, int expectedMinDirectorySize)
        {
            var input = File.ReadAllLines(inputPath);
            int diskSize = 70000000;
            int requiredUnusedSpace = 30000000;

            var minDirectorySize = DirectoryCrawler.ChooseDirectoryToDelete(input, diskSize, requiredUnusedSpace);

            Assert.Equal(expectedMinDirectorySize, minDirectorySize);
        }
    }
}
