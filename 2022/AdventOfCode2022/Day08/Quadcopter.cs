namespace AdventOfCode2022.Day08
{
    public class Quadcopter
    {
        public static int CountVisibleTrees(string[] input)
        {
            var map = GenerateMap(input).ToList();

            return map.Where(tree => IsTreeVisible(map, tree)).Count();
        }

        public static int CalculateMaxScenicScore(string[] input)
        {
            var map = GenerateMap(input).ToList();

            return map.Select(tree => CalculateTreeScenicScore(map, tree)).Max();
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
            var isVisibleFromLeft = map.Where(LeftTreesPredicate(tree)).All(t => t.Height < tree.Height);
            var isVisibleFromRight = map.Where(RightTreesPredicate(tree)).All(t => t.Height < tree.Height);
            var isVisibleFromTop = map.Where(TopTreesPredicate(tree)).All(t => t.Height < tree.Height);
            var isVisibleFromBottom = map.Where(BottomTreesPredicate(tree)).All(t => t.Height < tree.Height);
            return isVisibleFromLeft || isVisibleFromRight || isVisibleFromTop || isVisibleFromBottom;
        }

        private static int CalculateTreeScenicScore(IEnumerable<Tree> map, Tree tree)
        {
            var visibleTreesOnLeft = CountVisibleTrees(map.Where(LeftTreesPredicate(tree)).OrderByDescending(tree => tree.Column), tree);
            var visibleTreesOnRight = CountVisibleTrees(map.Where(RightTreesPredicate(tree)).OrderBy(tree => tree.Column), tree);
            var visibleTreesOnTop = CountVisibleTrees(map.Where(TopTreesPredicate(tree)).OrderByDescending(tree => tree.Row), tree);
            var visibleTreesOnBottom = CountVisibleTrees(map.Where(BottomTreesPredicate(tree)).OrderBy(tree => tree.Row), tree);

            return visibleTreesOnLeft * visibleTreesOnRight * visibleTreesOnTop * visibleTreesOnBottom;
        }

        private static int CountVisibleTrees(IOrderedEnumerable<Tree> trees, Tree tree)
        {
            int count = 0;

            foreach (var t in trees)
            {
                count++;
                if (t.Height >= tree.Height) break;
            }

            return count;
        }

        private static Func<Tree, bool> LeftTreesPredicate(Tree tree) => t => t.Row == tree.Row && t.Column < tree.Column;
        private static Func<Tree, bool> RightTreesPredicate(Tree tree) => t => t.Row == tree.Row && t.Column > tree.Column;
        private static Func<Tree, bool> TopTreesPredicate(Tree tree) => t => t.Row < tree.Row && t.Column == tree.Column;
        private static Func<Tree, bool> BottomTreesPredicate(Tree tree) => t => t.Row > tree.Row && t.Column == tree.Column;
    }

    internal record Tree (int Row, int Column, int Height);
}
