using Day06;

//Time:      42     68     69     85
//Distance: 284   1005   1122   1341

//Time:      42686985
//Distance: 284100511221341

List<(long, long)> races = [(42, 284), (68, 1005), (69, 1122), (85, 1341)];

(long, long) realRace = (42686985, 284100511221341);

List<long> possibles = [];
foreach(var race in races)
{
    possibles.Add(race.NumberOfWins());
}

long wins = possibles.Aggregate((first, second) => first * second);
Console.WriteLine(wins);

wins = realRace.NumberOfWins();
Console.WriteLine(wins);

// Part 1 = 440000
// Part 2 = 26187338
