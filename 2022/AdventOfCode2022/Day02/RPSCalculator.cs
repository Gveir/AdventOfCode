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

        public static int CalculateTotalScore(string input) => 
            input.Split(Environment.NewLine).Select(round => CalculateRoundScore(round)).Sum();

        private static int CalculateRoundScore(string round)
        {
            var shapeScore = round[2] - 'W';
            var outcomeScore = OutcomeScores[round];

            return shapeScore + outcomeScore;
        }
    }
}
