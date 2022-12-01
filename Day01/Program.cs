using System;
using System.Collections.Generic;
using System.Linq;
using static AdventOfCode2022.Utils;

class Program
{
    // https://adventofcode.com/2022/day/1
    static void Main()
    {
        int result1 = 0;
        int result2 = 0;

        StartDay(1);

        // Part 1
        StartPart(1);

        var lines = ReadInputAsLines("input.txt").ToArray();

        var elves = new List<int>();
        var sum = 0;
        foreach (var line in lines)
        {
            if (line.Length == 0)
            {
                elves.Add(sum);
                Console.WriteLine(sum);
                sum = 0;
            }
            else
            {
                sum += Convert.ToInt32(line);
            }
        }
        if (sum != 0)
            elves.Add(sum);

        result1 = elves.Max();
        // ...

        EndPart(1, result1);

        // Part 2
        StartPart(2);

        result2 = elves.OrderByDescending(x => x).Take(3).Sum();

        EndPart(2, result2);
    }
}