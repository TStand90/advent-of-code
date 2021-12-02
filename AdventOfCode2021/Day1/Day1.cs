using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.Day1
{
    public static class Day1
    {
        private static List<int> GetInput()
        {
            var lines = File.ReadAllLines("Day1/input.txt");
            
            var measurements = lines.Select(int.Parse).ToList();

            return measurements;
        }
        
        public static int PartOne()
        {
            var numberOfTimesDepthIncreased = 0;

            var measurements = GetInput();

            for (var i = 1; i < measurements.Count; i++)
            {
                if (measurements[i] > measurements[i - 1])
                {
                    numberOfTimesDepthIncreased++;
                }
            }

            return numberOfTimesDepthIncreased;
        }

        public static int PartTwo()
        {
            var numberOfTimesDepthIncreased = 0;
            
            var measurements = GetInput();
            var sums = new List<int>();

            for (var i = 0; i < measurements.Count - 2; i++)
            {
                sums.Add(measurements[i] + measurements[i + 1] + measurements[i + 2]);
            }

            for (var i = 1; i < sums.Count; i++)
            {
                if (sums[i] > sums[i - 1])
                {
                    numberOfTimesDepthIncreased++;
                }
            }
            
            return numberOfTimesDepthIncreased;
        }
    }
}