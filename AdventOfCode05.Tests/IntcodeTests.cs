using AdventOfCode02;
using Xunit;

namespace AdventOfCode05.Tests
{
    public class IntcodeTests
    {
        [Fact]
        public void TestNewIntructions()
        {
            var intcode = new Intcode("3,0,4,0,99", 42);

            intcode.Process();

            Assert.Equal(42, intcode.Output);
        }
    }
}
