using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AdventOfCode10.Tests
{
    public class GiantLaserTests
    {
        [Fact]
        public void TestLaserExample()
        {
            List<(int, int)> expectedAsteroids = new List<(int, int)>
            {
                (8, 1), (9, 0), (9, 1), (10, 0), (9, 2), (11, 1), (12, 1), (11, 2), (15, 1),
                (12, 2), (13, 2), (14, 2), (15, 2), (12, 3), (16, 4), (15, 4), (10, 4), (4, 4),
                (2, 4), (2, 3), (0, 2), (1, 2), (0, 1), (1, 1), (5, 2), (1, 0), (5, 1),
                (6, 1), (6, 0), (7, 0), (8, 0), (10, 1), (14, 0), (16, 1), (13, 3), (14, 3)
            };

            var map = MapReader.FindAllAsteroids(File.ReadAllText("LaserExample.txt"));

            BestPlace bestPlace = BestPlaceDetector.Determine(map);

            Assert.True(bestPlace.Asteroid.X == 8 && bestPlace.Asteroid.Y == 3,
                $"Best place: X:{bestPlace.Asteroid.X}/Y:{bestPlace.Asteroid.Y}");

            var vaporizedAsteroids = GiantLaser.Vaporize(map, bestPlace.Asteroid);

            Assert.NotEmpty(vaporizedAsteroids);

            for (int i = 0; i < expectedAsteroids.Count; i++)
            {
                Assert.True(vaporizedAsteroids[i].X == expectedAsteroids[i].Item1 && vaporizedAsteroids[i].Y == expectedAsteroids[i].Item2,
                    $"At position {i} expected location: X:{expectedAsteroids[i].Item1}/Y:{expectedAsteroids[i].Item2}, actual: X:{vaporizedAsteroids[i].X}/Y:{vaporizedAsteroids[i].Y}");
            }
        }

        [Fact]
        public void Find200thAsteroidToBeVaporized()
        {
            var map = MapReader.FindAllAsteroids(File.ReadAllText("Input.txt"));

            BestPlace bestPlace = BestPlaceDetector.Determine(map);

            var vaporizedAsteroids = GiantLaser.Vaporize(map, bestPlace.Asteroid);

            var theAsteroid = vaporizedAsteroids[199];

            Assert.Equal(1419, theAsteroid.X * 100 + theAsteroid.Y);
        }
    }
}
