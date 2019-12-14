using AdventOfCode02;
using System;
using System.Linq;
using Xunit;

namespace AdventOfCode09.Tests
{
    public class IntcodeTests
    {
        [Fact]
        public void OutputLargeNumber()
        {
            var intcode = new Intcode("104,1125899906842624,99");

            intcode.Process();

            Assert.Equal(1125899906842624, intcode.Output);
        }

        [Fact]
        public void Output16DigitsNumber()
        {
            var intcode = new Intcode("1102,34915192,34915192,7,4,7,99,0");

            intcode.Process();

            Assert.Equal(16, intcode.Output.ToString().Length);
        }

        [Fact]
        public void Quine()
        {
            var program = "109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99";
            var expectedOutputs = program.Split(',').Select(s => Convert.ToInt64(s)).ToArray();

            var intcode = new Intcode(program);

            int i = 0;

            while (i < expectedOutputs.Length)
            {
                intcode.Process();

                Assert.Equal(expectedOutputs[i++], intcode.Output);
            }
        }
    }
}
