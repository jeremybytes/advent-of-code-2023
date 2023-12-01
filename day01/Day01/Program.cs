using DataLoader;
using Day01;

var fileName = AppDomain.CurrentDomain.BaseDirectory + "input.txt";
var data = Loader.Load(fileName);

int runningTotal = 0;
foreach(string item in data)
{
    runningTotal += item.FindNumbers().FirstAndLastDigits().CombineTupleToInt();
}

Console.WriteLine(runningTotal);

// Part 1: 53194
// Part 2: 54249