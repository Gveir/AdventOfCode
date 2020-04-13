using AdventOfCode02;

namespace AdventOfCode15
{
    public class RepairDroid
    {
        private readonly Intcode _processor;
        
        public (int X, int Y) Position { get; private set; }
        public TileType TileType { get; private set; }
        public int MoveCounter { get; private set; }

        public RepairDroid(string program)
        {
            _processor = new Intcode(program);
            MoveCounter = 0;
            Position = (0, 0);
        }

        private RepairDroid(Intcode processor, (int, int) position, TileType tileType, int moveCounter)
        {
            _processor = processor;
            Position = position;
            TileType = tileType;
            MoveCounter = moveCounter;
        }

        public RepairDroid Move(MovementCommand command)
        {
            _processor.EnqueueInput((long)command);
            _processor.Process();
            StatusCode status = (StatusCode)_processor.Output;

            return new RepairDroid(_processor.Clone(), Position.Calculate(command), (TileType)status, MoveCounter + 1);
        }

        public RepairDroid Clone() => new RepairDroid(_processor.Clone(), Position, TileType, MoveCounter);
    }
}
