using System.IO;
using Xunit;

namespace AdventOfCode16.Tests
{
    public class FFTTests
    {
        [Theory]
        [InlineData(1, "48226158")]
        [InlineData(2, "34040438")]
        [InlineData(3, "03415518")]
        [InlineData(4, "01029498")]
        public void SimpleCalculateTest(int phase, string expectedOutput)
        {
            var output = FFT.Calculate("12345678", phase);

            Assert.Equal(expectedOutput, output);
        }

        [Theory]
        [InlineData("80871224585914546619083218645595", "24176176")]
        [InlineData("19617804207202209144916044189917", "73745418")]
        [InlineData("69317163492948606335995924319873", "52432133")]
        public void LargeInputAfter100PhasesTest(string inputSignal, string expectedOutputSignalBeginning)
        {
            var output = FFT.Calculate(inputSignal, 100);

            Assert.Equal(expectedOutputSignalBeginning, output.Substring(0, 8));
        }

        [Fact]
        public void TheInputAfter100PhasesTest()
        {
            var input = File.ReadAllText("Input.txt");

            var output = FFT.Calculate(input, 100);

            Assert.Equal("77038830", output.Substring(0, 8));
        }

        [Theory]
        [InlineData("03036732577212944063491565474664", "84462026")]
        [InlineData("02935109699940807407585447034323", "78725270")]
        [InlineData("03081770884921959731165446850517", "53553731")]
        public void RealSignalAfter100PhasesTest(string inputSignal, string expectedOutput)
        {
            int messageOffset = int.Parse(inputSignal.Substring(0, 7));
            
            var output = FFT.Calculate(inputSignal, 10000, 100, skipFirstHalf: true);

            Assert.Equal(expectedOutput, output.Substring(messageOffset, 8));
        }

        [Fact]
        public void TheInputRealSignalAfter100PhasesTest()
        {
            var input = File.ReadAllText("Input.txt");

            int messageOffset = int.Parse(input.Substring(0, 7));

            var output = FFT.Calculate(input, 10000, 100, skipFirstHalf: true);

            Assert.Equal("28135104", output.Substring(messageOffset, 8));
        }
    }
}
