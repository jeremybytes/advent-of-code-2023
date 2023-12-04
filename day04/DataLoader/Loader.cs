namespace DataLoader;

public static class Loader
{
    public record Card(List<int> Winners, List<int> MyNumbers);

    public static List<Card> GetCards(this List<string> input)
    {
        List<Card> cards = [];
        foreach(string line in input)
        {
            var numbers = line.Split(":")[1].Split("|");

            List<int> winners = 
                numbers[0]
                .Split(" ")
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(n => int.Parse(n.Trim()))
                .ToList();

            List<int> mine =
                numbers[1]
                .Split(" ")
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(n => int.Parse(n.Trim()))
                .ToList();

            cards.Add(new(winners, mine));
        }
        return cards;
    }

    public static List<string> LoadRaw(this string fileName)
    {
        List<string> output = [];
        if (!File.Exists(fileName)) return output;

        using var reader = new StreamReader(fileName);
        while (!reader.EndOfStream)
            output.Add(reader.ReadLine()!);
        return output;
    }
}
