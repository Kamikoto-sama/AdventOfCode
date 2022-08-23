using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using AdventOfCode;

var regex = new Regex(@"Day(\d+)");

var lastSolver = Assembly
    .GetExecutingAssembly()
    .GetTypes()
    .Where(x => x.IsAssignableTo(typeof(ISolver)) && !x.IsInterface)
    .OrderByDescending(x => x.Name)
    .First();

var solver = (ISolver)Activator.CreateInstance(lastSolver)!;
var index = regex.Match(lastSolver.Name).Groups[1].Value;

var input = File.ReadAllText($"Input/day{index}.txt");

var stopwatch = Stopwatch.StartNew();
var gcBefore = GC.GetTotalAllocatedBytes(true);
solver.Solve(input);
var gcAfter = GC.GetTotalAllocatedBytes(true);
stopwatch.Stop();

Console.WriteLine("__________________");
Console.WriteLine($"Elapsed: {stopwatch.Elapsed} GC: {gcAfter - gcBefore}");