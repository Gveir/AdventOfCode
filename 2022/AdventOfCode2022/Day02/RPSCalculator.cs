namespace AdventOfCode2022.Day02
{
    public class RPSCalculator
    {
        private static IDictionary<string, int> OutcomeScores = new Dictionary<string, int>
        {
            { "A X", 3 },
            { "A Y", 6 },
            { "A Z", 0 },
            { "B X", 0 },
            { "B Y", 3 },
            { "B Z", 6 },
            { "C X", 6 },
            { "C Y", 0 },
            { "C Z", 3 },
        };

        private static IDictionary<string, int> StrategyGuideOutcomeScores = new Dictionary<string, int>
        {
            { "A X", 0 },
            { "A Y", 3 },
            { "A Z", 6 },
            { "B X", 0 },
            { "B Y", 3 },
            { "B Z", 6 },
            { "C X", 0 },
            { "C Y", 3 },
            { "C Z", 6 },
        };

        private static IDictionary<string, int> StrategyGuideShapeScores = new Dictionary<string, int>
        {
            { "A X", 3 },
            { "A Y", 1 },
            { "A Z", 2 },
            { "B X", 1 },
            { "B Y", 2 },
            { "B Z", 3 },
            { "C X", 2 },
            { "C Y", 3 },
            { "C Z", 1 },
        };

        public static int CalculateTotalScore(string input) => 
            input.Split(Environment.NewLine).Select(CalculateRoundScore).Sum();

        public static int CalculateStrategyGuideScore(string input) =>
            input.Split(Environment.NewLine).Select(CalculateStrategyGuideRoundScore).Sum();

        private static int CalculateRoundScore(string round)
        {
            var shapeScore = round[2] - 'W';
            var outcomeScore = OutcomeScores[round];

            return shapeScore + outcomeScore;
        }

        private static int CalculateStrategyGuideRoundScore(string round) =>
            StrategyGuideOutcomeScores[round] + StrategyGuideShapeScores[round];
    }
}
