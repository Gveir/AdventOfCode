using AdventOfCode02;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode09.Tests
{
    public class BoostTests
    {
        private readonly ITestOutputHelper _output;

        public BoostTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void BoostProgramTest()
        {
            var program = File.ReadAllText("Program.txt");

            var intcode = new Intcode(program, 1);

            while (!intcode.IsFinished)
            {
                intcode.Process();
                _output.WriteLine(intcode.Output.ToString());
            }

            Assert.Equal(3512778005, intcode.Output);
        }

        [Fact]
        public void CoordinatesOfTheDistressSignalTest()
        {
            var program = File.ReadAllText("Program.txt");

            var intcode = new Intcode(program, 2);

            while (!intcode.IsFinished)
            {
                intcode.Process();
                _output.WriteLine(intcode.Output.ToString());
            }

            Assert.Equal(35920, intcode.Output);
        }
    }
}
