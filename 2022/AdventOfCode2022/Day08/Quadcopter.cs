namespace AdventOfCode2022.Day08
{
    public class Quadcopter
    {
        public static int CountVisibleTrees(string[] input)
        {
            var map = GenerateMap(input).ToList();

            return map.Where(tree => IsTreeVisible(map, tree)).Count();
        }

        private static IEnumerable<Tree> GenerateMap(string[] input)
        {
            for (int row = 0; row < input.Length; row++)
            {
                for (int column = 0; column < input[row].Length; column++)
                {
                    yield return new Tree(row, column, input[row][column] - '0');
                }
            }
        }

        private static bool IsTreeVisible(IEnumerable<Tree> map, Tree tree)
        {
            var isVisibleFromLeft = map.Where(t => t.Row == tree.Row && t.Column < tree.Column).All(t => t.Height < tree.Height);
            var isVisibleFromRight = map.Where(t => t.Row == tree.Row && t.Column > tree.Column).All(t => t.Height < tree.Height);
            var isVisibleFromTop = map.Where(t => t.Row < tree.Row && t.Column == tree.Column).All(t => t.Height < tree.Height);
            var isVisibleFromBottom = map.Where(t => t.Row > tree.Row && t.Column == tree.Column).All(t => t.Height < tree.Height);
            return isVisibleFromLeft || isVisibleFromRight || isVisibleFromTop || isVisibleFromBottom;
        }
    }

    internal record Tree (int Row, int Column, int Height);
}
