using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode15
{
    public class MapExplorer
    {
        private readonly Dictionary<(int X, int Y), TileType> _map = new Dictionary<(int, int), TileType>
        {
            { (0, 0), TileType.Start }
        };

        private readonly string _program;

        public IReadOnlyDictionary<(int X, int Y), TileType> Map => _map;
        public (int X, int Y) OxygenSystemPosition => Map.Where(x => x.Value == TileType.OxygenSystem).Select(x => x.Key).SingleOrDefault();

        public MapExplorer(string program)
        {
            _program = program;
        }

        public int Explore()
        {
            Queue<(RepairDroid, MovementCommand)> droids = new Queue<(RepairDroid, MovementCommand)>(
                MovementCommand.All.Select(c => (new RepairDroid(_program), c)));

            int movesToOxygen = 0;

            while (droids.Count > 0)
            {
                var (droid, command) = droids.Dequeue();

                var droidAfterMove = droid.Move(command);

                _map.TryAdd(droidAfterMove.Position, droidAfterMove.TileType);

                if (droidAfterMove.TileType == TileType.OxygenSystem)
                {
                    movesToOxygen = droidAfterMove.MoveCounter;
                }

                if (droidAfterMove.TileType == TileType.Empty)
                {
                    foreach (var c in MovementCommand.AllExcept(command.Opposite))
                    {
                        droids.Enqueue((droidAfterMove.Clone(), c));
                    }
                }
            }

            return movesToOxygen;
        }
    }
}
