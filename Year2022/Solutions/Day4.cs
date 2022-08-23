using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode;
using Utils;

namespace Year2022.Solutions;

public class Day4 : ISolver
{
    public void Solve(string input)
    {
        var lines = input.Split("\n");
        var numbers = lines[0].Split(",").Select(int.Parse);
        var boards = lines[2..].Split(string.IsNullOrWhiteSpace).Select(Board.Create).ToHashSet();

        var winners = new List<int>();
        foreach (var number in numbers)
        {
            var wins = boards.Where(x => x.MarkAndCheckWin(number)).ToArray();
            if (wins.Length < 1)
                continue;

            winners.AddRange(wins.Select(x => x.CalculateScore(number)).OrderDesc());
            boards.RemoveRange(wins);
        }

        Console.WriteLine($"Best: {winners.First()}");
        Console.WriteLine($"Last: {winners.Last()}");
    }
}

class Board
{
    private readonly Dictionary<int, (int, int, bool)> nums;
    private readonly int[,] hash;

    private Board(Dictionary<int, (int, int, bool)> nums)
    {
        this.nums = nums;
        hash = new int[5, 2];
    }

    public static Board Create(List<string> numbers)
    {
        var nums = numbers
            .SelectMany((line, i) => line
                .Split(" ")
                .Where(x => x.IsSignificant())
                .Select((x, j) => KeyValuePair.Create(int.Parse(x), (i, j, false))))
            .ToDictionary();

        return new Board(nums);
    }

    public bool MarkAndCheckWin(int num)
    {
        if (!nums.ContainsKey(num))
            return false;

        var (x, y, marked) = nums[num];
        hash[x, 0]++;
        hash[y, 1]++;
        nums[num] = (x, y, true);

        return hash[x, 0] >= 5 || hash[y, 1] >= 5;
    }

    public int CalculateScore(int number) => nums.Where(x => !x.Value.Item3).Sum(x => x.Key) * number;
}
