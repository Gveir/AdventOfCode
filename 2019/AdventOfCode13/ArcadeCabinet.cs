using AdventOfCode02;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode13
{
    public class ArcadeCabinet
    {
        private readonly Intcode _processor;
        private readonly Dictionary<(long X, long Y), Tile> _screen = new Dictionary<(long X, long Y), Tile>();

        public long Score { get; private set; }

        public ArcadeCabinet(string program, bool playForFree = false)
        {
            _processor = new Intcode(program);

            if (playForFree)
            {
                _processor.WriteMemory(0, 2);
            }
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

                if (x == -1 && y == 0)
                {
                    Score = _processor.Output;
                }
                else
                {
                    UpdateScreen((x, y), (Tile)_processor.Output);
                }
            }
        }

        public int BlockTilesCount => _screen.Values.Count(t => t == Tile.Block);

        private void UpdateScreen((long X, long) position, Tile tile)
        {
            if (!_screen.TryGetValue(position, out _))
            {
                _screen.Add(position, Tile.Empty);
            }
            
            _screen[position] = tile;

            if (tile == Tile.Ball)
            {
                var paddle = _screen.Where(kvp => kvp.Value == Tile.Paddle).SingleOrDefault();

               _processor.EnqueueInput(position.X < paddle.Key.X ? -1 : position.X > paddle.Key.X ? 1 : 0);
            }
        }
    }
}
