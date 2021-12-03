using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.Day3
{
    public static class Day3
    {
        private static List<string> GetInput()
        {
            var lines = File.ReadAllLines("Day3/input.txt");

            return lines.ToList();
        }

        private static Dictionary<int, Dictionary<int, int>> GetCounts(List<string> binaryStrings)
        {
            var counts = new Dictionary<int, Dictionary<int, int>>();

            for (var index = 0; index < binaryStrings[0].Length; index++)
            {
                counts[index] = new Dictionary<int, int>
                {
                    [0] = 0,
                    [1] = 0
                };
            }

            foreach (var binaryString in binaryStrings)
            {
                for (var index = 0; index < binaryString.Length; index++)
                {
                    var binaryCharacter = binaryString[index];

                    if (binaryCharacter == '0')
                    {
                        counts[index][0] += 1;
                    }
                    else
                    {
                        counts[index][1] += 1;
                    }
                }
            }

            return counts;
        }

        public static int PartOne()
        {
            var inputs = GetInput();

            var inputLength = inputs[0].Length;

            var counts = GetCounts(inputs);

            var gammaRateString = "";
            var epsilonRateString = "";

            for (var i = 0; i < inputLength; i++)
            {
                var countForPlace = counts[i];

                var zeroCount = countForPlace[0];
                var oneCount = countForPlace[1];
                
                if (zeroCount > oneCount)
                {
                    gammaRateString += '0';
                    epsilonRateString += '1';
                }
                else
                {
                    gammaRateString += '1';
                    epsilonRateString += '0';
                }
            }
            
            var gammaRate = Convert.ToInt32(gammaRateString, 2);
            var epsilonRate = Convert.ToInt32(epsilonRateString, 2);
            
            return gammaRate * epsilonRate;
        }

        public static int PartTwo()
        {
            int GetRating(List<string> binaryStrings, bool isOxygenRating, int currentPosition = 0)
            {
                if (binaryStrings.Count == 1)
                {
                    return Convert.ToInt32(binaryStrings[0], 2);
                }
                
                var counts = GetCounts(binaryStrings);

                var countsForPosition = counts[currentPosition];

                var zeroCount = countsForPosition[0];
                var oneCount = countsForPosition[1];

                char value;

                if (isOxygenRating)
                {
                    value = zeroCount > oneCount ? '0' : '1';
                }
                else
                {
                    value = zeroCount <= oneCount ? '0' : '1';
                }
                
                List<string> reducedList = binaryStrings.Where(binaryString => binaryString[currentPosition] == value).ToList();

                return GetRating(reducedList, isOxygenRating, currentPosition + 1);
            }
            
            var inputs = GetInput();

            var inputLength = inputs[0].Length;

            var counts = new Dictionary<int, Dictionary<int, int>>();

            for (var index = 0; index < inputLength; index++)
            {
                counts[index] = new Dictionary<int, int>
                {
                    [0] = 0,
                    [1] = 0
                };
            }

            foreach (var input in inputs)
            {
                for (var index = 0; index < input.Length; index++)
                {
                    var binaryCharacter = input[index];

                    if (binaryCharacter == '0')
                    {
                        counts[index][0] += 1;
                    }
                    else
                    {
                        counts[index][1] += 1;
                    }
                }
            }

            var oxygenGeneratorRating = GetRating(inputs, true);
            var c02ScrubberRating = GetRating(inputs, false);
            
            return oxygenGeneratorRating * c02ScrubberRating;
        }
    }
}