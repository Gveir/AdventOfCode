using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode15
{
    public class MapExplorer
    {
        private readonly RepairDroid _droid;

        private readonly Dictionary<(int X, int Y), (TileType TileType, int MoveCounter)> _map = new Dictionary<(int, int), (TileType, int)>();

        public IReadOnlyDictionary<(int X, int Y), TileType> Map => _map.ToDictionary(x => x.Key, x=> x.Value.TileType);

        public MapExplorer(RepairDroid droid)
        {
            _droid = droid;
        }
        
        public int Explore()
        {
            _map.TryAdd(_droid.Position, (TileType.Start, 10));
            var path = new Stack<(int X, int Y)>();
            path.Push(_droid.Position);
            
            StatusCode status;
            var currentCommand = MovementCommand.West;

            do
            {
                status = _droid.Move(currentCommand);

                var newPosition = status == StatusCode.Wall ? _droid.Position.Calculate(currentCommand) : _droid.Position;

                if (!_map.ContainsKey(newPosition))
                {
                    _map.Add(newPosition, (TileType.Unknown, 0));
                }

                _map[newPosition] = ((TileType)status, _map[newPosition].MoveCounter + (status == StatusCode.Wall ? 10 : 1));

                if (status == StatusCode.Moved)
                {
                    if (path.Count > 1 && path.ToArray()[1].Equals(newPosition))
                    {
                        path.Pop();
                    }
                    else
                    {
                        path.Push(newPosition);
                    }
                }

                currentCommand = FindNextMove(_droid.Position);
            } while (status != StatusCode.OxygenSystem);

            return path.Count;
        }

        private MovementCommand FindNextMove((int X, int Y) position)
        {
            Dictionary<(int X, int Y), (TileType TileType, int MoveCounter)> potentialPositions = MovementVector.Directions
                .ToDictionary(pos => (pos.Key.X + position.X, pos.Key.Y + position.Y),
                    pos => _map.GetValueOrDefault((pos.Key.X + position.X, pos.Key.Y + position.Y), (TileType.Unknown, 0)));
            var nextPosition = potentialPositions
                .OrderByDescending(pos => pos.Value.TileType)
                .ThenBy(pos => pos.Value.MoveCounter)
                .ThenBy(pos => pos.Key.X)
                .ThenBy(pos => pos.Key.Y)
                .Select(pos => pos.Key)
                .First();

            return MovementVector.Directions[(nextPosition.X - position.X, nextPosition.Y - position.Y)];
        }
    }
}
