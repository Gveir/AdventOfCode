using System.IO;
using Xunit;
using System.Collections.Generic;
using System;
using System.Linq;

namespace AdventOfCode08.Tests
{
    public class CorruptedTransmisionDetectorTests
    {
        [Fact]
        public void Test1()
        {
            var image = File.ReadAllText("Input.txt");

            int width = 25;
            int height = 6;

            int layerSize = width * height;

            var layers = ExtractLayers(image, layerSize);

            var theLayer = layers.OrderBy(layer => layer.Count(pixel => pixel == '0')).First();

            var onesCount = theLayer.Count(pixel => pixel == '1');
            var twosCount = theLayer.Count(pixel => pixel == '2');

            Assert.Equal(1088, onesCount * twosCount);
        }

        private static IEnumerable<string> ExtractLayers(string image, int layerSize)
        {
            for (var i = 0; i < image.Length; i += layerSize)
                yield return image.Substring(i, Math.Min(layerSize, image.Length - i));
        }
    }
}
