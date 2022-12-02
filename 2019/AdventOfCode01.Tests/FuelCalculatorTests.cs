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
        public void CalculateModuleFuelRequirement(int givenMass, int expectedFuel)
        {
            Assert.Equal(expectedFuel, FuelCalculator.CalculateFuelRequirement(givenMass));
        }

        [Fact]
        public void CalculateSpacecraftFuelRequirements()
        {
            var modulesMasses = File.ReadAllText("Input.txt")
                .Split(Environment.NewLine)
                .Select(x => Convert.ToInt32(x));

            Assert.Equal(3313655, FuelCalculator.CalculateSpacecraftFuelRequirement(modulesMasses));
        }

        [Theory]
        [InlineData(14, 2)]
        [InlineData(1969, 966)]
        [InlineData(100756, 50346)]
        public void CalculateModuleFuelRequirementIncludingTheFuelMass(int givenMass, int expectedFuel)
        {
            Assert.Equal(expectedFuel, FuelCalculator.CalculateModuleFuelRequirementIncludingTheFuelMass(givenMass));
        }

        [Fact]
        public void CalculateSpacecraftFuelRequirementsInfIncludingFuelMass()
        {
            var modulesMasses = File.ReadAllText("Input.txt")
                .Split(Environment.NewLine)
                .Select(x => Convert.ToInt32(x));

            Assert.Equal(4967616, FuelCalculator.CalculateSpacecraftFuelRequirementIncludingFuelMass(modulesMasses));
        }
    }
}
