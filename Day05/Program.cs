using System.Collections.Generic;
using System.Text.RegularExpressions;
using static AdventOfCode2022.Utils;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    // https://adventofcode.com/2022/day/5

    static void Main()
    {
        var result1 = "";
        var result2 = "";

        StartDay(5);

        //var stacks = new List<string>()
        //    {
        //        "ZN",
        //        "MCD",
        //        "P",
        //    };

        var stacks = new List<string>()
        {
            "FHBVRQDP",
            "LDZQWV",
            "HLZQGRPC",
            "RDHFJVB",
            "ZWLC",
            "JRPNTGVM",
            "JRLVMBS",
            "DPJ",
            "DCNWV"
        };

        var lines = ReadInputAsLines("input.txt");

        // Part 1
        StartPart(1);

        // PrintStacks(stacks);

        foreach (var line in lines)
        {
            var move = GetMove(line);
            ProcessMove(stacks, move);
        }
        result1 = string.Concat(GetLastItems(stacks));

        //  PrintStacks(stacks);

        EndPart(1, result1);

        // Part 2
        StartPart(2);

        //stacks = new List<string>()
        //    {
        //        "ZN",
        //        "MCD",
        //        "P",
        //    };

        stacks = new List<string>()
        {
            "FHBVRQDP",
            "LDZQWV",
            "HLZQGRPC",
            "RDHFJVB",
            "ZWLC",
            "JRPNTGVM",
            "JRLVMBS",
            "DPJ",
            "DCNWV"
        };

        foreach (var line in lines)
        {
            var move = GetMove(line);
            ProcessMove2(stacks, move);
        }
        result2 = string.Concat(GetLastItems(stacks));

        EndPart(2, result2);
    }

    private static void ProcessMove(List<string> stacks, (int, int, int) move)
    {
        for (int i = 0; i < move.Item1; i++)
        {
            stacks[move.Item3 - 1] = stacks[move.Item3 - 1] + stacks[move.Item2 - 1].Last();
            stacks[move.Item2 - 1] = stacks[move.Item2 - 1].Substring(0, stacks[move.Item2 - 1].Length - 1);
        }
    }

    private static void ProcessMove2(List<string> stacks, (int, int, int) move)
    {
        stacks[move.Item3 - 1] = stacks[move.Item3 - 1] + stacks[move.Item2 - 1].Substring(stacks[move.Item2 - 1].Length - move.Item1);
        stacks[move.Item2 - 1] = stacks[move.Item2 - 1].Substring(0, stacks[move.Item2 - 1].Length - move.Item1);        
    }

    private static void PrintStacks(List<List<char>> stacks)
    {
        foreach (var stack in stacks)
        {
            Console.WriteLine(string.Concat(stack));
        }
    }

    private static IEnumerable<char> GetLastItems(List<string> stacks)
    {
        foreach (var stack in stacks)
        {
            yield return stack.Last();
        }
    }

    private static (int, int, int) GetMove(string line)
    {
        var regex = new Regex(@"move (\d+) from (\d+) to (\d+)");
        var match = regex.Match(line);

        // If the regex didn't match, throw an exception.
        if (!match.Success)
        {
            throw new ArgumentException("Invalid move command: " + line);
        }

        // Parse the three numbers from the regex match.
        var x = int.Parse(match.Groups[1].Value);
        var y = int.Parse(match.Groups[2].Value);
        var z = int.Parse(match.Groups[3].Value);

        return (x, y, z);
    }

}