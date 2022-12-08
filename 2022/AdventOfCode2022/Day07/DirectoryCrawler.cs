namespace AdventOfCode2022.Day07
{
    public class DirectoryCrawler
    {
        public static int SumOfTotalSizesOfDirs(string[] input, int sizeThreshold)
        {
            var tree = new TreeBuilder().Build(input);

            return tree.Where(node => node.IsDirectory && node.Size <= sizeThreshold).Sum(node => node.Size);
        }

        public static object ChooseDirectoryToDelete(string[] input, int diskSize, int requiredUnusedSpace)
        {
            var tree = new TreeBuilder().Build(input);

            var usedSpace = tree[0].Size;
            var unusedSpace = diskSize - usedSpace;
            var spaceNeededToFree = requiredUnusedSpace - unusedSpace;

            return tree.Where(node => node.Size >= spaceNeededToFree && node.IsDirectory).Min(node => node.Size);
        }
    }

    internal record FilesTreeNode
    {
        public int Left { get; set; }
        public int Right { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Size { get; set; } = 0;
        public bool IsDirectory { get; init; }
        public int DepthInTree { get; init; }
    }

    internal class TreeBuilder
    {
        private List<FilesTreeNode> tree;
        private FilesTreeNode? currentNode;

        public TreeBuilder()
        {
            tree = new List<FilesTreeNode>
            {
                new FilesTreeNode
                {
                    Left = 1,
                    Right = 2,
                    Name = "/",
                    Size = 0,
                    IsDirectory = true,
                    DepthInTree = 0
                }
            };
        }

        public List<FilesTreeNode> Build(string[] input)
        {
            foreach (var inputLine in input)
            {
                if (inputLine.StartsWith('$'))
                {
                    ProcessCommand(inputLine);
                }
                else
                {
                    AddDirectory(inputLine);
                }
            }

            while(currentNode != null)
            {
                currentNode.Size = tree.Where(node => node.Left > currentNode.Left && node.Right < currentNode.Right && !node.IsDirectory).Sum(node => node.Size);
                currentNode = tree.Where(node => node.Left < currentNode.Left && node.Right > currentNode.Right).MinBy(node => node.Right);
            }
            

            return tree;
        }

        private void ProcessCommand(string inputLine)
        {
            var lineParts = inputLine.Split(' ');

            if (lineParts[1] == "cd")
            {
                if (lineParts[2] == "..")
                {
                    if (currentNode == null) return;
                    currentNode.Size = tree.Where(node => node.Left > currentNode.Left && node.Right < currentNode.Right && !node.IsDirectory).Sum(node => node.Size);
                    currentNode = tree.Where(node => node.Left < currentNode.Left && node.Right > currentNode.Right).MinBy(node => node.Right);
                    return;
                }

                if (currentNode == null)
                {
                    currentNode = tree.Single(node => node.Name == "/");
                    return;
                }

                currentNode = tree.Single(
                    node => node.Left > currentNode.Left &&
                    node.Right < currentNode.Right &&
                    node.Name == lineParts[2] &&
                    node.DepthInTree == currentNode.DepthInTree + 1
                );
            }
        }

        private void AddDirectory(string inputLine)
        {
            if (currentNode == null) return;

            var lineParts = inputLine.Split(' ');

            var prevRight = tree.Where(node => node.Left > currentNode.Left && node.Right < currentNode.Right).MaxBy(node => node.Right)?.Right ?? currentNode.Left;

            foreach (var node in tree.Where(node => node.Right > prevRight))
            {
                node.Right += 2;
            }
            foreach (var node in tree.Where(node => node.Left > prevRight))
            {
                node.Left += 2;
            }

            tree.Add(new FilesTreeNode()
            {
                Left = prevRight + 1,
                Right = prevRight + 2,
                Name = lineParts[1],
                Size = lineParts[0] == "dir" ? 0 : int.Parse(lineParts[0]),
                IsDirectory = lineParts[0] == "dir",
                DepthInTree = currentNode.DepthInTree + 1
            });
        }
    }
}
