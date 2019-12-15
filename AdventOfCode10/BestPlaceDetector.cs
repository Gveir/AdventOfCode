using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode10
{
    internal class Asteroid
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Asteroid(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"X:{X}/Y:{Y}";
        }
    }

    public class BestPlaceDetector
    {
        public static int Determine(string map)
        {
            var asteroids = FindAllAsteroids(map).ToList();

            int maxCount = 0;

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

                maxCount = count > maxCount ? count : maxCount;
            }

            return maxCount;
        }

        private static int CalculateDetectableAsteroidsCount(Asteroid asteroid, IEnumerable<Asteroid> asteroids)
        {
            HashSet<int> linesOfSight = new HashSet<int>();

            foreach (var a in asteroids.Where(a => a.X != asteroid.X || a.Y != asteroid.Y))
            {
                int dx = asteroid.X - a.X;
                int dy = (asteroid.Y - a.Y) * 1000000;
                var c = dx != 0 ? dy / dx : int.MaxValue;

                linesOfSight.Add(c);
            }

            return linesOfSight.Count;
        }

        private static IEnumerable<Asteroid> FindAllAsteroids(string map)
        {
            var lines = map.Split(Environment.NewLine);

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == '#')
                    {
                        yield return new Asteroid(j, i);
                    }
                }
            }
        }
    }
}
