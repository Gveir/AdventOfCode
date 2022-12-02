using System;
using System.IO;
using Xunit;

namespace AdventOfCode06.Tests
{
    public class OrbitsCounterTests
    {
        [Fact]
        public void CountTotalTestExample()
        {
            var input = @"COM)B
B)C
C)D
D)E
E)F
B)G
G)H
D)I
E)J
J)K
K)L";

            var orbitsCounter = new OrbitsCounter(input);

            Assert.Equal(42, orbitsCounter.CountTotal());
        }

        [Fact]
        public void CountTotalTestInput()
        {
            var input = File.ReadAllText("Input.txt");

            var orbitsCounter = new OrbitsCounter(input);

            Assert.Equal(308790, orbitsCounter.CountTotal());
        }

        [Fact]
        public void CountOrbitalTransfersTestExample()
        {
            var input = @"COM)B
B)C
C)D
D)E
E)F
B)G
G)H
D)I
E)J
J)K
K)L
K)YOU
I)SAN";

            var orbitsCounter = new OrbitsCounter(input);

            Assert.Equal(4, orbitsCounter.CountOrbitalTransfers("YOU", "SAN"));
        }

        [Fact]
        public void CountOrbitalTransfersTestInput()
        {
            var input = File.ReadAllText("Input.txt");

            var orbitsCounter = new OrbitsCounter(input);

            Assert.Equal(472, orbitsCounter.CountOrbitalTransfers("YOU", "SAN"));
        }
    }
}
