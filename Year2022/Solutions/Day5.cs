using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AdventOfCode;
using Utils;

namespace Year2022.Solutions;

public class Day5 : ISolver
{
    public void Solve(string input)
    {
        var points = input.Split("\n").SelectMany(ParseLine);
        var count = CountPoints(points)
            .Where(x => x.Value > 1)
            .Select(x => x.Value)
            .Sum();

        Console.WriteLine(count);
    }

    private static Dictionary<Point, int> CountPoints(IEnumerable<Point> source)
    {
        var counts = new Dictionary<Point, int>();
        foreach (var item in source)
            if (counts.ContainsKey(item))
                counts[item]++;
            else
                counts[item] = 1;

        return counts;
    }

    private static IEnumerable<Point> ParseLine(string line)
    {
        var (start, end) = line.Split("->");
        var (startX, startY) = start.Split(",").Select(int.Parse);
        var (endX, endY) = end.Split(",").Select(int.Parse);
        return GetPoints(new Point(startX, startY), new Point(endX, endY));
    }

    private static IEnumerable<Point> GetPoints(Point start, Point end)
    {
        var points = new List<Point>();
        for (var x = start.X; Math.Abs(x - end.X) >= 0; x += Math.Sign(end.X - start.X))
        for (var y = start.Y; Math.Abs(y - end.Y) >= 0; y += Math.Sign(end.Y - start.Y))
            points.Add(new Point(x, y));

        return points;
    }
}