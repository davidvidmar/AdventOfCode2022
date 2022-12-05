#define LOG

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2022
{
    public static class Utils
    {
        static readonly Stopwatch[] watches = { new Stopwatch(), new Stopwatch() };

        public static void StartDay(int day)
        {
            Console.WriteLine($"Advent of Code 2022 - Day {day}");
        }

        public static void StartPart(int part)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nPart {part}\n");
            Console.ResetColor();

            watches[part - 1].Start();
        }

        public static void EndPart(int part, long value = 0)
        {
            EndPart(part, value != 0 ? value.ToString() : "");
        }

        public static void EndPart(int part, string value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nResult  = {value}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Elapsed = {watches[part - 1].Elapsed}\n");
            Console.ResetColor();
        }

        public static void Wait()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any key...");
            Console.ResetColor();
            Console.ReadKey();
        }

        public static string[] ReadInputAsLines(string filename = "input.txt")
        {
            return File.ReadAllLines(filename);
        }

        public static IEnumerable<Int32> ReadInputAsIntLines(string filename = "input.txt")
        {
            return from q in File.ReadAllLines(filename) select Convert.ToInt32(q);
        }

        public static IEnumerable<long> ReadInputAsLongLines(string filename = "input.txt")
        {
            return from q in File.ReadAllLines(filename) select Convert.ToInt64(q);
        }

        public static IEnumerable<Int32> ReadInputAsIntArray(string filename = "input.txt")
        {
            var inputFile = File.ReadAllText(filename);
            return from q in inputFile.Split(',') select Convert.ToInt32(q);
        }


        public static IEnumerable<string[]> ReadInputAsStringArrays(string filename = "input.txt")
        {
            return from q in File.ReadAllLines(filename) select q.Split(',');
        }

        public static (int[,] area, int cols, int lines) ReadIntArray(string filename = "input.txt")
        {
            var inputFile = File.ReadAllLines(filename);

            var lines = inputFile.Length;
            var cols = inputFile[0].Length;

            var area = new int[cols, lines];

            for (int l = 0; l < lines; l++)
            {
                var s = inputFile[l];
                for (int c = 0; c < cols; c++)
                {
                    area[c, l] = Convert.ToInt32(s[c].ToString());
                }
            }
            return (area, cols, lines);
        }


        public static void Log(object s)
        {
#if LOG
            Console.Write(s);
#endif
        }

        public static void LogLine()
        {
#if LOG
            Console.WriteLine();
#endif
        }

        public static void LogLine(object s)
        {
#if LOG
            Console.WriteLine(s);
#endif
        }


        public static string Xor(string key, string input)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
                sb.Append((char)(input[i] ^ key[(i % key.Length)]));
            var result = sb.ToString();
            return result;
        }
    }
}