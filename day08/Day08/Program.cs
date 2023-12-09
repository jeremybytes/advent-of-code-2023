using DataLoader;
using Day08;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

var fileName = AppDomain.CurrentDomain.BaseDirectory + "input.txt";

string directions = fileName.LoadDirections()!;
var map = fileName.LoadRawMap().ParseMap();

long stepCount = 0;
int directionCount = 0;
string currentLocation = "AAA";
while (currentLocation != "ZZZ")
{
    stepCount++;
    if (directionCount >= directions.Count())
        directionCount = 0;
    char currentDirection = directions[directionCount];

    currentLocation = currentLocation.GetNextStep(currentDirection, map);
    directionCount++;
}

Console.WriteLine(stepCount);

Console.WriteLine($"Start Time: {DateTimeOffset.Now:hh:mm:ss}");

// Ghost Path
List<string> locations = map.Where(d => d.Key.EndsWith("A")).Select(d => d.Key).ToList();

List<ulong> steps = [];
for (int i = 0; i < locations.Count; i++)
{
    ulong ghostCount = 0;
    directionCount = 0;

    while (!locations[i].EndsWith("Z"))
    {
        ghostCount++;
        if (directionCount >= directions.Count())
            directionCount = 0;
        char currentDirection = directions[directionCount];

        locations[i] = locations[i].GetNextStep(currentDirection, map);
        directionCount++;
    }
    steps.Add(ghostCount);
}

foreach (var step in steps)
{
    Console.WriteLine(step);
}

static List<ulong> GetPrimes(ulong number)
{
    var primes = new List<ulong>();

    for (ulong div = 2; div <= number; div++)
        while (number % div == 0)
        {
            primes.Add(div);
            number = number / div;
        }

    return primes;
}

List<ulong> primes = [];
foreach(ulong step in steps)
{
    primes.AddRange(GetPrimes(step));
}

ulong ghostSteps = primes.Distinct().Aggregate((first, second) => first * second);

Console.WriteLine(ghostSteps);

// Part 1 = 17287
// Part 2 = 18625484023687
