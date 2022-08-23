using System.IO;
using System.Linq;

namespace Year2022.Solutions
{
    public class Day1
    {
        public static int Solve1()
        {
            return File.ReadLines("input/day1.txt")
                .Select(int.Parse)
                .Aggregate((Prev: int.MaxValue, Total: 0), (accum, current) =>
                {
                    if (current > accum.Prev)
                        accum.Total++;
                    accum.Prev = current;
                    return accum;
                }).Total;
        }

        public static int Solve2()
        {
            var values = File.ReadLines("input/day1.txt").Select(int.Parse).ToList();
            return values
                .Skip(3)
                .Where((value, index) => value + values[index + 1] + values[index + 2] > values[index] + values[index + 1] + values[index + 2])
                .Count();
        }
    }
}