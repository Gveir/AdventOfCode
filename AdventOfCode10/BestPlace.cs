namespace AdventOfCode10
{
    public class BestPlace
    {
        public Asteroid Asteroid { get; private set; }

        public int DetectionRatio { get; private set; }

        public BestPlace(Asteroid asteroid, int detectionRatio)
        {
            Asteroid = asteroid;
            DetectionRatio = detectionRatio;
        }
    }
}
