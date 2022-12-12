﻿using AdventOfCode2022.Day12;

namespace AdventOfCode2022.Tests
{
    public class Day12Tests
    {
        [Theory]
        [InlineData("Examples/Day12.txt", 31)]
        [InlineData("Input/Day12.txt", 391)]
        public void FindShortestPathLengthTest(string inputPath, int expectedPathLength)
        {
            var input = File.ReadAllLines(inputPath);

            var shortestPathLength = PathFinder.FindShortestPathLength(input);

            Assert.Equal(expectedPathLength, shortestPathLength);
        }
    }
}
