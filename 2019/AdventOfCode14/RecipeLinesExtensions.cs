using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode14
{
    public static class RecipeLinesExtensions
    {
        public static RecipeLine GetForOutputChemical(this IEnumerable<RecipeLine> lines, Chemical chemical)
        {
            return lines.Single(l => l.IsForOutputChemical(chemical));
        }

        public static bool IsForOutputChemical(this RecipeLine line, Chemical chemical)
        {
            return line.Output.Chemical.Equals(chemical);
        }
    }
}
