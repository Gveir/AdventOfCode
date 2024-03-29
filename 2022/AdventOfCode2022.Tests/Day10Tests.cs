﻿using AdventOfCode2022.Day10;

namespace AdventOfCode2022.Tests
{
    public class Day10Tests
    {
        [Theory]
        [InlineData("Examples/Day10.txt", 13140)]
        [InlineData("Input/Day10.txt", 13820)]
        public void CalculateSignalStrengthsSumTest(string inputPath, int expectedSignalsStrengthsSum)
        {
            var input = File.ReadAllLines(inputPath);

            var signalsStrengthsSum = Cpu.CalculateSignalsStrengthsSum(input,
                new int[] { 20, 60, 100, 140, 180, 220 });

            Assert.Equal(expectedSignalsStrengthsSum, signalsStrengthsSum);
        }

        [Theory]
        [InlineData("Examples/Day10.txt", "Examples/Day10.part2.expected.txt")]
        [InlineData("Input/Day10.txt", "Input/Day10.part2.expected.txt")]
        public void DrawOnCrtTest(string inputPath, string expectedImagePatch)
        {
            var inputProgram = File.ReadAllLines(inputPath);
            var expectedImage = File.ReadAllLines(expectedImagePatch);

            var device = new Device(inputProgram);
            device.ProduceImageFrame();
            var producedImage = device.Crt.ImageFrame;

            Assert.Equal(expectedImage, producedImage);
        }
    }
}
