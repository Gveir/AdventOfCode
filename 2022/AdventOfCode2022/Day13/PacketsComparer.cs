using System.Text.Json.Nodes;

namespace AdventOfCode2022.Day13
{
    public class PacketsComparer : IComparer<JsonArray>
    {
        public static int CalculateSumOfPairsIndicesInRightOrder(string input)
        {
            var pairs = input.Split(Environment.NewLine + Environment.NewLine);
            var pairsInRightOrder = pairs.Select(IsPairInRightOrder).ToArray();
            return pairsInRightOrder.Select((x, index) => x == ComparisonResult.InOrder ? (index + 1) : 0).Sum();
        }

        public int CalculateDecoderKey(string input, string[] dividerPackets)
        {
            var packets = input.Split(Environment.NewLine).Where(line => !string.IsNullOrEmpty(line)).ToList();
            packets.AddRange(dividerPackets);

            var sortedPackets = packets.Select(packet => JsonNode.Parse(packet)!.Root.AsArray()).ToList();
            sortedPackets.Sort(this);

            var decoderKey = dividerPackets.Select(dp => sortedPackets.FindIndex(packet => packet.ToJsonString() == dp) + 1).Aggregate(1, (x, y) => x * y);
            return decoderKey;
        }

        private static ComparisonResult IsPairInRightOrder(string inputPair)
        {
            var packetsInPair = inputPair.Split(Environment.NewLine);

            var left = JsonNode.Parse(packetsInPair[0])!.Root.AsArray();
            var right = JsonNode.Parse(packetsInPair[1])!.Root.AsArray();

            return CompareElements(left, right);
        }

        private static ComparisonResult CompareElements(JsonArray left, JsonArray right)
        {
            for (int i = 0; i < Math.Min(left.Count, right.Count); i++)
            {
                var leftElement = left[i];
                var rightElement = right[i];

                if (leftElement is JsonValue && rightElement is JsonValue)
                {

                    var leftValue = leftElement!.GetValue<short>();
                    var rightValue = rightElement!.GetValue<short>();
                    if (leftValue == rightValue) continue;
                    return leftValue < rightValue ? ComparisonResult.InOrder : ComparisonResult.NotInOrder;
                }

                if (leftElement is JsonValue)
                {
                    leftElement = new JsonArray(JsonValue.Create<short>(leftElement.GetValue<short>()));
                }
                if (rightElement is JsonValue)
                {
                    rightElement = new JsonArray(JsonValue.Create<short>(rightElement.GetValue<short>()));
                }

                var comparisonResult = CompareElements(leftElement!.AsArray(), rightElement!.AsArray());
                if (comparisonResult == ComparisonResult.Equal) continue;
                return comparisonResult;
            }

            return left.Count == right.Count
                ? ComparisonResult.Equal
                : left.Count < right.Count
                    ? ComparisonResult.InOrder
                    : ComparisonResult.NotInOrder;
        }

        public int Compare(JsonArray? x, JsonArray? y)
        {
            var comparisonResult = CompareElements(x, y);
            return comparisonResult == ComparisonResult.Equal
                ? 0
                : comparisonResult == ComparisonResult.InOrder
                    ? -1 : 1;

        }
    }

    internal enum ComparisonResult
    {
        Equal,
        InOrder,
        NotInOrder
    }
}
