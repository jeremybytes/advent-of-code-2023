using DataLoader;

namespace Day07.Tests;

public class Tests
{
    string testData =
        """
        32T3K 765
        T55J5 684
        KK677 28
        KTJJT 220
        QQQJA 483
        """;

    [Test]
    public void LoadHand()
    {
        Hand expected = new Hand("32T3K", 765);
        Hand actual = Loader.GetHands(["32T3K 765"]).Single();

        Assert.That(actual.HandValue, Is.EqualTo(expected.HandValue));
        Assert.That(actual.Cards, Is.EqualTo(expected.Cards));
    }

    [Test]
    public void GetHandStrength()
    {
        Hand hand = new Hand("32T3K", 765);
        HandStrength expected = HandStrength.OnePair;
        HandStrength actual = DataParser.GetHandStrength(hand);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GetHandStrengths()
    {
        var hands = Loader.GetHands(testData.Split(Environment.NewLine).ToList());
        List<HandStrength> expected = new() { 
            HandStrength.OnePair,
            HandStrength.ThreeOfAKind,
            HandStrength.TwoPair,
            HandStrength.TwoPair,
            HandStrength.ThreeOfAKind,
        };

        var actual = hands.GetHandStrengths();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GetOrderedHands()
    {
        var hands = Loader.GetHands(testData.Split(Environment.NewLine).ToList());
        List<Hand> expected = [hands[0], hands[3], hands[2], hands[1], hands[4]];
        var actual = hands.GetOrderedHands();

        Assert.That(actual[0], Is.EqualTo(expected[0]));
        Assert.That(actual[1], Is.EqualTo(expected[1]));
        Assert.That(actual[2], Is.EqualTo(expected[2]));
        Assert.That(actual[3], Is.EqualTo(expected[3]));
        Assert.That(actual[4], Is.EqualTo(expected[4]));
    }

    [Test]
    public void GetTotalWinnings()
    {
        var hands = Loader.GetHands(testData.Split(Environment.NewLine).ToList());
        long expected = 6440;
        long actual = hands.GetOrderedHands().GetTotalWinnings();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GetWildTotalWinnings()
    {
        var hands = Loader.GetHands(testData.Split(Environment.NewLine).ToList());
        long expected = 5905;
        long actual = hands.GetWildOrderedHands().GetTotalWinnings();
        Assert.That(actual, Is.EqualTo(expected));
    }
}