using System.Collections.Generic;
using System.IO;
using TestHelpers;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode15.Tests
{
    public class MapExplorerTests
    {
        private readonly ITestOutputHelper _output;

        private readonly Dictionary<TileType, char> visualMap = new Dictionary<TileType, char>
        {
            { TileType.Empty, '.' },
            { TileType.Wall, '#' },
            { TileType.OxygenSystem, 'O' },
            { TileType.Start, 'X' }
        };

        public MapExplorerTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void ExploreTest()
        {
            var program = File.ReadAllText("Input.txt");

            var explorer = new MapExplorer(program);

            var pathLength = explorer.Explore();

            explorer.Map.Visualize(_output, visualMap, '?');

            Assert.Equal((-12, 16), explorer.OxygenSystemPosition);
            Assert.Equal(280, pathLength);
        }
    }
}
