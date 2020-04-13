using System.IO;
using Xunit;

namespace AdventOfCode15.Tests
{
    public class RepairDroidTests
    {
        [Theory]
        [InlineData(MovementCommand.North, TileType.Wall, 0, 1)]
        [InlineData(MovementCommand.South, TileType.Wall, 0, -1)]
        [InlineData(MovementCommand.West, TileType.Wall, -1, 0)]
        [InlineData(MovementCommand.East, TileType.Empty, 1, 0)]
        public void MoveTest(MovementCommand command, TileType expectedTileType, int expectedX, int expectedY)
        {
            var program = File.ReadAllText("Input.txt");

            var droid = new RepairDroid(program);

            var droidAfterMove = droid.Move(command);

            Assert.Equal(expectedTileType, droidAfterMove.TileType);
            Assert.Equal((expectedX, expectedY), droidAfterMove.Position);
            Assert.Equal(1, droidAfterMove.MoveCounter);
        }
    }
}
