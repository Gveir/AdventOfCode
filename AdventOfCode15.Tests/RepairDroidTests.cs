using System.IO;
using Xunit;

namespace AdventOfCode15.Tests
{
    public class RepairDroidTests
    {
        [Theory]
        [InlineData(MovementCommand.North, StatusCode.Wall, 0, 0)]
        [InlineData(MovementCommand.South, StatusCode.Wall, 0, 0)]
        [InlineData(MovementCommand.West, StatusCode.Wall, 0, 0)]
        [InlineData(MovementCommand.East, StatusCode.Moved, 1, 0)]
        public void MoveTest(MovementCommand command, StatusCode expectedStatus, int expectedX, int expectedY)
        {
            var program = File.ReadAllText("Input.txt");

            var droid = new RepairDroid(program);

            var status = droid.Move(command);

            Assert.Equal(expectedStatus, status);
            Assert.Equal((expectedX, expectedY), droid.Position);
        }
    }
}
