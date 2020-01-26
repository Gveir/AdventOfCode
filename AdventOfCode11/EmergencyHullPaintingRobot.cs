using AdventOfCode02;
using System.Collections.Generic;

namespace AdventOfCode11
{
    public class EmergencyHullPaintingRobot
    {
        private readonly Intcode _processor;
        private Position _position;
        private Direction _direction = Direction.Up;
        private Dictionary<Position, Color> _paintedPanels = new Dictionary<Position, Color>();

        public int PaintendPanelsCount => _paintedPanels.Count;

        public EmergencyHullPaintingRobot(string program)
        {
            _processor = new Intcode(program);
            _position = Position.Start;
        }

        public void PaintHull()
        {
            while (!_processor.IsFinished)
            {
                int currentColor = GetColor();

                _processor.EnqueueInput(currentColor);
                
                _processor.Process();
                long newColor = _processor.Output;

                _processor.Process();
                long turnDirection = _processor.Output;
                
                SetColor((Color)newColor);
                Move((TurnDirection)turnDirection);
            }
        }

        private int GetColor() => (int)(_paintedPanels.TryGetValue(_position, out var color) ? color : Color.Black);

        private void SetColor(Color color)
        {
            if (!_paintedPanels.ContainsKey(_position))
            {
                _paintedPanels.Add(_position, Color.Black);
            }

            _paintedPanels[_position] = color;
        }

        private void Move(TurnDirection turnDirection)
        {
            _direction = (Direction)(((int)_direction + (turnDirection == TurnDirection.Left ? 1 : 3)) % 4);
            _position = _position.Next(_direction);
        }
    }
}
