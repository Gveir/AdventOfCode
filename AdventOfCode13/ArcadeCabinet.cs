using AdventOfCode02;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode13
{
    public class ArcadeCabinet
    {
        private readonly Intcode _processor;
        private readonly Dictionary<(long X, long Y), Tile> _screen = new Dictionary<(long X, long Y), Tile>();
        
        public ArcadeCabinet(string program)
        {
            _processor = new Intcode(program);
        }

        public void Play()
        {
            while (!_processor.IsFinished)
            {
                _processor.Process();
                var x = _processor.Output;
                _processor.Process();
                var y = _processor.Output;
                _processor.Process();
                Tile newTile = (Tile)_processor.Output;
                
                if (!_screen.TryGetValue((x, y), out _))
                {
                    _screen.Add((x, y), newTile);
                }
                else
                {
                    _screen[(x, y)] = newTile;
                }
            }
        }

        public int BlockTilesCount => _screen.Values.Count(t => t == Tile.Block);
    }
}
