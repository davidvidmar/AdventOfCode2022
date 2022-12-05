using static AdventOfCode2022.Utils;

class Program
{
    // https://adventofcode.com/2022/day/2

    private const int lose = 0;
    private const int draw = 3;
    private const int wins = 6;

    private const int rock = 1;
    private const int paper = 2;
    private const int scissors = 3;
    
    static void Main()
    {
        int result1 = 0;
        int result2 = 0;

        StartDay(2);

        // Part 1
        StartPart(1);

        var lines = ReadInputAsLines("input.txt").ToArray();

        // he: A = rock = 1, B = paper = 2, C = scissors = 3
        // me: X = rock, Y = paper, Z = scissors
        // 0 = loss, 3 = draw, 6 = win

        foreach (var line in lines)
        {
            int play = (int)line[2] - 87;
            int win = PlayRockPaperScissors(line[0], line[2]);
            
            var round = win + play;

            result1 += round;

            Console.WriteLine($"{line[0]} vs {line[2]} -> {play} + {win} = {round}");
        }

        EndPart(1, result1);

        // Part 2
        StartPart(2);

        foreach (var line in lines)
        {
            int result = (int)line[2] - 87;
            var (play, score) = PlayRockPaperScissors2(line[0], line[2]);

            var round = play + score;

            result2 += round;

            Console.WriteLine($"{line[0]} vs {line[2]} -> {play} + {score} = {round}");
        }

        EndPart(2, result2);
    }

    private static int PlayRockPaperScissors(char he, char me)
    {
        switch (he)
        {
            case 'A':
                switch (me)
                {
                    case 'X': return draw; // rock vs rock
                    case 'Y': return wins;  // rock vs paper
                    case 'Z': return lose; // rock vs scissors
                    default: break;
                }
                throw new InvalidOperationException();
            case 'B':
                switch (me)
                {
                    case 'X': return lose; // paper vs rock
                    case 'Y': return draw; // paper vs paper
                    case 'Z': return wins; // paper vs scissors
                    default:
                        break;
                }
                throw new InvalidOperationException();
            case 'C':
                switch (me)
                {
                    case 'X': return wins; // scissors vs rock
                    case 'Y': return lose; // scissors vs paper
                    case 'Z': return draw; // scissors vs scissors
                    default:
                        break;
                }
                throw new InvalidOperationException();
            default:
                break;
        }
        throw new InvalidOperationException();
    }

    private static (int, int) PlayRockPaperScissors2(char he, char result)
    {
        // he: A = rock, B = paper, C = scissors
        // me: X = rock = 1, Y = paper = 2, Z = scissors = 3

        switch (he)
        {
            case 'A': // rock
                switch (result)
                {
                    case 'X': return (scissors, lose); // lose: rock vs scissors
                    case 'Y': return (rock, draw);     // draw: rock vs rock
                    case 'Z': return (paper, wins);    // win: rock vs paper
                    default: break;
                }
                throw new InvalidOperationException();
            case 'B': // paper
                switch (result)
                {
                    case 'X': return (rock, lose);     // lose: paper vs rock
                    case 'Y': return (paper, draw);    // draw: paper vs paper
                    case 'Z': return (scissors, wins); // win: paper vs scissors
                    default:
                        break;
                }
                throw new InvalidOperationException();
            case 'C':
                switch (result) // scissors
                {
                    case 'X': return (paper, lose);    // lose: scissors vs rock
                    case 'Y': return (scissors, draw); // draw: scissors vs paper
                    case 'Z': return (rock, wins);     // win: scissors vs scissors
                    default:
                        break;
                }
                throw new InvalidOperationException();
            default:
                break;
        }
        throw new InvalidOperationException();
    }
}