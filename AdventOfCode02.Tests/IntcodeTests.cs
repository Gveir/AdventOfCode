using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode02.Tests
{
    public class IntcodeTests
    {
        private readonly ITestOutputHelper _output;

        public IntcodeTests(ITestOutputHelper output)
        {
            _output = output;
        }

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

        [Fact]
        public void FindingOutput19690720()
        {
            string input = File.ReadAllText("Input.txt");
            long desiredOutput = 19690720;

            for (long noun = 10; noun < 100; noun++)
            {
                for (long verb = 10; verb < 100; verb++)
                {
                    var intcode = new Intcode(input);
                    intcode.AdjustMemory(memory =>
                    {
                        memory[1] = noun;
                        memory[2] = verb;
                    });

                    intcode.Process();

                    if (intcode.Result == desiredOutput)
                    {
                        _output.WriteLine($"Found noun: {noun} and verb: {verb}; The result is {100 * noun + verb}");
                        return;
                    }
                }
            }

            Assert.True(false, "Failed to find noun and verb for desired output :(");
        }
    }
}
