// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Reflection;

using AdventOfCode2021.Day1;
using AdventOfCode2021.Day2;
using AdventOfCode2021.Day3;

List<int> daysToRun = new();

foreach (var arg in args)
{
    try
    {
        daysToRun.Add(int.Parse(arg));
    }
    catch
    {
        Console.WriteLine($"Invalid argument: ${arg}, please give only a space separated list of numbers");
    }
    
    Console.WriteLine(arg);
}

foreach (var dayToRun in daysToRun)
{
    var t = Type.GetType($"Day{dayToRun}");
    
    MethodInfo method = t.GetMethod("PartOne", BindingFlags.Static | BindingFlags.Public);

    method.Invoke(null, null);
}

Console.WriteLine($"Day 1 | Part 1: {Day1.PartOne()}");
Console.WriteLine($"Day 1 | Part 2: {Day1.PartTwo()}");

Console.WriteLine($"Day 2 | Part 1: {Day2.PartOne()}");
Console.WriteLine($"Day 2 | Part 2: {Day2.PartTwo()}");

Console.WriteLine($"Day 3 | Part 1: {Day3.PartOne()}");
Console.WriteLine($"Day 3 | Part 2: {Day3.PartTwo()}");
