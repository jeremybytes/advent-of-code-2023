using DataLoader;
using Day02;

var fileName = AppDomain.CurrentDomain.BaseDirectory + "input.txt";
var games = Loader.LoadRaw(fileName).ParseGames();

int maxRed = 12;
int maxGreen = 13;
int maxBlue = 14;

int runningTotal = 0;
foreach (var game in games)
{
    bool include = true;
    foreach(var set in game.Sets)
    {
        if (set.Red > maxRed || set.Green > maxGreen || set.Blue > maxBlue)
        {
            include = false;
            break;
        }
    }
    if (include) runningTotal += game.GameNumber;
}

Console.WriteLine(runningTotal);

int minSets = 0;
foreach(var game in games)
{
    int power = game.MinimumColors().GetColorSetPower();
    minSets += power;
}

Console.WriteLine(minSets);

// Part 1: 3035
// Part 2: 66027