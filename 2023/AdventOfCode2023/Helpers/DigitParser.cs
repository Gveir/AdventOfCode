namespace AdventOfCode2023.Helpers
{
    internal class DigitParser
    {
        public static bool TryParseChar(char ch, out long value)
        {
            value = default;

            if (48 <= ch && ch <= 57)
            {
                value = ch - 48;
                return true;
            }

            return false;
        }

        public static bool TryParseSpelledOutDigit(string input, out long value)
        {
            value = default;

            var digit = spelledOutDigits
                    .Where(d => d.Key.Length <= input.Length && d.Key == input[0..d.Key.Length])
                    .FirstOrDefault();

            if (digit.Key != null)
            {
                value = digit.Value;
                return true;
            }

            return false;
        }

        private static readonly Dictionary<string, long> spelledOutDigits = new Dictionary<string, long>
        {
            {"one", 1},
            {"two", 2},
            {"three", 3},
            {"four", 4},
            {"five", 5},
            {"six", 6},
            {"seven", 7},
            {"eight", 8},
            {"nine", 9}
        };
    }
}
