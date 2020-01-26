using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            var colorMap = new Dictionary<Color, string>
            {
                { Color.Black, "." },
                { Color.White, "#" }
            };

            var minX = paintedPanels.Min(panel => panel.Key.X);
            var maxX = paintedPanels.Max(panel => panel.Key.X);
            var minY = paintedPanels.Min(panel => panel.Key.Y);
            var maxY = paintedPanels.Max(panel => panel.Key.Y);

            var lineBuilder = new StringBuilder();

            for (int i = maxY; i >= minY; i--)
            {
                for (int j = minX; j <= maxX; j++)
                {
                    var panelColor = paintedPanels.TryGetValue((Position)(j, i), out var color) ? color : Color.Black;
                    lineBuilder.Append(colorMap[panelColor]);
                }

                _output.WriteLine(lineBuilder.ToString());
                lineBuilder.Clear();
            }
        }
    }
}
