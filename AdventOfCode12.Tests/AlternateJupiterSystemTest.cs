using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode12.Tests
{
    public class AlternateJupiterSystemTest
    {
        [Fact]
        public void Example1Test()
        {
            var exampleLoader = new AlternateExampleLoader("Example1.txt");

            var system = exampleLoader.System;

            Assert.Equal(exampleLoader.ExpectedSystemStateOnStep[0], system.State);

            for (int i = 1; i <= 10; i++)
            {
                system.Simulate();
                Assert.Equal(exampleLoader.ExpectedSystemStateOnStep[i], system.State);
            }

            Assert.Equal(179, system.TotalEnergy);
        }

        [Fact]
        public void Example2Test()
        {
            var exampleLoader = new AlternateExampleLoader("Example2.txt");

            var system = exampleLoader.System;

            Assert.Equal(exampleLoader.ExpectedSystemStateOnStep[0], system.State);

            for (int i = 1; i <= 10; i++)
            {
                system.Simulate(10);
                Assert.Equal(exampleLoader.ExpectedSystemStateOnStep[i * 10], system.State);
            }

            Assert.Equal(1940, system.TotalEnergy);
        }

        [Fact]
        public void FindSystemsTotalEnergyAfter1000Steps()
        {
            var exampleLoader = new AlternateExampleLoader("Input.txt");

            var system = exampleLoader.System;

            system.Simulate(1000);

            Assert.Equal(12053, system.TotalEnergy);
        }

        [Theory]
        [InlineData("Example1.txt", 2772)]
        //[InlineData("Example2.txt", 4686774924)]
        public void ExampleHistoryRepeatItselfTest(string fileName, long expectedSteps)
        {
            var exampleLoader = new AlternateExampleLoader(fileName);

            var system = exampleLoader.System;

            var initialState = system.State.ToArray();

            long step = 0;

            do
            {
                step++;
                system.Simulate();

                if (initialState.SequenceEqual(system.State))
                {
                    break;
                }
            } while (step <= expectedSteps + 1);

            Assert.Equal(expectedSteps, step);
        }
    }
}
