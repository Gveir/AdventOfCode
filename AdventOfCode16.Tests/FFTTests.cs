using System;
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
            var output = FFT.Calculate((Signal)"12345678", phase);

            Assert.Equal(expectedOutput, output);
        }

        [Theory]
        [InlineData("80871224585914546619083218645595", "24176176")]
        [InlineData("19617804207202209144916044189917", "73745418")]
        [InlineData("69317163492948606335995924319873", "52432133")]
        public void LargeInputAfter100PhasesTest(string inputSignal, string expectedOutputSignalBeginning)
        {
            var output = FFT.Calculate((Signal)inputSignal, 100);

            Assert.Equal(expectedOutputSignalBeginning, output.ToString().Substring(0, 8));
        }

        [Fact]
        public void TheInputAfter100PhasesTest()
        {
            var input = File.ReadAllText("Input.txt");

            var output = FFT.Calculate((Signal)input, 100);

            Assert.Equal("77038830", output.ToString().Substring(0, 8));
        }
    }
}
