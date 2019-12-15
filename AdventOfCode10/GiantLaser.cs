using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode10
{
    public class GiantLaser
    {
        public static IList<Asteroid> Vaporize(IEnumerable<Asteroid> map, Asteroid @base)
        {
            Dictionary<(int, float), List<Asteroid>> asteroidsOnSlopes = new Dictionary<(int, float), List<Asteroid>>();

            var quadrants = new List<IEnumerable<Asteroid>>
            {
                map.Where(a => a.X >= @base.X && a.Y < @base.Y),
                map.Where(a => a.X >= @base.X && a.Y >= @base.Y),
                map.Where(a => a.X < @base.X && a.Y >= @base.Y),
                map.Where(a => a.X < @base.X && a.Y < @base.Y),
            };

            for (int quadrantIndex = 0; quadrantIndex < quadrants.Count; quadrantIndex++)
            {
                foreach (var asteroid in quadrants[quadrantIndex].Where(a => a.X != @base.X || a.Y != @base.Y))
                {
                    var slope = @base.CalculateSlope(asteroid);

                    if (!asteroidsOnSlopes.ContainsKey((quadrantIndex, slope)))
                    {
                        asteroidsOnSlopes.Add((quadrantIndex, slope), new List<Asteroid>());
                    }

                    asteroidsOnSlopes[(quadrantIndex, slope)].Add(asteroid);
                }
            }

            asteroidsOnSlopes = asteroidsOnSlopes
                .OrderBy(kvp => kvp.Key.Item1)
                .ThenBy(kvp => kvp.Key.Item2)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            List<Asteroid> vaporizedAsteroids = new List<Asteroid>();

            int slopeIndex = 0;

            while (asteroidsOnSlopes.Values.SelectMany(x => x).Any(a => !a.IsDestroyed))
            {
                var slope = asteroidsOnSlopes.Keys.ElementAt(slopeIndex);

                var asteroid = asteroidsOnSlopes[slope].OrderBy(a => @base.Distance(a)).FirstOrDefault(a => !a.IsDestroyed);

                if (asteroid != null)
                {
                    asteroid.Vaporize();
                    vaporizedAsteroids.Add(asteroid);
                }

                slopeIndex = (slopeIndex + 1) % asteroidsOnSlopes.Keys.Count;
            }

            return vaporizedAsteroids;
        }
    }
}
