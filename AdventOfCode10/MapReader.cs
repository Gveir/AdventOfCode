using System;
using System.Collections.Generic;

namespace AdventOfCode10
{
    public class MapReader
    {
        public static IEnumerable<Asteroid> FindAllAsteroids(string map)
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
