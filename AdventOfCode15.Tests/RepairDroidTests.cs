using System.IO;
using Xunit;

namespace AdventOfCode15.Tests
{
    public class RepairDroidTests
    {
        [Theory]
        [InlineData(1, TileType.Wall, 0, 1)]
        [InlineData(2, TileType.Wall, 0, -1)]
        [InlineData(3, TileType.Wall, -1, 0)]
        [InlineData(4, TileType.Empty, 1, 0)]
        public void MoveTest(long command, TileType expectedTileType, int expectedX, int expectedY)
        {
            var program = File.ReadAllText("Input.txt");

            var droid = new RepairDroid(program);

            var droidAfterMove = droid.Move((MovementCommand)command);

            Assert.Equal(expectedTileType, droidAfterMove.TileType);
            Assert.Equal((expectedX, expectedY), droidAfterMove.Position);
            Assert.Equal(1, droidAfterMove.MoveCounter);
        }
    }
}
