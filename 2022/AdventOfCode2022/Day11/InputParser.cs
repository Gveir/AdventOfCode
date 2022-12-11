namespace AdventOfCode2022.Day11
{
    internal class InputParser
    {
        public static IReadOnlyList<Monkey> Parse(string input)
        {
            var monkeys = new List<Monkey>();

            foreach (var monkeyInput in input.Split(Environment.NewLine + Environment.NewLine))
            {
                var monkeySpec = monkeyInput.Split(Environment.NewLine);

                var startingItems = ParseStartingItems(monkeySpec[1]);
                var operation = ParseOperation(monkeySpec[2]);
                var test = ParseTest(monkeySpec[3..]);

                monkeys.Add(new Monkey(startingItems, operation, test));
            }

            return monkeys;
        }

        private static List<ulong> ParseStartingItems(string startingItems) =>
            startingItems[18..].Split(", ").Select(ulong.Parse).ToList();

        private static IOperation ParseOperation(string operation)
        {
            var parts = operation[23..].Split(' ');

            if (parts[0] == "+")
            {
                return new Add(uint.Parse(parts[1]));
            }

            if (parts[0] == "*")
            {
                if (parts[1] == "old")
                {
                    return new MultiplyByItself();
                }

                return new Multiply(uint.Parse(parts[1]));
            }

            throw new ArgumentException($"Unsupported operation {parts[0]} {parts[1]}");
        }

        private static Test ParseTest(string[] test)
        {
            var divisibleBy = uint.Parse(test[0][21..]);
            var throwToIfTrue = int.Parse(test[1].Split(" ")[^1].ToString());
            var throwToIfFalse = int.Parse(test[2].Split(" ")[^1].ToString());

            return new Test(divisibleBy, throwToIfTrue, throwToIfFalse);
        }
    }
}
