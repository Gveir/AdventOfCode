namespace AdventOfCode2022.Day05
{
    internal static class StackExtensions
    {
        public static IEnumerable<T> PopRange<T>(this Stack<T> stack, int amount)
        {
            while (amount-- > 0 && stack.Count > 0)
            {
                yield return stack.Pop();
            }
        }

        public static void PushRange<T>(this Stack<T> stack, IEnumerable<T> elementsToPush)
        {
            foreach (var element in elementsToPush)
            {
                stack.Push(element);
            }
        }
    }
}
