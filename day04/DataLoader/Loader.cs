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
            var winnerString = numbers[0].Split(" ");
            List<int> winners = [];
            foreach(var num in winnerString)
            {
                if (string.IsNullOrWhiteSpace(num))
                    continue;
                winners.Add(int.Parse(num.Trim()));
            }

            var mineString = numbers[1].Split(" ");
            List<int> mine = [];
            foreach(var num in mineString)
            {
                if (string.IsNullOrWhiteSpace(num))
                    continue;
                mine.Add(int.Parse(num.Trim()));
            }
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
