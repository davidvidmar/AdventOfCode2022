using System.Collections.Generic;
using static AdventOfCode2022.Utils;

class Program
{
    // https://adventofcode.com/2022/day/4

    static void Main()
    {
        int result1 = 0;
        int result2 = 0;

        StartDay(4);

        // Part 1
        StartPart(1);

        var lines = ReadInputAsLines("input.txt");

        foreach (var line in lines)
        {
            var (p1, p2) = ExpandPair(line);
            if (ContainsAllElements(p1, p2) || ContainsAllElements(p2, p1)) {
                result1++;
                Console.WriteLine($"{result1}: {line}");
            }
        }

        EndPart(1, result1);

        // Part 2
        StartPart(2);

        foreach (var line in lines)
        {
            var (p1, p2) = ExpandPair(line);
            if (Overlaps(p1, p2) || Overlaps(p2, p1))
            {
                result2++;
                Console.WriteLine($"{result2}: {line}");
            }
        }

        EndPart(2, result2);
    }

    private static (List<int>, List<int>) ExpandPair(string line)
    {
        var s = line.Split(',');

        var first = ExpandSection(s[0]);
        var second = ExpandSection(s[1]);

        return (first, second);
    }

    private static List<int> ExpandSection(string section)
    {
        var range = section.Split('-');

        int start = int.Parse(range[0]);
        int end = int.Parse(range[1]);

        var result = new List<int>();
        for (int i = start; i <= end; i++)
        {
            result.Add(i);
        }
        return result;
    }

    static bool ContainsAllElements(List<int> list1, List<int> list2)
    {
        // Loop through all the elements in list2 and check if they are contained in list1
        foreach (int element in list2)
        {
            if (!list1.Contains(element))
            {
                return false;
            }
        }
        return true;
    }

    static bool Overlaps(List<int> list1, List<int> list2)
    {
        // Loop through all the elements in list1 and check if they are contained in list2
        foreach (int element in list2)
        {
            if (!list1.Contains(element))
            {
                return true;
            }
        }
        return false;
    }
}