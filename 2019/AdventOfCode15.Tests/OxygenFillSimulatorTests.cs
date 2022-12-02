using System.IO;
using Xunit;

namespace AdventOfCode15.Tests
{
    public class OxygenFillSimulatorTests
    {
        [Fact]
        public void SimulateTest()
        {
            var program = File.ReadAllText("Input.txt");

            var explorer = new MapExplorer(program);

            explorer.Explore();

            var time = OxygenFillSimulator.Simulate(explorer.Map);

            Assert.Equal(400, time);
        }
    }
}
