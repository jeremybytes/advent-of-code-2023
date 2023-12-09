namespace DataLoader;

// Part 2 CardType
public enum CardType
{
    J,
    N2,
    N3,
    N4,
    N5,
    N6,
    N7,
    N8,
    N9,
    T,
    Q,
    K,
    A
}

// Part 1 CardType
//public enum CardType
//{
//    N2,
//    N3,
//    N4,
//    N5,
//    N6,
//    N7,
//    N8,
//    N9,
//    T,
//    J,
//    Q,
//    K,
//    A
//}

public class Hand
{
    public List<CardType> Cards { get; set; }
    public int HandValue { get; set; }

    public Hand(string cards, int value)
    {
        Cards = GetCards(cards);
        HandValue = value;
    }

    private List<CardType> GetCards(string cards)
    {
        return cards.Select(GetCard).ToList();
    }

    private CardType GetCard(char card)
    {
        return card switch
        {
            'A' => CardType.A,
            'K' => CardType.K,
            'Q' => CardType.Q,
            'J' => CardType.J,
            'T' => CardType.T,
            '9' => CardType.N9,
            '8' => CardType.N8,
            '7' => CardType.N7,
            '6' => CardType.N6,
            '5' => CardType.N5,
            '4' => CardType.N4,
            '3' => CardType.N3,
            '2' => CardType.N2,
            _ => throw new ArgumentOutOfRangeException(),
        };
    }
}

public static class Loader
{
    public static List<Hand> GetHands(this List<string> hands)
    {
        List<Hand> result = [];
        foreach(var hand in hands)
        {
            string cards = hand.Split(" ")[0];
            int value = int.Parse(hand.Split(" ")[1]);
            result.Add(new(cards, value));
        }
        return result;
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
