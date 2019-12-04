using AdventOfCode02;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace AgventOfCode02
{
    public class IntcodeTests
    {
        [Theory]
        [InlineData("1,0,0,0,99", "2,0,0,0,99")]
        [InlineData("2,3,0,3,99", "2,3,0,6,99")]
        [InlineData("2,4,4,5,99,0", "2,4,4,5,99,9801")]
        [InlineData("1,1,1,4,99,5,6,0,99", "30,1,1,4,2,5,6,0,99")]
        public void Calculate(string input, string expectedOutput)
        {
            Assert.Equal(expectedOutput, Intcode.Calculate(input));
        }

        [Fact]
        public void ProgramAlarm()
        {
            var input = File.ReadAllText("Input.txt").Split(',').Select(i => Convert.ToInt64(i)).ToArray();
            input[1] = 12;
            input[2] = 2;

            Assert.StartsWith("2890696,", Intcode.Calculate(string.Join(',', input)));
        }
    }
}
