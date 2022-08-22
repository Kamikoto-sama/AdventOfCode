using System.IO;

namespace Year2022
{
    public class Day2
    {
        public static int Solve1()
        {
            var hor = 0;
            var depth = 0;

            foreach (var line in File.ReadLines("input/day2.txt"))
            {
                var (name, value) = ParseCommand(line);

                switch (name)
                {
                    case "forward":
                        hor += value;
                        break;
                    case "down":
                        depth += value;
                        break;
                    case "up":
                        depth -= value;
                        break;
                }
            }

            return hor * depth;
        }

        public static int Solve2()
        {
            var hor = 0;
            var depth = 0;
            var aim = 0;

            foreach (var line in File.ReadLines("input/day2.txt"))
            {
                var (name, value) = ParseCommand(line);

                switch (name)
                {
                    case "forward":
                        hor += value;
                        depth += aim * value;
                        break;
                    case "down":
                        aim += value;
                        break;
                    case "up":
                        aim -= value;
                        break;
                }
            }

            return hor * depth;
        }

        private static (string, int) ParseCommand(string line)
        {
            var @params = line.Split();
            return (@params[0], int.Parse(@params[1]));
        }
    }
}