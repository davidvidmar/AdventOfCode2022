using AdventOfCode2022;
using Day07;
using static AdventOfCode2022.Utils;

class Program
{
    // https://adventofcode.com/2022/day/7

    static void Main()
    {
        int result1 = 0;
        int result2 = 0;

        StartDay(7);

        // Part 1
        StartPart(1);

        var lines = ReadInputAsLines("input.txt");

        var fs = ProcessLines(lines);

        //Print(structure);

        var dirs = fs.Where(node => node.Data == null && GetSize(node) <= 100000);

        foreach (var item in dirs)
        {
            //Console.Write(item.Key + " " + (item.Data == null ? "(dir)" : item.Data));

            var size = GetSize(item);
            result1 += size;
            //Console.WriteLine(" - " + size);
        }

        EndPart(1, result1);

        // Part 2
        StartPart(2);

        var total = 70000000;
        var target = 30000000;

        var used = GetSize(fs);
        var missing = total - used;

        Console.WriteLine($"total  = {total}");
        Console.WriteLine($"used   = {used}");
        Console.WriteLine($"free   = {total - used}");
        Console.WriteLine($"target = {target}");
        var toDelete = target - (total - used);
        Console.WriteLine($"delete = {toDelete}");

        dirs = fs.Where(node => node.Data == null && GetSize(node) > toDelete);

        var best = used;
        TreeNode<string, int?> dir;
        foreach (var item in dirs)
        {
            var size = GetSize(item);
            if (size < best)
            {
                Console.WriteLine(item.Key + " " + (item.Data == null ? $"(size = {size})" : "item.Data"));
                dir = item;
                best = size;
            }
        }

        result2 = used - best;

        EndPart(2, result2);
    }


    private static void Print(TreeNode<string, int?> node, string indent = "")
    {
        if (node.Data== null)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(indent + "- " + node.Key + " (dir)");
            Console.ResetColor();
        }
        else
            Console.WriteLine(indent + "- " + node.Key + (node.Data != null ? " (file, size=" + node.Data + ")" : " (dir)"));

        foreach (var child in node.Children)
        {
            Print(child, indent + "  ");
        }
    }

    private static int GetSize(TreeNode<string, int?> node)
    {
        if (node.IsLeaf)
            return node.Data ?? 0;

        var sum = 0;
        foreach (var child in node.Children)
        {            
            sum += GetSize(child);
        }
        return sum;
    }

    private static TreeNode<string, int?> ProcessLines(string[] lines)
    {
        var command = "";

        var root = new TreeNode<string, int?>("/", null);
        var current = root;

        foreach (var line in lines)
        {
            //Utils.LogLine(line);
            if (line.StartsWith("$ "))
            {
                // command
                command = null;
                var parsedCommand = line[2..].Split(' ');
                command = parsedCommand[0];
                switch (command) {
                    case "cd":
                        var parm1 = parsedCommand[1];
                        if (parm1 == "/")
                        {
                            current = root;
                        }
                        else if (parm1 == "..")
                        {
                            current = current.Parent;
                        }
                        else
                        {
                            var searchKey = current.Key + parm1 + "/";
                            current = root.FindTreeNode(n => n.Key == searchKey);
                            if (current == null)
                                throw new FileNotFoundException(searchKey);
                        }                            
                        break;
                    case "ls":
                        command = "ls";
                        break;
                    default:
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine($"Command not implemented: {command}");
                        Console.ResetColor();
                        break;
                }
            }
            else
            {
                if (command == "ls")
                {
                    var s = line.Split(" ");
                    if (s[0] == "dir")
                        // dir
                        current.AddChild(current.Key + s[1] + "/", null);
                    else
                    {
                        // file
                        current.AddChild(current.Key + s[1], Convert.ToInt32(s[0]));
                    }
                }
            }
            
        }
        return root;
    }
}