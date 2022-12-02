
using System.Linq;

namespace AdventOfCode04
{
    public class PasswordValidator
    {
        public static bool Validate(string password)
        {
            var isAscending = password == string.Concat(password.OrderBy(ch => ch));

            var hasDuplicatedChar = password.GroupBy(ch => ch).Select(g => g.Count()).Any(count => count == 2);

            return isAscending && hasDuplicatedChar;
        }
    }
}
