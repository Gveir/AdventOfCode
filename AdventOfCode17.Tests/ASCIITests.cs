using System.IO;
using TestHelpers;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode17.Tests
{
    public class ASCIITests
    {
        private readonly ITestOutputHelper _output;

        public ASCIITests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void ProcessFrameTest()
        {
            var program = File.ReadAllText("Input.txt");

            var ascii = new ASCII(program);

            ascii.ProcessFrame();

            ascii.Map.Visualize(_output);

            Assert.Equal(4044, ascii.AlignmentParametersSum);
        }
    }
}
