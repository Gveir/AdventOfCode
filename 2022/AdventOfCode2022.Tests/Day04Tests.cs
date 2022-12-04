using AdventOfCode2022.Day04;

namespace AdventOfCode2022.Tests
{
    public class Day04Tests
    {
        [Fact]
        public void FindFullyContainedSectionsTestExample()
        {
            var input = @"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8";

            var containedSectionsCount = SectionsScanner.CountFullyContainedSections(input);

            Assert.Equal(2, containedSectionsCount);
        }

        [Fact]
        public void FindFullyContainedSectionsTestInput()
        {
            var input = File.ReadAllText("Input/Day04.txt");

            var containedSectionsCount = SectionsScanner.CountFullyContainedSections(input);

            Assert.Equal(599, containedSectionsCount);
        }

        [Fact]
        public void FindOverlappingSectionsTestExample()
        {
            var input = @"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8";

            var containedSectionsCount = SectionsScanner.CountOverlappingSections(input);

            Assert.Equal(4, containedSectionsCount);
        }

        [Fact]
        public void FindOverlappingSectionsTestInput()
        {
            var input = File.ReadAllText("Input/Day04.txt");

            var containedSectionsCount = SectionsScanner.CountOverlappingSections(input);

            Assert.Equal(928, containedSectionsCount);
        }
    }
}
