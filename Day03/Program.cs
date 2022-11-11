using static AdventOfCode2022.Utils;

class Program
{
    static void Main()
    {
        int result1 = 0;
        int result2 = 0;

        StartDay(1);

        // Part 1
        StartPart(1);

        var lines = ReadInputAsIntLines("input.txt").ToArray();

        // ...

        EndPart(1, result1);

        // Part 2
        StartPart(2);

        // ...

        EndPart(2, result2);
    }
}