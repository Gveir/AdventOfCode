using System.IO;
using Xunit;

namespace AdventOfCode11.Tests
{
    public class EmergencyHullPaintingRobotTests
    {
        [Fact]
        public void RobotTest()
        {
            var program = File.ReadAllText("Program.txt");

            var robot = new EmergencyHullPaintingRobot(program);

            robot.PaintHull();

            Assert.Equal(1907, robot.PaintendPanelsCount);
        }
    }
}
