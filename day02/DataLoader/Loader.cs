

namespace DataLoader;

public static class Loader
{
    public static IEnumerable<GameSets> ParseGames(this IEnumerable<string> input)
    {
        List<GameSets> output = new();
        foreach (var item in input)
            output.Add(ParseGame(item));
        return output;
    }

    public static GameSets ParseGame(string input)
    {
        // Game 1: 1 green, 1 blue, 1 red; 1 green, 8 red, 7 blue; 6 blue, 10 red; 4 red, 9 blue, 2 green; 1 green, 3 blue; 4 red, 1 green, 10 blue
        // Get Game Number
        int gameNumber = GetGameNumber(input);

        // Get Sets
        List<ColorSet> gameSets = new();
        var sets = input.Split(": ")[1].Split("; ");
        foreach (var set in sets)
        {
            ColorSet gameSet = GetSet(set);
            gameSets.Add(gameSet);
        }
        return new GameSets(gameNumber, gameSets);
    }

    public static ColorSet GetSet(string set)
    {
        // 1 green, 1 blue, 1 red
        var colors = set.Split(", ").ToList();
        int red = int.Parse(colors.FirstOrDefault(c => c.Contains("red"))?.Split(" ")[0] ?? "0");
        int green = int.Parse(colors.FirstOrDefault(c => c.Contains("green"))?.Split(" ")[0] ?? "0");
        int blue = int.Parse(colors.FirstOrDefault(c => c.Contains("blue"))?.Split(" ")[0] ?? "0");
        return new ColorSet(red, green, blue);
    }

    public static int GetGameNumber(string input)
    {
        string gameNumber = input.Split(":")[0].Split(" ")[1];
        return int.Parse(gameNumber);
    }

    public static IEnumerable<string> LoadRaw(this string fileName)
    {
        List<string> output = new();
        if (!File.Exists(fileName)) return output;

        using var reader = new StreamReader(fileName);
        while (!reader.EndOfStream)
            output.Add(reader.ReadLine()!);
        return output;
    }
}
