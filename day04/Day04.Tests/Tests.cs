using DataLoader;
using static DataLoader.Loader;

namespace Day04.Tests
{
    public class Tests
    {
        string testData =
            """
            Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
            Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
            Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
            Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
            Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
            Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11
            """;

        [Test]
        public void GetCardTotals()
        {
            List<string> data = [.. testData.Split(Environment.NewLine)];
            List<Card> cards = data.GetCards();
            int expected = 30;

            var cardList = cards.GetCardCopies();
            int actual = cardList.Sum();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetCardValues()
        {
            List<string> data = [.. testData.Split(Environment.NewLine)];
            List<Card> cards = data.GetCards();

            int actual = cards[0].GetCardValue();
            int expected = 8;
            Assert.That(actual, Is.EqualTo(expected));

            actual = cards[1].GetCardValue();
            expected = 2;
            Assert.That(actual, Is.EqualTo(expected));

            actual = cards[2].GetCardValue();
            expected = 2;
            Assert.That(actual, Is.EqualTo(expected));

            actual = cards[3].GetCardValue();
            expected = 1;
            Assert.That(actual, Is.EqualTo(expected));

            actual = cards[4].GetCardValue();
            expected = 0;
            Assert.That(actual, Is.EqualTo(expected));

            actual = cards[5].GetCardValue();
            expected = 0;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetCard()
        {
            List<string> input = ["Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53"];
            List<int> expectedWinners = [41, 48, 83, 86, 17];
            List<int> expectedMine = [83, 86, 6, 31, 17, 9, 48, 53];

            var actual = Loader.GetCards(input);

            Assert.That(actual[0].Winners, Is.EqualTo(expectedWinners));
            Assert.That(actual[0].MyNumbers, Is.EqualTo(expectedMine));
        }

        [Test]
        public void GetCardValue()
        {
            Card input = new([41, 48, 83, 86, 17], [83, 86, 6, 31, 17, 9, 48, 53]);
            int expected = 8;

            int actual = input.GetCardValue();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}