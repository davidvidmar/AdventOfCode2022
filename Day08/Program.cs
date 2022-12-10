using System.ComponentModel.DataAnnotations;
using System.Security;
using static AdventOfCode2022.Utils;

// https://adventofcode.com/2022/day/8

int result1 = 0;
int result2 = 0;

StartDay(8);

// Part 1
StartPart(1);

var (area, w, h) = ReadIntArray("input.txt");

var visible = 0;
for (int j = 1; j < h - 1; j++) // y-os
{
    for (int i = 1; i < w - 1; i++) // x-os
    {

        // pogled levo
        var vLeft = true;
        for (int x = 0; x < i; x++)
            vLeft &= area[i, j] > area[x, j];
        // pogled desno
        var vRight = true;
        for (int x = i + 1; x < w; x++)
            vRight &= area[i, j] > area[x, j];
        // pogled gor
        var vTop = true;
        for (int y = 0; y < j; y++)
            vTop &= area[i, j] > area[i, y];
        // pogled dol
        var vBottom = true;
        for (int y = j + 1; y < h; y++)
            vBottom &= area[i, j] > area[i, y];
        if (vLeft || vRight || vTop || vBottom)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            visible++;
        }
        //Console.Write(area[i, j]);
        Console.ResetColor();
    }
    Console.WriteLine();
}

result1 = w + w + h + h - 4 + visible;

EndPart(1, result1);

// Part 2
StartPart(2);

int[,] visibleTrees = new int[w, h];
for (int j = 0; j < h; j++) // y-os
{
    for (int i = 0; i < w; i++) // x-os
    {
        // pogled levo
        var vl = 0;
        for (int x = i - 1; x >= 0; x--)
        {
            if (area[i, j] > area[x, j])
                vl++;
            else
            {
                vl++;
                break;
            }
        }
        // pogled desno
        var vr = 0;
        for (int x = i + 1; x < w; x++)
        {
            if (area[i, j] > area[x, j])
                vr++;
            else
            {
                vr++;
                break;
            }
        }
        // pogled gor
        var vt = 0;
        for (int y = j - 1; y >= 0; y--)
        {
            if (area[i, j] > area[i, y])
                vt++;
            else
            {
                vt++;
                break;
            }
        }
        // pogled dol
        var vb = 0;
        for (int y = j + 1; y < h; y++)
        {
            if (area[i, j] > area[i, y])
                vb++;
            else
            {
                vb++;
                break;
            }
        }
        visibleTrees[i, j] = vl * vr * vt * vb;
        //Console.Write(visibleTrees[i, j]);
        if (vl * vr * vt * vb > result2)
            result2 = vl * vr * vt * vb;
    }
    Console.WriteLine();
}

EndPart(2, result2);