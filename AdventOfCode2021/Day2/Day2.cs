using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.Day2
{
    public static class Day2
    {
        private static List<Tuple<string, int>> GetInput()
        {
            var lines = File.ReadAllLines("Day2/input.txt");

            return lines.Select(
                line => line.Split(' '))
                .Select(splitLine => 
                new Tuple<string, int>(splitLine[0], int.Parse(splitLine[1])))
                .ToList();
        }
        
        public static int PartOne()
        {
            var verticalPosition = 0;
            var horizontalPosition = 0;
            
            var inputs = GetInput();

            foreach (var (direction, unit) in inputs)
            {
                switch (direction)
                {
                    case "forward":
                        horizontalPosition += unit;
                        break;
                    case "up":
                        verticalPosition -= unit;
                        break;
                    case "down":
                        verticalPosition += unit;
                        break;
                }
            }
            
            return verticalPosition * horizontalPosition;
        }

        public static int PartTwo()
        {
            var verticalPosition = 0;
            var horizontalPosition = 0;
            var aim = 0;
            
            var inputs = GetInput();
            
            foreach (var (direction, unit) in inputs)
            {
                switch (direction)
                {
                    case "forward":
                        horizontalPosition += unit;
                        verticalPosition += aim * unit;
                        break;
                    case "up":
                        aim -= unit;
                        break;
                    case "down":
                        aim += unit;
                        break;
                }
            }
            
            return verticalPosition * horizontalPosition;
        }
    }
}