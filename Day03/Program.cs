using static AdventOfCode2022.Utils;

class Program
{
    // https://adventofcode.com/2022/day/3#part2

    static void Main()
    {
        int result1 = 0;
        int result2 = 0;

        StartDay(4);

        // Part 1
        StartPart(1);

        var lines = ReadInputAsLines("input.txt").ToArray();

        foreach (var line in lines)
        {
            var left = line.Substring(0, line.Length / 2);
            var right = line.Substring(left.Length);

            var common = CommonChars(left, right);
            var priority = ToPriority(common[0]);

            result1 += priority;

            Console.WriteLine($"{left} x {right} == {common} - {priority}");
        }

        EndPart(1, result1);

        // Part 2
        StartPart(2);

        for (int i = 0; i < (int)(lines.Length / 3); i++)
        {
            var first = lines[i*3];
            var second = lines[i*3 + 1];
            var third = lines[i*3 + 2];

            var commonFirstSecond = CommonChars(first, second);
            var common = CommonChars(commonFirstSecond, third);

            var priority = ToPriority(common[0]);

            Console.WriteLine($"{first} x {second} x {third} == {common} - {priority}");

            result2 += priority;
        }

        // ...

        EndPart(2, result2);
    }

    private static string CommonChars(string s1, string s2)
    {
        var result = "";
        foreach (char c in s1)
        {
            if (s2.Contains(c))
                if (!result.Contains(c))
                    result += c;
        }
        return result;
    }

    private static int ToPriority(char c)
    {
        if (char.IsUpper(c))
            return (int)c - 38;
        else
            return (int)c - 96;
    }
}