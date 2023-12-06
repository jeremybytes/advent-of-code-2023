using DataLoader;
using Day05;

var fileName = AppDomain.CurrentDomain.BaseDirectory + "input.txt";
var allData = Loader.LoadRaw(fileName);

var seeds = allData.GetSeeds();
var maps = allData.GetMaps();

List<long> results = [];
foreach (var seed in seeds)
{
    long temp = seed;
    foreach(var map in maps)
    {
        temp = temp.GetNextValue(map);
    }
    results.Add(temp);
}

var min = results.Min(v => v);

Console.WriteLine(min);


// Part 2
//var rangedSeeds = allData.GetRangedSeeds();

Console.WriteLine(seeds.Count());

long currentMin = long.MaxValue;
long curr = 0;
var ranges = seeds;
for (int i = 0; i < ranges.Count; i += 2)
{
    Console.WriteLine($"Current seed: {i}");
    for (int x = 0; x < ranges[i + 1]; x++)
    {
        curr = ranges[i] + x;
        foreach (var map in maps)
        {
            curr = curr.GetNextValue(map);
        }
        if (curr < currentMin)
        {
            currentMin = curr;
        }
    }
}

Console.WriteLine($"Minimum: {currentMin}");

// Part 1: 174137457
// Part 2: 1493866