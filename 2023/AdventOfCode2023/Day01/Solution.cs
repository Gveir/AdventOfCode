using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Day01
{
    public class Solution
    {
        public static long CalculateSumOfCalibrationValues(string input) =>
            InputParser.Parse(input).Select(FindCalibrationValue).Sum();

        private static long FindCalibrationValue(string input)
        {
            long result = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (TryParse(input[i..], out var digit))
                {
                    result = 10 * digit;
                    break;
                }
            }

            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (TryParse(input[i..], out var digit))
                {
                    result += digit;
                    break;
                }
            }

            return result;
        }

        private static bool TryParse(string input, out long result)
        {
            result = default;

            if (DigitParser.TryParseChar(input[0], out var x))
            {
                result = x;
                return true;
            }

            if (DigitParser.TryParseSpelledOutDigit(input, out var y))
            {
                result = y;
                return true;
            }

            return false;
        }
    }
}
