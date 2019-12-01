using System;
using System.IO;
using System.Linq;
using Xunit;

namespace AdventOfCode01.Tests
{
    public class FuelCalculatorTests
    {
        [Theory]
        [InlineData(12, 2)]
        [InlineData(14, 2)]
        [InlineData(1969, 654)]
        [InlineData(100756, 33583)]
        public void Calculate(int givenMass, int expectedFuel)
        {
            Assert.Equal(expectedFuel, FuelCalculator.CalculateModuleFuelRequirement(givenMass));
        }

        [Fact]
        public void CalculateSpacecraftFuelRequirements()
        {
            var modulesMasses = File.ReadAllText("Input.txt")
                .Split(Environment.NewLine)
                .Select(x => Convert.ToInt32(x));

            Assert.Equal(3313655, FuelCalculator.CalculateSpacecraftFuelRequirement(modulesMasses));
        }
    }
}
