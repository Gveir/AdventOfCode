﻿namespace AdventOfCode2022.Day04
{
    public class SectionsScanner
    {
        public static int CountFullyContainedSections(string input) =>
            input.Split(Environment.NewLine).Select(IsSectionFullyContained).Count(x => x);

        private static bool IsSectionFullyContained(string assignmensPair)
        {
            var ranges = assignmensPair.Split(',')
                .Select(a => a.Split('-').Select(int.Parse).ToArray()).ToArray();
            return ranges[0][0] <= ranges[1][0] && ranges[0][1] >= ranges[1][1] || ranges[1][0] <= ranges[0][0] && ranges[1][1] >= ranges[0][1];
        }
    }
}
