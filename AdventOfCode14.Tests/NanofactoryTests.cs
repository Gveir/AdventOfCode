using Xunit;

namespace AdventOfCode14.Tests
{
    public class NanofactoryTests
    {
        [Theory]
        [InlineData("Example1.txt", 31)]
        [InlineData("Example2.txt", 165)]
        [InlineData("Example3.txt", 13312)]
        [InlineData("Example4.txt", 180697)]
        [InlineData("Example5.txt", 2210736)]
        [InlineData("Input.txt", 365768)]
        public void MinimumOreForOneFuelTest(string fileName, int expectedOre)
        {
            var nanofactory = new Nanofactory(fileName);

            Assert.Equal(expectedOre, nanofactory.MinimumOreForOneFuel());
        }
    }
}
