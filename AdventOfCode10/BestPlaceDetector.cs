using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode10
{
    public class BestPlaceDetector
    {
        public static BestPlace Determine(IEnumerable<Asteroid> asteroids)
        {
            BestPlace bestPlace = null;

            foreach (var asteroid in asteroids)
            {
                var quadrants = new List<IEnumerable<Asteroid>>
                {
                    asteroids.Where(a => a.X > asteroid.X && a.Y > asteroid.Y),
                    asteroids.Where(a => a.X > asteroid.X && a.Y <= asteroid.Y),
                    asteroids.Where(a => a.X <= asteroid.X && a.Y > asteroid.Y),
                    asteroids.Where(a => a.X <= asteroid.X && a.Y <= asteroid.Y),
                };

                var count = quadrants.Sum(quadrrantAsteroids => CalculateDetectableAsteroidsCount(asteroid, quadrrantAsteroids));

                if (bestPlace == null || bestPlace.DetectionRatio < count)
                {
                    bestPlace = new BestPlace(asteroid, count);
                }
            }

            return bestPlace;
        }

        private static int CalculateDetectableAsteroidsCount(Asteroid asteroid, IEnumerable<Asteroid> asteroids)
        {
            HashSet<float> linesOfSight = new HashSet<float>();

            foreach (var a in asteroids.Where(a => a.X != asteroid.X || a.Y != asteroid.Y))
            {
                linesOfSight.Add(asteroid.CalculateSlope(a));
            }

            return linesOfSight.Count;
        }
    }
}
