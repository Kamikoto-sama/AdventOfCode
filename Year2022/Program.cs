using System;
using System.Diagnostics;

namespace Year2022
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();
            Console.WriteLine(Day3.Solve2());
            Console.WriteLine(sw.Elapsed);
        }
    }
}