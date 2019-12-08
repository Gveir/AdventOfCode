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
            Assert.Equal(99, intcode.ReadMemory(4));
        }

        [Fact]
        public void TestNegativeValues()
        {
            var intcode = new Intcode("1101,100,-1,4,0");

            intcode.Process();

            Assert.Equal(1101, intcode.Result);
            Assert.Equal(99, intcode.ReadMemory(4));
        }

        [Fact]
        public void DiagnosticsProgram()
        {
            var intcode = new Intcode(File.ReadAllText("Program.txt"), 1);

            intcode.Process();

            Assert.Equal(9025675, intcode.Output);
        }
    }
}
