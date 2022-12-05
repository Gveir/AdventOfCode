using AdventOfCode2022.Day05;

namespace AdventOfCode2022.Tests
{
    public class Day05Tests
    {
        [Fact]
        public void CrateMover9000RearrangementTestExample()
        {
            var input = @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2";

            var topCrates = new CrateMover9000RearrangementProcessor().Process(input);

            Assert.Equal("CMZ", topCrates);
        }

        [Fact]
        public void CrateMover9000RearrangementTestInput()
        {
            var input = File.ReadAllText("Input/Day05.txt");

            var topCrates = new CrateMover9000RearrangementProcessor().Process(input);

            Assert.Equal("QNNTGTPFN", topCrates);
        }

        [Fact]
        public void CrateMover9001RearrangementTestExample()
        {
            var input = @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2";

            var topCrates = new CrateMover9001RearrangementProcessor().Process(input);

            Assert.Equal("MCD", topCrates);
        }

        [Fact]
        public void CrateMover9001RearrangementTestInput()
        {
            var input = File.ReadAllText("Input/Day05.txt");

            var topCrates = new CrateMover9001RearrangementProcessor().Process(input);

            Assert.Equal("GGNPJBTTR", topCrates);
        }
    }
}
