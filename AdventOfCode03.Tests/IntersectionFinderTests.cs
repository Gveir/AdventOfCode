using System;
using System.IO;
using Xunit;

namespace AdventOfCode03.Tests
{
    public class IntersectionFinderTests
    {
        [Theory]
        [InlineData("R8,U5,L5,D3", "U7,R6,D4,L4", 6)]
        [InlineData("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", 159)]
        [InlineData("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 135)]
        public void FindingClosestIntersection(string path1, string path2, int expectedDistance)
        {
            Assert.Equal(expectedDistance, IntersectionFinder.FindClosestIntersectionDistance(path1, path2));
        }

        [Fact]
        public void PuzzleClosestIntersection()
        {
            string[] input = File.ReadAllText("Input.txt").Split(Environment.NewLine);

            Assert.Equal(258, IntersectionFinder.FindClosestIntersectionDistance(input[0], input[1]));
        }
    }
}
