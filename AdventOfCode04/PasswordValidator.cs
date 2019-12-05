
using System.Linq;

namespace AdventOfCode04
{
    public class PasswordValidator
    {
        public static bool Validate(string password)
        {
            var hasDuplicatedChar = password.Length != password.Distinct().Count();
            var isAscending = password == string.Concat(password.OrderBy(ch => ch));

            return isAscending && hasDuplicatedChar;
        }
    }
}
