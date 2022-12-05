using AdventOfCode2022.Day04;

namespace AdventOfCode2022.Tests
{
    public class Day04Tests
    {
        [Theory]
        [InlineData("Examples/Day04.txt", 2)]
        [InlineData("Input/Day04.txt", 599)]
        public void FindFullyContainedSectionsTest(string inputPath, int expectedContainedSectionsCount)
        {
            var input = File.ReadAllText(inputPath);

            var containedSectionsCount = SectionsScanner.CountFullyContainedSections(input);

            Assert.Equal(expectedContainedSectionsCount, containedSectionsCount);
        }

        [Theory]
        [InlineData("Examples/Day04.txt", 4)]
        [InlineData("Input/Day04.txt", 928)]
        public void FindOverlappingSectionsTest(string inputPath, int expectedOverlappingSectionsCount)
        {
            var input = File.ReadAllText(inputPath);

            var containedSectionsCount = SectionsScanner.CountOverlappingSections(input);

            Assert.Equal(expectedOverlappingSectionsCount, containedSectionsCount);
        }
    }
}
