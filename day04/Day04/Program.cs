using DataLoader;
using Day04;

var fileName = AppDomain.CurrentDomain.BaseDirectory + "input.txt";
var allData = Loader.LoadRaw(fileName);

var result = allData.GetCards().GetCardValues().Sum();

Console.WriteLine(result);

var cardCount = allData.GetCards().GetCardCopies().Sum();
Console.WriteLine(cardCount);

// Part 1 = 21088
// Part 2 = 6874754