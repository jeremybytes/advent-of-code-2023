using DataLoader;
using Day10;

var fileName = AppDomain.CurrentDomain.BaseDirectory + "input.txt";

var result = fileName.LoadRaw().GetPathLength() / 2;

Console.WriteLine(result);

// Part 1 = 6738

