using Xunit;

namespace AdventOfCode12.Tests
{
    public class JupiterSystemTest
    {
        [Fact]
        public void Example1Test()
        {
            var exampleLoader = new ExampleLoader("Example1.txt");

            var system = exampleLoader.System;

            Assert.Equal(exampleLoader.ExpectedSystemStateOnStep[0], system.Moons);

            for (int i = 1; i <= 10; i++)
            {
                system.Simulate();
                Assert.Equal(exampleLoader.ExpectedSystemStateOnStep[i], system.Moons);
            }

            Assert.Equal(179, system.TotalEnergy);
        }

        [Fact]
        public void Example2Test()
        {
            var exampleLoader = new ExampleLoader("Example2.txt");

            var system = exampleLoader.System;

            Assert.Equal(exampleLoader.ExpectedSystemStateOnStep[0], system.Moons);

            for (int i = 1; i <= 10; i++)
            {
                system.Simulate(10);
                Assert.Equal(exampleLoader.ExpectedSystemStateOnStep[i * 10], system.Moons);
            }

            Assert.Equal(1940, system.TotalEnergy);
        }

        [Fact]
        public void FindSystemsTotalEnergyAfter1000Steps()
        {
            var exampleLoader = new ExampleLoader("Input.txt");

            var system = exampleLoader.System;

            system.Simulate(1000);

            Assert.Equal(12053, system.TotalEnergy);
        }
    }
}
