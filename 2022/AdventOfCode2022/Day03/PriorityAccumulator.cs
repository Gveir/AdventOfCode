namespace AdventOfCode2022.Day03
{
    public class PriorityAccumulator
    {
        public static int CalculatePrioritySum(string input) =>
            input.Split(Environment.NewLine).Select(CalculateRucksackPriority).ToArray().Sum();

        public static int CalculateBadgeSum(string input) => 
            CalculateBadgePriorities(input.Split(Environment.NewLine)).Sum();

        private static int CalculateRucksackPriority(string input)
        {
            var commonItem = input.AsSpan(0, input.Length / 2).ToArray().Intersect(input.AsSpan(input.Length / 2, input.Length / 2).ToArray()).Single();
            return CalculateItemPriority(commonItem);
        }

        private static IEnumerable<int> CalculateBadgePriorities(string[] rucksacks)
        {
            var badgePriorities = new List<int>();
            for (int i = 0; i < rucksacks.Length; i = i + 3)
            {
                var commonItem = rucksacks[i].Intersect(rucksacks[i + 1]).Intersect(rucksacks[i + 2]).Single();
                badgePriorities.Add(CalculateItemPriority(commonItem));
            }
            return badgePriorities;
        }

        private static int CalculateItemPriority(char item) => item >= 'a' ? item - 'a' + 1 : item - 'A' + 27;
    }
}
