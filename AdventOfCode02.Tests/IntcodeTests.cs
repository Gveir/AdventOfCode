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
            var intcode = new Intcode(input);
            
            intcode.Process();
            
            Assert.Equal(expectedOutput, intcode.GetMemoryDump());
        }

        [Fact]
        public void ProgramAlarm()
        {
            const int noun = 12;
            const int verb = 2;

            var intcode = new Intcode(File.ReadAllText("Input.txt"));
            intcode.AdjustMemory(memory =>
            {
                memory[1] = noun;
                memory[2] = verb;
            });

            intcode.Process();

            Assert.Equal(2890696, intcode.Result);
        }
    }
}
