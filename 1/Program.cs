﻿var firstColumn = new List<int>();
var secondColumn = new List<int>();

var inputPath = "/home/roman/programming/net/advent/input.txt";
var lines = File.ReadLines(inputPath);

foreach (var line in lines)
{
    //each line is a string with two numbers separated by a 1-4 spaces or tabs
    var lineParts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    firstColumn.Add(int.Parse(lineParts[0]));
    secondColumn.Add(int.Parse(lineParts[1]));
}

firstColumn.Sort();
secondColumn.Sort();

int totalColumnsDistance = 0;

for (int i = 0; i < firstColumn.Count; i++)
{
    totalColumnsDistance += Math.Abs(firstColumn[i] - secondColumn[i]);
}

Console.WriteLine("Total distance between columns: " + totalColumnsDistance);