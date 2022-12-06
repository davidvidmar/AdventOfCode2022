using System.Collections.Generic;
using System.Data;
using static AdventOfCode2022.Utils;

class Program
{
    // https://adventofcode.com/2022/day/6

    static void Main()
    {
        int result1 = 0;
        int result2 = 0;

        StartDay(6);

        // Part 1
        StartPart(1);

        var lines = ReadInputAsLines("input.txt");

        foreach (var line in lines)
        {
            result1 = FirstUniqueConsequtiveCharacters(line, 4);
            //Console.WriteLine(" ˙ " + result1);
        }

        EndPart(1, result1);

        // Part 2
        StartPart(2);

        foreach (var line in lines)
        {
            result2 = FirstUniqueConsequtiveCharacters(line, 14);
            //Console.WriteLine(" ˙ " + result2);
        }

        EndPart(2, result2);
    }

    private static int FirstUniqueConsequtiveCharacters(string s, int length)
    {
        var window = "";

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (window.Length == length) { window = window[1..]; }
            window += c;
            //Console.WriteLine(" " + window);
            if (window.Length == length && AreAllCharactersUnique(window)) return i + 1;
        }
        return -1;
    }

    public static bool AreAllCharactersUnique(string s)
    {
        // Create a HashSet to store the unique characters
        HashSet<char> uniqueChars = new();

        // Iterate over the string
        foreach (char c in s)
        {
            // If the character is not in the HashSet, add it
            if (!uniqueChars.Contains(c))
            {
                uniqueChars.Add(c);
            }
        }

        // If the length of the HashSet is the same as the length of the string, all the characters in the string are unique
        return uniqueChars.Count == s.Length;
    }
}