﻿using AdventOfCode2022.Day08;

namespace AdventOfCode2022.Tests
{
    public class Day08Tests
    {
        [Theory]
        [InlineData("Examples/Day08.txt", 21)]
        [InlineData("Input/Day08.txt", 1647)]
        public void CountVisibleTreesTest(string inputPath, int expectedVisibleTreesCount)
        {
            var input = File.ReadAllLines(inputPath);
            
            var visibleTreesCount = Quadcopter.CountVisibleTrees(input);

            Assert.Equal(expectedVisibleTreesCount, visibleTreesCount);
        }

        [Theory]
        [InlineData("Examples/Day08.txt", 8)]
        [InlineData("Input/Day08.txt", 392080)]
        public void CalculateMaxScenicScoreTest(string inputPath, int expectedVisibleTreesCount)
        {
            var input = File.ReadAllLines(inputPath);

            var visibleTreesCount = Quadcopter.CalculateMaxScenicScore(input);

            Assert.Equal(expectedVisibleTreesCount, visibleTreesCount);
        }
    }
}
