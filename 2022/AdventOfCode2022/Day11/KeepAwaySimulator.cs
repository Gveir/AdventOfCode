namespace AdventOfCode2022.Day11
{
    public class KeepAwaySimulator
    {
        private readonly bool _applyRelief;

        public KeepAwaySimulator(bool applyRelief = true)
        {
            _applyRelief = applyRelief;
        }

        public ulong FindMonkeyBusiness(string input, int numberOfRounds)
        {
            var monkeys = InputParser.Parse(input);

            SimulateRounds(monkeys, numberOfRounds);

            return monkeys.Select(m => m.InspectionsCount).OrderByDescending(x => x).Take(2).Aggregate(1ul, (x, y) => x * y);
        }

        private void SimulateRounds(IReadOnlyList<Monkey> monkeys, int roundsCount)
        {
            uint modBase = monkeys.Select(m => m.Test.DivisibleBy).Aggregate(1u, (x, y) => x * y);

            while (roundsCount-- > 0)
            {
                foreach (var monkey in monkeys)
                {
                    SimulateMonkeyTurn(monkey, monkeys, modBase);
                }
            }
        }

        private void SimulateMonkeyTurn(Monkey monkey, IReadOnlyList<Monkey> monkeys, uint modBase)
        {
            foreach (var item in monkey.Items.ToArray())
            {
                monkey.InspectionsCount++;
                monkey.Items.Remove(item);
                var newWorryLevel = monkey.Operation.CalculateNew(item) % modBase;

                if (_applyRelief)
                {
                    newWorryLevel /= 3;
                }

                var test = monkey.Test;
                monkeys[newWorryLevel % test.DivisibleBy == 0 ? test.ThrowToIfTrue : test.ThrowToIfFalse].Items.Add(newWorryLevel);
            }
        }
    }
}
