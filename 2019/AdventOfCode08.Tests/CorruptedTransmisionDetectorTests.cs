using System.IO;
using Xunit;
using System.Collections.Generic;
using System;
using System.Linq;
using Xunit.Abstractions;

namespace AdventOfCode08.Tests
{
    public class CorruptedTransmisionDetectorTests
    {
        private readonly ITestOutputHelper _output;

        public CorruptedTransmisionDetectorTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test()
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

            var decodedImage = string.Join("", Enumerable.Range(0, width * height).Select(i => '2')).ToArray();

            foreach (var layer in layers)
            {
                for (int i = 0; i < layer.Length; i++)
                {
                    if (decodedImage[i] == '2')
                    {
                        decodedImage[i] = layer[i];
                    }
                }
            }

            var theImageLines = ExtractLayers(new string(decodedImage.Select(ch => ch == '0' ? ' ' : ch).ToArray()), width);

            foreach (var line in theImageLines)
            {
                _output.WriteLine(line);
            }
        }

        private static IEnumerable<string> ExtractLayers(string image, int layerSize)
        {
            for (var i = 0; i < image.Length; i += layerSize)
                yield return image.Substring(i, Math.Min(layerSize, image.Length - i));
        }
    }
}
