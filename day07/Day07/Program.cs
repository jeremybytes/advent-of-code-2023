using DataLoader;
using Day07;

var fileName = AppDomain.CurrentDomain.BaseDirectory + "input.txt";

var totalWinnings = fileName.LoadRaw().GetHands().GetOrderedHands().GetTotalWinnings();

Console.WriteLine(totalWinnings);

var totalWildWinnings = fileName.LoadRaw().GetHands().GetWildOrderedHands().GetTotalWinnings();
Console.WriteLine(totalWildWinnings);

// Part 1 = 248559379
// Part 2 = 249631254
