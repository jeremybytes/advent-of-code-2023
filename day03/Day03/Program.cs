using DataLoader;
using Day03;

var fileName = AppDomain.CurrentDomain.BaseDirectory + "input.txt";
var allData = Loader.LoadRaw(fileName);

var result = allData.GetAllNumbers().GetPartNumbers(allData).Sum();

Console.WriteLine(result);

var gearResult = allData.GetAllNumbers().GetPotentialGears(allData).GetActualGears().GetGearProducts().Sum();

Console.WriteLine(gearResult);

// Part 1 = 540131
// Part 2 = 86879020
