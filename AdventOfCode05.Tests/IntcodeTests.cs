using AdventOfCode02;
using System.IO;
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

        [Fact]
        public void TestNewOpcodeFormat()
        {
            var intcode = new Intcode("1002,4,3,4,33");

            intcode.Process();

            Assert.Equal(1002, intcode.Result); 
            Assert.Equal(99, intcode.ReadMemory(4L));
        }

        [Fact]
        public void TestNegativeValues()
        {
            var intcode = new Intcode("1101,100,-1,4,0");

            intcode.Process();

            Assert.Equal(1101, intcode.Result);
            Assert.Equal(99, intcode.ReadMemory(4L));
        }

        [Theory]
        [InlineData(1, 9025675)] //Run diagnostic program
        [InlineData(5, 11981754)] //Extend thermal radiators
        public void TestRunProgram(long input, long expectedOutput)
        {
            var intcode = new Intcode(File.ReadAllText("Program.txt"), input);

            intcode.Process();

            Assert.Equal(expectedOutput, intcode.Output);
        }

        [Theory]
        [InlineData("3,9,8,9,10,9,4,9,99,-1,8", 7, 0)]
        [InlineData("3,9,8,9,10,9,4,9,99,-1,8", 8, 1)]
        [InlineData("3,9,8,9,10,9,4,9,99,-1,8", 9, 0)]
        [InlineData("3,3,1108,-1,8,3,4,3,99", 7, 0)]
        [InlineData("3,3,1108,-1,8,3,4,3,99", 8, 1)]
        [InlineData("3,3,1108,-1,8,3,4,3,99", 9, 0)]
        public void TestEqualsInstruction(string program, long input, long expectedOutput)
        {
            var intcode = new Intcode(program, input);

            intcode.Process();

            Assert.Equal(expectedOutput, intcode.Output);
        }

        [Theory]
        [InlineData("3,9,7,9,10,9,4,9,99,-1,8", 7, 1)]
        [InlineData("3,9,7,9,10,9,4,9,99,-1,8", 8, 0)]
        [InlineData("3,9,7,9,10,9,4,9,99,-1,8", 9, 0)]
        [InlineData("3,3,1107,-1,8,3,4,3,99", 7, 1)]
        [InlineData("3,3,1107,-1,8,3,4,3,99", 8, 0)]
        [InlineData("3,3,1107,-1,8,3,4,3,99", 9, 0)]
        public void TestLessThanInstruction(string program, long input, long expectedOutput)
        {
            var intcode = new Intcode(program, input);

            intcode.Process();

            Assert.Equal(expectedOutput, intcode.Output);
        }

        [Theory]
        [InlineData("3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9", 0, 0)]
        [InlineData("3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9", 42, 1)]
        [InlineData("3,3,1105,-1,9,1101,0,0,12,4,12,99,1", 0, 0)]
        [InlineData("3,3,1105,-1,9,1101,0,0,12,4,12,99,1", 42, 1)]
        public void TestJumps(string program, long input, long expectedOutput)
        {
            var intcode = new Intcode(program, input);

            intcode.Process();

            Assert.Equal(expectedOutput, intcode.Output);
        }

        [Theory]
        [InlineData(4, 999)]
        [InlineData(8, 1000)]
        [InlineData(42, 1001)]
        public void TestLargerProgram(long input, long expectedOutput)
        {
            var intcode = new Intcode("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104,999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99", input);

            intcode.Process();

            Assert.Equal(expectedOutput, intcode.Output);
        }
    }
}
