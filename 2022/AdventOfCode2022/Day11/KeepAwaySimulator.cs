namespace AdventOfCode2022.Day11
{
    public class KeepAwaySimulator
    {
        public static int FindMonkeyBusiness(string input)
        {
            var monkeys = InputParser.Parse(input);

            SimulateRounds(monkeys, 20);

            return monkeys.Select(m => m.InspectionsCount).OrderByDescending(x => x).Take(2).Aggregate(1, (m, x) => m * x);
        }

        private static void SimulateRounds(IReadOnlyList<Monkey> monkeys, int roundsCount)
        {
            while(roundsCount-- > 0)
            {
                int monkeyIndex = 0;
                foreach (var monkey in monkeys)
                {
                    Console.WriteLine($"Monkey {monkeyIndex++}:");
                    SimulateMonkeyTurn(monkey, monkeys);
                }
            }
        }

        private static void SimulateMonkeyTurn(Monkey monkey, IReadOnlyList<Monkey> monkeys)
        {
            foreach (var item in monkey.Items.ToArray())
            {
                Console.WriteLine($" Monkey inspects an item with a worry level of {item}.");

                monkey.InspectionsCount++;
                monkey.Items.Remove(item);
                var newWorryLevel = monkey.Operation.CalculateNew(item);

                Console.WriteLine($"  Worry level is {monkey.Operation} to {newWorryLevel}.");

                newWorryLevel /= 3;

                Console.WriteLine($"  Monkey gets bored with item. Worry level is divided by 3 to {newWorryLevel}.");

                if (newWorryLevel % monkey.Test.DivisibleBy == 0)
                {
                    Console.WriteLine($"Current worry level is divisible by {monkey.Test.DivisibleBy}.");
                    monkeys[monkey.Test.ThrowToIfTrue].Items.Add(newWorryLevel);
                    Console.WriteLine($"Item with worry level {newWorryLevel} is thrown to monkey {monkey.Test.ThrowToIfTrue}.");
                }
                else
                {
                    Console.WriteLine($"Current worry level is not divisible by {monkey.Test.DivisibleBy}.");
                    monkeys[monkey.Test.ThrowToIfFalse].Items.Add(newWorryLevel);
                    Console.WriteLine($"Item with worry level {newWorryLevel} is thrown to monkey {monkey.Test.ThrowToIfFalse}.");

                }
            }
        }
    }

    internal class Monkey
    {
        public IList<int> Items { get; private set; }
        public IOperation Operation { get; private set; }
        public Test Test { get; private set; }
        public int InspectionsCount { get; set; } = 0;

        public Monkey(List<int> items, IOperation operation, Test test)
        {
            Items = items;
            Operation = operation;
            Test = test;
        }
    }

    internal record Test(int DivisibleBy, int ThrowToIfTrue, int ThrowToIfFalse)
    {
        public int WhereToThrow(int worryLevel) => 
            worryLevel % DivisibleBy == 0 ? ThrowToIfTrue : ThrowToIfFalse;
    }

    internal interface IOperation
    {
        int CalculateNew(int old);
    }

    internal record Add(int Operand) : IOperation
    {
        public int CalculateNew(int old) => old + Operand;

        public override string ToString() => $"increases by {Operand}";

    }

    internal record Multiply(int Operand) : IOperation
    {
        public int CalculateNew(int old) => old * Operand;

        public override string ToString() => $"multiplied by {Operand}";
    }

    internal record MultiplyByItself() : IOperation
    {
        public int CalculateNew(int old) => old * old;

        public override string ToString() => "multiplied by itself";
    }

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

        private static List<int> ParseStartingItems(string startingItems) =>
            startingItems[18..].Split(", ").Select(int.Parse).ToList();

        private static IOperation ParseOperation(string operation)
        {
            var parts = operation[23..].Split(' ');

            if (parts[0] == "+")
            {
                return new Add(int.Parse(parts[1]));
            }

            if (parts[0] == "*")
            {
                if (parts[1] == "old")
                {
                    return new MultiplyByItself();
                }

                return new Multiply(int.Parse(parts[1]));
            }

            return null;
        }

        private static Test ParseTest(string[] test)
        {
            var divisibleBy = int.Parse(test[0][21..]);
            var throwToIfTrue = int.Parse(test[1].Split(" ")[^1].ToString());
            var throwToIfFalse = int.Parse(test[2].Split(" ")[^1].ToString());

            return new Test(divisibleBy, throwToIfTrue, throwToIfFalse);
        }
    }
}
