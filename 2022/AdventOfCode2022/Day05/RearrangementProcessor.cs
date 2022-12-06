using System.Text.RegularExpressions;

namespace AdventOfCode2022.Day05
{
    public abstract class RearrangementProcessor
    {
        private const char EmptyCrate = ' ';
        private const int CrateStringLength = 4; //e.g. "[N] "
        private const int CrateIdOffset = 1;
        private static readonly Regex ProcedureStepRegex =
            new Regex("move ([1-9]\\d?) from ([1-9]) to ([1-9])", RegexOptions.Singleline);

        public string Process(string input)
        {
            var stacksAndProcedure =  input.Split(Environment.NewLine + Environment.NewLine);

            IReadOnlyList<Stack<string>> stacks = ParseStacks(stacksAndProcedure[0]);

            ApplyProcedure(stacks, stacksAndProcedure[1]);
            return string.Join(string.Empty, stacks.Select(s => s.Peek()));
        }

        private IReadOnlyList<Stack<string>> ParseStacks(string input)
        {
            var stacks = new List<Stack<string>>();
            var layers = input.Split(Environment.NewLine);

            foreach(var layer in layers.Take(layers.Length - 1).Reverse())
            {
                for (int i = 0; i < layer.Length; i = i + CrateStringLength)
                {
                    if (stacks.Count <= i / CrateStringLength)
                    {
                        stacks.Add(new Stack<string>());
                    }

                    char crate = layer[i + CrateIdOffset];
                    if (crate != EmptyCrate)
                    {
                        stacks[i / CrateStringLength].Push(crate.ToString());
                    }
                }
            }

            return stacks;
        }

        private void ApplyProcedure(IReadOnlyList<Stack<string>> stacks, string procedure)
        {
            var steps = procedure.Split(Environment.NewLine);

            foreach (var step in steps)
            {
                var match = ProcedureStepRegex.Match(step);
                var quantity = int.Parse(match.Groups[1].Value);
                var source = int.Parse(match.Groups[2].Value);
                var destination = int.Parse(match.Groups[3].Value);

                ApplyRearrangement(stacks, quantity, source, destination);
            }
        }

        protected abstract void ApplyRearrangement(IReadOnlyList<Stack<string>> stacks, int quantity, int source, int destination);
    }

    public class CrateMover9000RearrangementProcessor : RearrangementProcessor
    {
        protected override void ApplyRearrangement(IReadOnlyList<Stack<string>> stacks, int quantity, int source, int destination)
        {
            var cratesToMove = stacks[source - 1].PopRange(quantity);
            stacks[destination - 1].PushRange(cratesToMove);
        }
    }

    public class CrateMover9001RearrangementProcessor : RearrangementProcessor
    {
        protected override void ApplyRearrangement(IReadOnlyList<Stack<string>> stacks, int quantity, int source, int destination)
        {
            var cratesToMove = stacks[source - 1].PopRange(quantity);
            stacks[destination - 1].PushRange(cratesToMove.Reverse());
        }
    }
}