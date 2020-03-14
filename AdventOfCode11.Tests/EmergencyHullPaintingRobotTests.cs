using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestHelpers;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode11.Tests
{
    public class EmergencyHullPaintingRobotTests
    {
        private readonly ITestOutputHelper _output;

        public EmergencyHullPaintingRobotTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData(Color.Black, 1907)]
        [InlineData(Color.White, 250)]
        public void PaintedPanelsCountTest(Color startingColor, int expectedCount)
        {
            var program = File.ReadAllText("Program.txt");

            var robot = new EmergencyHullPaintingRobot(program, startingColor);

            robot.PaintHull();

            Assert.Equal(expectedCount, robot.PaintedPanels.Count);
        }

        [Fact]
        public void RegistrationIdentifierTest()
        {
            var program = File.ReadAllText("Program.txt");

            var robot = new EmergencyHullPaintingRobot(program, Color.White);

            robot.PaintHull();

            VisualizeRegistrationIdentifier(robot.PaintedPanels);
        }

        private void VisualizeRegistrationIdentifier(IReadOnlyDictionary<Position, Color> paintedPanels)
        {
            var colorMap = new Dictionary<Color, char>
            {
                { Color.Black, '.' },
                { Color.White, '#' }
            };

            paintedPanels.ToDictionary(x => (x.Key.X, x.Key.Y), x => x.Value)
                .Visualize(_output, colorMap, '.');
        }
    }
}
