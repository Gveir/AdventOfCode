using AdventOfCode2022.Day05;

namespace AdventOfCode2022.Tests
{
    public class Day05Tests
    {
        [Fact]
        public void RearrangementTestExample()
        {
            var input = @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2";

            var topCrates = RearrangementProcessor.Process(input);

            Assert.Equal("CMZ", topCrates);
        }

        [Fact]
        public void RearrangementTestInput()
        {
            var input = File.ReadAllText("Input/Day05.txt");

            var topCrates = RearrangementProcessor.Process(input);

            Assert.Equal("QNNTGTPFN", topCrates);
        }
    }
}
