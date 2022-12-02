using System;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode14.Tests
{
    public class NanofactoryTests
    {
        [Theory]
        [InlineData("Example1.txt", 31)]
        [InlineData("Example2.txt", 165)]
        [InlineData("Example3.txt", 13312)]
        [InlineData("Example4.txt", 180697)]
        [InlineData("Example5.txt", 2210736)]
        [InlineData("Input.txt", 365768)]
        public void MinimumOreForOneFuelTest(string fileName, long expectedOre)
        {
            var nanofactory = new Nanofactory(fileName);

            Assert.Equal(expectedOre, nanofactory.MinimumOreForOneFuel());
        }

        [Theory]
        [InlineData("Example1.txt", 34482758620)]
        [InlineData("Example2.txt", 6323777400)]
        [InlineData("Example3.txt", 82892753)]
        [InlineData("Example4.txt", 5586022)]
        [InlineData("Example5.txt", 460664)]
        [InlineData("Input.txt", 3756877)]
        public void MaximumAmountOfFuelWithTrilionOre(string fileName, long expectedFuel)
        {
            var nanofactory = new Nanofactory(fileName);

            var OreForOneFuel = nanofactory.MinimumOreForOneFuel();

            var results = new List<(long Fuel, long Ore)>();

            const long trilionOre = 1000000000000;
            var fuel1 = trilionOre / OreForOneFuel;
            var requiredOre1 = nanofactory.MinimumOreForFuel(fuel1);
            results.Add((fuel1, requiredOre1));

            long fuel2 = fuel1 * 2;
            long requiredOre2;
            long delta;

            do
            {
                requiredOre2 = nanofactory.MinimumOreForFuel(fuel2);
                results.Add((fuel2, requiredOre2));

                delta = Math.Abs(fuel2 - fuel1) / 2;
                fuel1 = fuel2;
                if (requiredOre2 > trilionOre)
                {
                    delta = delta > 0 ? delta : 1;
                    fuel2 -= delta;
                }
                else
                {
                    fuel2 += delta;
                }
            }
            while (delta > 0);

            Assert.Equal(expectedFuel, results.FindLast(result => result.Ore < trilionOre).Fuel);
        }
    }
}
