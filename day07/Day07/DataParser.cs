using DataLoader;

namespace Day07;

public enum HandStrength
{
    HighCard,
    OnePair,
    TwoPair,
    ThreeOfAKind,
    FullHouse,
    FourOfAKind,
    FiveOfAKind,
}

public class HandComparer : IComparer<Hand>
{
    public int Compare(Hand? x, Hand? y)
    {
        var xHandValue = x!.GetHandStrength();
        var yHandValue = y!.GetHandStrength();

        if (xHandValue != yHandValue)
            return xHandValue.CompareTo(yHandValue);

        var xCards = x.Cards;
        var yCards = y.Cards;
        for (int i = 0; i < 5; i++)
        {
            if (xCards[i] != yCards[i])
                return xCards[i].CompareTo(yCards[i]);
        }
        return 0;
    }
}

public class WildHandComparer : IComparer<Hand>
{
    public int Compare(Hand? x, Hand? y)
    {
        var xHandValue = x!.GetWildHandStrength();
        var yHandValue = y!.GetWildHandStrength();

        if (xHandValue != yHandValue)
            return xHandValue.CompareTo(yHandValue);

        var xCards = x.Cards;
        var yCards = y.Cards;
        for (int i = 0; i < 5; i++)
        {
            if (xCards[i] != yCards[i])
                return xCards[i].CompareTo(yCards[i]);
        }
        return 0;
    }
}

public static class DataParser
{
    public static long GetTotalWinnings(this List<Hand> orderedHands)
    {
        long result = 0;
        for (int i = 0; i < orderedHands.Count; i++)
        {
            result += (i+1) * orderedHands[i].HandValue;
        }
        return result;
    }

    public static List<Hand> GetOrderedHands(this List<Hand> hands)
    {
        return hands.Order(new HandComparer()).ToList();
    }

    public static List<HandStrength> GetHandStrengths(this List<Hand> hands)
    {
        return hands.Select(GetHandStrength).ToList();
    }

    public static HandStrength GetHandStrength(this Hand hand)
    {
        var cardCounts = 
            hand.Cards
                .Distinct()
                .Select(c => (c, hand.Cards.Count(t => c == t)))
                .OrderByDescending(cc => cc.Item2)
                .ToList();

        if (cardCounts[0].Item2 == 5) return HandStrength.FiveOfAKind;

        var first = cardCounts[0].Item2;
        var second = cardCounts[1].Item2;
        return (first, second) switch
        {
            (5, _) => HandStrength.FiveOfAKind,
            (4, _) => HandStrength.FourOfAKind,
            (3, 2) => HandStrength.FullHouse,
            (3, _) => HandStrength.ThreeOfAKind,
            (2, 2) => HandStrength.TwoPair,
            (2, _) => HandStrength.OnePair,
            (_, _) => HandStrength.HighCard,
        };
    }

    public static List<Hand> GetWildOrderedHands(this List<Hand> hands)
    {
        return hands.Order(new WildHandComparer()).ToList();
    }

    public static List<HandStrength> GetWildHandStrengths(this List<Hand> hands)
    {
        return hands.Select(GetWildHandStrength).ToList();
    }

    public static HandStrength GetWildHandStrength(this Hand hand)
    {
        var cardCounts =
            hand.Cards
                .Where(c => c != CardType.J)
                .Distinct()
                .Select(c => (c, hand.Cards.Count(t => c == t)))
                .OrderByDescending(cc => cc.Item2)
                .ToList();

        int jackCount = hand.Cards.Count(c => c == CardType.J);
        if (jackCount == 5) return HandStrength.FiveOfAKind; 

        var first = cardCounts[0].Item2 + jackCount;
        if (first == 5) return HandStrength.FiveOfAKind;

        var second = cardCounts[1].Item2;
        return (first, second) switch
        {
            (5, _) => HandStrength.FiveOfAKind,
            (4, _) => HandStrength.FourOfAKind,
            (3, 2) => HandStrength.FullHouse,
            (3, _) => HandStrength.ThreeOfAKind,
            (2, 2) => HandStrength.TwoPair,
            (2, _) => HandStrength.OnePair,
            (_, _) => HandStrength.HighCard,
        };
    }
}
