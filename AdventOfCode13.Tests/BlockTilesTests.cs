using System;
using System.IO;
using Xunit;

namespace AdventOfCode13.Tests
{
    public class BlockTilesTests
    {
        [Fact]
        public void CountBlockTilesTest()
        {
            var program = File.ReadAllText("Game.txt");

            var arcadeCabinet = new ArcadeCabinet(program);

            arcadeCabinet.Play();

            Assert.Equal(329, arcadeCabinet.BlockTilesCount);
        }
    }
}
