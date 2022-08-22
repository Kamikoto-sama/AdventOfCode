using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Year2022
{
    public class Day3
    {
        public static int Solve1()
        {
            var lines = File.ReadAllLines("input/day3.txt");

            var rawNumber = lines[0].Select((_, i) => CalcBit(lines, i));

            var gamma = Convert.ToInt32(string.Join("", rawNumber), 2);
            var epsilon = gamma ^ Convert.ToInt32(new string('1', lines[0].Length), 2);

            return gamma * epsilon;
        }

        private static char CalcBit(string[] lines, int index)
        {
            var count = lines.Count(l => l[index] == '1');
            return count > lines.Length - count ? '1' : '0';
        }

        public static int Solve2()
        {
            var lines = File.ReadAllLines("input/day3.txt");
            var gammaArray = lines;
            var epsilonArray = lines;

            for (var i = 0; i < lines.Length; i++)
            {
                if (gammaArray.Length > 1)
                {
                    var (ones, zeros) = Split(gammaArray, i);
                    gammaArray = ones.Length >= zeros.Length ? ones : zeros;
                }
                if (epsilonArray.Length > 1)
                {
                    var (ones, zeros) = Split(epsilonArray, i);
                    epsilonArray = ones.Length < zeros.Length ? ones : zeros;
                }
            }

            var gamma = Convert.ToInt32(gammaArray.Single(), 2);
            var epsilon = Convert.ToInt32(epsilonArray.Single(), 2);

            return gamma * epsilon;
        }

        private static (string[], string[]) Split(string[] lines, int index)
        {
            var ones = lines.Where(l => l[index] == '1').ToArray();
            var zeros = lines.Where(l => l[index] == '0').ToArray();
            return (ones, zeros);
        }
    }
}