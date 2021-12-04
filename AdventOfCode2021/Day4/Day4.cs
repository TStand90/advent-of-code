using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.Day4
{
    internal class BingoBoard
    {
        private readonly int[,] _board = new int[5, 5];
        private readonly bool[,] _hits = new bool[5, 5];
        
        public BingoBoard(IReadOnlyList<int> numbers)
        {
            for (var x = 0; x < 5; x++)
            {
                for (var y = 0; y < 5; y++)
                {
                    var currentNumber = numbers[y + (x * 5)];

                    _board[x, y] = currentNumber;
                }
            }
        }
        
        public void Hit(int targetNumber)
        {
            for (var x = 0; x < 5; x++)
            {
                for (var y = 0; y < 5; y++)
                {
                    var currentNumber = _board[x, y];

                    if (currentNumber == targetNumber)
                    {
                        _hits[x, y] = true;

                        break;
                    }
                }
            }
        }

        public bool IsWinner()
        {
            for (var x = 0; x < 5; x++)
            {
                if (_hits[x, 0] && _hits[x, 1] && _hits[x, 2] && _hits[x, 3] && _hits[x, 4])
                {
                    return true;
                }
            }

            for (var y = 0; y < 5; y++)
            {
                if (_hits[0, y] && _hits[1, y] && _hits[2, y] && _hits[3, y] && _hits[4, y])
                {
                    return true;
                }
            }

            return false;
        }

        public int GetSumOfUnmarkedNumbers()
        {
            var sum = 0;
            
            for (var x = 0; x < 5; x++)
            {
                for (var y = 0; y < 5; y++)
                {
                    if (!_hits[x, y])
                    {
                        sum += _board[x, y];
                    }
                }
            }

            return sum;
        }
    }
    
    public static class Day4
    {
        private static (List<int>, List<BingoBoard>) GetInput()
        {
            var lines = File.ReadAllLines("Day4/input.txt");

            var numbersAsString = lines[0];

            List<int> numbers = numbersAsString.Split(',').Select(int.Parse).ToList();

            List<BingoBoard> boards = new();

            List<int> boardNumbers = new();

            for (var i = 2; i < lines.Length; i++)
            {
                var currentLine = lines[i];

                if (currentLine == "")
                {
                    boards.Add(new BingoBoard(boardNumbers));
                    
                    boardNumbers = new List<int>();
                }
                else
                {
                    boardNumbers.AddRange(lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
                }
            }

            return (numbers, boards);
        }
        
        public static int PartOne()
        {
            (List<int> numbers, List<BingoBoard> boards) = GetInput();

            foreach (var currentNumber in numbers)
            {
                foreach (var board in boards)
                {
                    board.Hit(currentNumber);

                    if (board.IsWinner())
                    {
                        return board.GetSumOfUnmarkedNumbers() * currentNumber;
                    }
                }
            }

            // This should never be reached, theoretically.
            return 0;
        }

        public static int PartTwo()
        {
            (List<int> numbers, List<BingoBoard> boards) = GetInput();

            foreach (var currentNumber in numbers)
            {
                BingoBoard? currentBoard = null;
                
                for (var i = boards.Count - 1; i >= 0; i--)
                {
                    var board = boards[i];
                    currentBoard = board;
            
                    board.Hit(currentNumber);
            
                    if (board.IsWinner())
                    {
                        boards.RemoveAt(i);
                    }
                }
                
                if (boards.Count == 0 && currentBoard != null)
                {
                    return currentBoard.GetSumOfUnmarkedNumbers() * currentNumber;
                }
            }
            
            // This should never be reached, theoretically.
            return 0;
        }
    }
}