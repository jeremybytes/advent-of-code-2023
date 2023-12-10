using DataLoader;
using Day09;

var fileName = AppDomain.CurrentDomain.BaseDirectory + "input.txt";

var runningTotal = fileName.LoadRaw().GetSequences().Select(s => s.GetNextInSequence()).Sum();

Console.WriteLine(runningTotal);

var firsts = fileName.LoadRaw().GetSequences().Select(s => s.GetPreviousInSequence()).Sum();

Console.WriteLine(firsts);

// Part 1 = 1637452029
// Part 2 = 908